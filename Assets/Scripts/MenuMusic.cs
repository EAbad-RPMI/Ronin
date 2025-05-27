using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Victor Cobo
* Script para manejar la musica y sonidos del menu
*/
public class MenuMusic : MonoBehaviour
{
    //Source de la musica
    public AudioSource MusicSource;

    //Source de los efectos
    public AudioSource SFXSource;

    //Musica
    public AudioClip Backgroud;

    //SFX
    public AudioClip espada;

    //Reproducimos la musica del menu
    private void Start()
    {
        MusicSource.clip = Backgroud;
        MusicSource.Play();
    }

    //Metodo para reproducir los efectos al hacer click
    public void PlaySFX()
    {
        SFXSource.PlayOneShot(espada);
    }
}

