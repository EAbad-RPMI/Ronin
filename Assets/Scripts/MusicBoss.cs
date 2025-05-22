using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoss : MonoBehaviour
{

    public AudioManager EmpezarBoss;
    //Cuando algo choque con el objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //si es el jugador
        if (collision.CompareTag("Player"))
        {
            EmpezarBoss.GetComponent<AudioManager>().Boss();
        }
    }
}
