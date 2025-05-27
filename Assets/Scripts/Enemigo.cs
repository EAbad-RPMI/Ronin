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

    //capas del player
    public LayerMask playerCheck;

    //Manager de SFX
    public AudioManager SFX;

    //Animator del enemigo
    public Animator animator;

    //Animator del player
    public Animator PlayerAnimator;

    //Espera entre ataques
    public float attackCooldown = 3f;

    //Ultima vez que atacamos
    private float lastAttackTime = -Mathf.Infinity;
    void Start()
    {
        //le damos el valor de vida
        vidaActual = vidaMax;

        //Animator del enemigo
        animator.GetComponent<Animation>();
    }

    //metodo para que los enemigos pierdan vida
    public void perderVida(int damage)
    {

        //le hacemos daño
        vidaActual -= damage;

        //si la vida baja de 0, mueren
        if (vidaActual <= 0)
        {
            morir();
        }
        //si no, se hacen damage
        else
        {
            animator.SetBool("Damage", true);
        }
    }

    //metodo de morir
    void morir()
    {
        //animacion de muerte
        animator.SetBool("Muerte", true);

        //deshabilitamos la colision y el objeto en si
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    void Update()
    {
        //Buscamos al jugador para que le ataquen
        CheckPlayer();
    }

    //metodo de ataque
    void Attack(Collider2D player)
    {
        //Miramos si el jugador está en la animación de parry
        bool parryActive = PlayerAnimator.GetBool("Parry");

        //si no, le hacemos daño
        if (!parryActive)
        {
            player.GetComponent<PlayerHealth>().perderVida(20);
        }

        //animacion de ataque
        animator.SetBool("Ataque", true);

        //reproducimos el sfx
        SFX.PlaySFX(SFX.espada);
    }

    //Metodo para finalizar el
    public void FinalizarAtaque()
    {
        //le decimos al animator que ya no estamos atacando
        animator.SetBool("Ataque", false);
    }

    //Metodo para finalizar el damage
    public void FinalizarDamage()
    {
        //le decimos al animator que ya no estamos siendo atacados
        animator.SetBool("Damage", false);
    }

    //Metodo para finalizar la muerte
    public void FinalizarMuerte()
    {
        //le decimos al animator que ya no estamos muertos
        animator.SetBool("Muerte", false);
    }

    //Metodo para buscar al jugador
    void CheckPlayer()
    {
        //Mira si hay collider del jugador en la area de ataque
        Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerCheck);

        //Si el jugador está dentro y no esta en cooldown
        if (player != null && Time.time >= lastAttackTime + attackCooldown)
        {
            //atacamos al jugador
            Attack(player);
            lastAttackTime = Time.time;
        }
    }

    //gizmo de prueba
    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}
