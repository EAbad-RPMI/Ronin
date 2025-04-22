using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Edgar Abad
* Script para mover la camara entre "niveles"
*/
public class MoverCamara : MonoBehaviour
{
    //Transform del jugador
    public Transform player;

    //Transform de la camara
    public Transform camara;

    //Suavidad del movimiento
    public float smoothSpeed = 0.2f;

    //velocidad del movimiento de la camara
    private Vector3 velocity = Vector3.zero;

    //Cuando algo choque con el objeto
    private void OnTriggerEnter2D(Collider2D collision) {

        //Si es el jugador
        if (collision.CompareTag("Player")) {

            //si el jugador mira hacia la derecha
            if (player.localScale.x > 0)
            {
                //Movemos la camara 17.8 unidades a la derecha
                camara.position = new Vector3 (camara.position.x + 17.8f, camara.position.y, camara.position.z);       
            }

            //si el jugador mira hacia la izquierda
            else if (player.localScale.x < 0)
            {   
                //Movemos la camara 17.8 unidades a la izquierda
                camara.position = new Vector3 (camara.position.x - 17.8f, camara.position.y, camara.position.z);       
            }
        }
    }
}
