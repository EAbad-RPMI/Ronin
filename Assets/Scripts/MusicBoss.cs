using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Albert Sanchez
* Script para manejar la musica del boss
*/
public class MusicBoss : MonoBehaviour
{

    //audio manager del boss
    public AudioManager EmpezarBoss;

    //Cuando algo choque con el objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //si es el jugador
        if (collision.CompareTag("Player"))
        {
            //Reproducimos la musica del Boss
            EmpezarBoss.GetComponent<AudioManager>().Boss();
        }
    }
}