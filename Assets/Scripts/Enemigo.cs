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

    // Start is called before the first frame update
    void Start()
    {
        //le damos el valor de vida
        vidaActual = vidaMax;
    }

    //metodo para que los enemigos pierdan vida
    public void perderVida(int damage) {

        //le hacemos daño
        vidaActual -= damage;

        //animacion daño

        //si la vida baja de 0, mueren
        if (vidaActual <= 0){
            morir();
        }
    }

    //metodo de morir
    void morir() {

        //animacion morir

        //deshabilitamos la colision y el objeto en si
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;    
    }
}
