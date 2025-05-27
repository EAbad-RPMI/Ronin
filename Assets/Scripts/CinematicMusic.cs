using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Berta Soto
* Script para manejar la musica de la cinematica
*/
public class CinematicMusic : MonoBehaviour
{
    //Source de la musica
    public AudioSource MusicSource;

    //Musica de la cinematica
    public AudioClip Cinematica;

    //Reproducimos la musica de la cinematica
    private void Start()
    {
        MusicSource.clip = Cinematica;
        MusicSource.Play();
    }
}