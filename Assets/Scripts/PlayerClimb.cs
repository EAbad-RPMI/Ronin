using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Edgar Abad
* Script para escalar paredes
*/
public class PlayerClimb : MonoBehaviour
{

    //velocidad de movimiento
    public float moveSpeed = 5f;

    //velocidad de escalada
    public float climbSpeed = 3f;

    //distancia de deteccion
    public float wallDetectionDistance = 0.5f;

    //punto desde el que escalamos
    public Transform wallCheck;

    //capas de paredes
    public LayerMask wallLayer;

    //rigidBody del jugador
    private Rigidbody2D rb;

    //bool de escalada
    private bool isClimbing = false;

    public AudioManager SFX;

    public Animator animator;

    void Start()
    {
        //rigidBody del jugador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //comprobamos si hay una pared escalable delante
        bool wallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right * transform.localScale.x, wallDetectionDistance, wallLayer);

        //escalamos si hay pared y le damos a W
        if (wallDetected && Input.GetKey(KeyCode.W))
        {
            isClimbing = true;
        }

        //dejamos de escalar si deja de haber pared o dejan de escalar
        if (!wallDetected || !Input.GetKey(KeyCode.W))
        {
            isClimbing = false;
            animator.SetBool("Escalar", false);
        }

        //escalar
        if (isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
            animator.SetBool("Escalar", true);
            SFX.GetComponent<AudioManager>().PlaySFX(SFX.escalar);
        }
    }

    //gizmo de prueba
    private void OnDrawGizmosSelected()
    {
        // Dibujar el raycast para visualizar la detección de paredes
        if (wallCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * transform.localScale.x * wallDetectionDistance);
        }
    }
}
