using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Albert Sanchez
* Script para manejar los ataques del jugador
*/
public class PlayerAttack : MonoBehaviour
{
    //alcance del ataque
    public float attackRange = 1f;

    //punto donde se ataca
    public Transform attackPoint;

    //capas de enemigos
    public LayerMask enemyCheck;

    //Efectos de sonido
    public AudioManager SFX;

    //Animator del GameObject
    public Animator animator;

    void Start()
    {
        //Inicializamos el animator
        animator.GetComponent<Animation>();
    }

    void Update()
    {
        //si hacemos click izquierdo se ataca
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        //Si hacemos click derecho se hace parry
        if (Input.GetMouseButtonDown(1))
        {
            Parry();
        }
    }

    //metodo de ataque
    void Attack()
    {
        //activamos la animacion de ataque
        animator.SetBool("Ataque", true);

        //reproducimos el efecto de sonido
        SFX.PlaySFX(SFX.espada);

        //generamos un array de enemigos golpeados
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyCheck);

        //por cada enemigo golpeado le hacemos perder vida
        foreach (Collider2D enemigo in enemigos)
        {
            enemigo.GetComponent<Enemigo>().perderVida(20);
        }
    }

    //Metodo para hacer parry
    void Parry()
    {
        //activamos la animacion del parry
        animator.SetBool("Parry", true);

        //reproducimos el efecto de sonido
        SFX.PlaySFX(SFX.espada);
    }

    //Metodo para finalizar el ataque
    public void FinalizarAtaque()
    {
        //le decimos al animator que deje de atacar
        animator.SetBool("Ataque", false);
    }

    //metodo para finalizar el parry
    public void FinalizarParry()
    {
        //le decimos al animator que deje de hacer parry
        animator.SetBool("Parry", false);
    }

    //gizmo de prueba
    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}
