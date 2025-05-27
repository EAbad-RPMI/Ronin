using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Victor Cobo
* Script para manejar los enemigos
*/
public class Enemigo : MonoBehaviour
{

    //int de la vida maxima que depende del enemigo e int de la vida actual
    public int vidaMax;
    int vidaActual;

    //alcance del ataque
    public float attackRange = 1f;

    //punto donde se ataca
    public Transform attackPoint;

    //capas de enemigos
    public LayerMask enemyCheck;

    public AudioManager SFX;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //le damos el valor de vida
        vidaActual = vidaMax;
        animator.GetComponent<Animation>();
    }

    //metodo para que los enemigos pierdan vida
    public void perderVida(int damage)
    {

        //le hacemos daño
        vidaActual -= damage;

        //animacion daño

        //si la vida baja de 0, mueren
        if (vidaActual <= 0)
        {
            morir();
        }
    }

    //metodo de morir
    void morir()
    {

        //animacion morir

        //deshabilitamos la colision y el objeto en si
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    void Update()
    {
        /*//si hacemos click izquierdo se ataca
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }*/
    }

    //metodo de ataque
    void Attack()
    {

        /*animator.SetBool("Ataque", true);

        SFX.PlaySFX(SFX.espada);

        //generamos un array de enemigos golpeados
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyCheck);

        //por cada enemigo golpeado le hacemos perder vida
        foreach (Collider2D enemigo in enemigos)
        {
            enemigo.GetComponent<Enemigo>().perderVida(20);
        }*/
    }

    public void FinalizarAtaque()
    {
        animator.SetBool("Ataque", false);
    }

    //gizmo de prueba
    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}
