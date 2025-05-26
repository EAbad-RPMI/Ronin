using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource SFXSource;

    //Musica
    public AudioClip Backgroud;
    public AudioClip BackgroudBoss;

    //SFX
    public AudioClip salto;
    public AudioClip espada;
    public AudioClip escalar;
    public AudioClip dolor;
    public AudioClip correr;
    public AudioClip flecha;

    //public Slider volumeSlider;

    private void Start()
    {
        MusicSource.clip = Backgroud;
        //MusicSource.Play();
    }

    public void Boss()
    {
        MusicSource.Stop();
        MusicSource.clip = BackgroudBoss;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
