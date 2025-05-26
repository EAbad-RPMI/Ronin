using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicMusic : MonoBehaviour
{
    public AudioSource MusicSource;

    //Musica
    public AudioClip Cinematica;

    private void Start()
    {
        MusicSource.clip = Cinematica;
        MusicSource.Play();
    }
}