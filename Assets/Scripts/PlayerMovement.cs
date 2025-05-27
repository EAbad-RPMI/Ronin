using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/* Albert Sanchez
* Script para manejar el movimiento del jugador
*/
public class PlayerMovement : MonoBehaviour
{
    //velocidad del jugador
    public float moveSpeed = 5f;

    //salto del jugador
    public float jumpForce = 10f;

    //punto de salto
    public Transform groundCheck;

    //capas del suelo
    public LayerMask groundLayer;

    //rigiBody del componente
    private Rigidbody2D rb;

    //bool de si estamos en el suelo
    private bool isGrounded;

    //input de movimiento
    private float moveInput;

    //transform de la camara
    public Transform camara;

    //suavizado del movimiento de la camara
    public float suavizadoCam = 0.3f;

    //velocidad de la camra
    private Vector3 velocidadCam = Vector3.zero;

    //Manager de SFX
    public AudioManager SFX;

    //Animador del GameObject
    public Animator animator;

    //SpriteRenderer del GameObject
    private SpriteRenderer render;

    //punto de pared
    public Transform wallCheck;

    //punto de ataque
    public Transform attackCheck;

    void Start()
    {
        //rigidBody del jugador
        rb = GetComponent<Rigidbody2D>();

        //animator del jugador
        animator.GetComponent<Animation>();

        //render del jugador
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //comprobar si el jugador está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Cuando el jugador se mueva
    public void OnMove(InputValue value)
    {
        // le damos velocidad al player con el input
        rb.velocity = value.Get<Vector2>() * moveSpeed;

        // Mover al personaje
        Vector2 moveInput = value.Get<Vector2>();
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        // Solo nos interesa el eje horizontal (x)
        float horizontalInput = moveInput.x;

        // Girar el jugador y los checks según la dirección del movimiento
        if (horizontalInput > 0.1f)
        {
            render.flipX = false;
            wallCheck.localPosition = new Vector3(0.5f, -1.25f, 0f);
            attackCheck.localPosition = new Vector3(1f, 0f, 0f);
        }
        else if (horizontalInput < -0.1f)
        {
            render.flipX = true;
            wallCheck.localPosition = new Vector3(-1f, -1.25f, 0f);
            attackCheck.localPosition = new Vector3(-1.5f, 0f, 0f);
        }

        //Si estamos en el suelo
        if (isGrounded)
        {
            //Le decimos al animator que haga la animación de correr
            float velocidadHorizontal = Mathf.Abs(rb.velocity.x);
            animator.SetFloat("Velocidad_Correr", velocidadHorizontal);

            //Le decimos al animator que deje de saltar
            animator.SetBool("Salto", false);

            //Reproducimos el audio de correr
            SFX.PlaySFX(SFX.correr);
        }

    }


    //Cuando el jugador salta
    public void OnJump(InputValue value)
    {
        //Si el jugador está presionando el boton de salto
        if (value.isPressed)
        {
            //vemos si el jugador está en el suelo
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

            //Si está en el suelo
            if (isGrounded)
            {
                //Le decimos al animator que salte
                animator.SetBool("Salto", true);

                //Actualizamos la velocidad del player
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                //Reproducimos el audio de saltar
                SFX.GetComponent<AudioManager>().PlaySFX(SFX.salto);

                //Ajustamos la posición de la cámara
                float targetY = camara.position.y;

                //Si el jugador está más de una unidad por encima de la cámara
                if (transform.position.y > camara.position.y + 1)
                {
                    //La cámara pasará a estar dos unidades por encima del jugador
                    targetY = transform.position.y + 2;
                }
                //Si el jugador está más de dos unidades por debajo de la cámara
                else if (transform.position.y < camara.position.y - 2)
                {
                    //La cámara pasará a estar dos unidades por encima del jugador
                    targetY = transform.position.y + 2;
                }

                // Actualizamos la posición donde debería estar la cámara y la movemos
                Vector3 targetPosition = new Vector3(camara.position.x, targetY, camara.position.z);
                camara.position = Vector3.SmoothDamp(camara.position, targetPosition, ref velocidadCam, suavizadoCam);
            }
        }
    }

    //gizmo para pruebas
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.3f); // Asegúrate de que este círculo toque el suelo
        }
    }
}