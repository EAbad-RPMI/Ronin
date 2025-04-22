using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        //rigidBody del jugador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //movimiento horizontal con A/D
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //girar el jugador
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 2, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 2, 1);

        //comprobar si el jugador está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        //salto presionando el SPACE
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //Despues de saltar, volvemos a poner la posicion actual de la camara
        float targetY = camara.position.y;

        //Si el jugador está mas de una unidad por encima de la camara
        if (transform.position.y > camara.position.y + 1)
        {
            //La camara pasara a estar dos unidades por encima del jugador
            targetY = transform.position.y + 2;
        }

        // Si el jugador está más de dos unidades por debajo de la cámara
        else if (transform.position.y < camara.position.y - 2)
        {
            //La camara pasara a estar dos unidades por encima del jugador
            targetY = transform.position.y + 2;
        }

        //Actualizamos la posicion donde deberia estar la camara y la movemos
        Vector3 targetPosition = new Vector3(camara.position.x, targetY, camara.position.z);
        camara.position = Vector3.SmoothDamp(camara.position, targetPosition, ref velocidadCam, suavizadoCam);

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