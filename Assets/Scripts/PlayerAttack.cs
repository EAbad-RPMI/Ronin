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

    void Update()
    {
        //si hacemos click izquierdo se ataca
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }

    //metodo de ataque
    void Attack() {

        //animacion ataque

        //generamos un array de enemigos golpeados
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyCheck);

        //por cada enemigo golpeado le hacemos perder vida
        foreach (Collider2D enemigo in enemigos) {
            enemigo.GetComponent<Enemigo>().perderVida(20);
        }
    }

    //gizmo de prueba
    private void OnDrawGizmosSelected(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
        
    }
}
