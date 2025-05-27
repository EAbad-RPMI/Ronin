using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Edgar Abad
* Script para manejar la musica del juego
*/
public class AudioManager : MonoBehaviour
{
    //Source de la musica
    public AudioSource MusicSource;

    //Source de los efectos
    public AudioSource SFXSource;

    //Musicas
    public AudioClip Backgroud;
    public AudioClip BackgroudBoss;

    //efectos
    public AudioClip salto;
    public AudioClip espada;
    public AudioClip escalar;
    public AudioClip dolor;
    public AudioClip correr;
    public AudioClip flecha;

    //Reproducimos la musica de fondo
    private void Start()
    {
        MusicSource.clip = Backgroud;
        MusicSource.Play();
    }

    //Reproducimos la musica del boss
    public void Boss()
    {
        MusicSource.Stop();
        MusicSource.clip = BackgroudBoss;
        MusicSource.Play();
    }

    //Reproducimos el SFX que nos pasen
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
