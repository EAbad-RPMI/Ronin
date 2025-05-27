using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Edgar Abad
* Script para finalizar el juego
*/
public class FinalJuego : MonoBehaviour
{

    //Si algo choca
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si es el jugador
        if (collision.CompareTag("Player"))
        {
            //Cargamos el final del juego
            SceneManager.LoadScene("Final");

        }
    }
}
