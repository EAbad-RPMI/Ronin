using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource SFXSource;

    //Musica
    public AudioClip Backgroud;

    //SFX
    public AudioClip espada;

    private void Start()
    {
        MusicSource.clip = Backgroud;
        MusicSource.Play();
    }

    public void PlaySFX()
    {
        SFXSource.PlayOneShot(espada);
    }
}

