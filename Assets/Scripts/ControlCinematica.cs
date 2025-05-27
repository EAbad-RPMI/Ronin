using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/* Berta Soto
* Script para manejar la cinematica
*/
public class ControlCinematica : MonoBehaviour
{

    //animator de la cinematica
    public Animator animCine;

    //subtitulos
    public TMP_Text texto;

    //imagenes de la cinematica
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public GameObject img4;

    // Start is called before the first frame update
    void Start()
    {
        //Empezamos la rutina de la cinematica
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        //Vamos cambiando el texto y las imagenes según pase el tiempo
        texto.text = "Samurai, no cumpliste tu mision... Suicidate.";
        yield return new WaitForSeconds(5);
        img1.SetActive(false);
        texto.text = "*hhhnnggg....* No, Abuelo!!!\n ME VENGARE!";
        yield return new WaitForSeconds(5);
        img2.SetActive(false);
        texto.text = "*ahhhgg..* Esto va por ti, Abuelo...";
        yield return new WaitForSeconds(5);
        img3.SetActive(false);
        texto.text = "HA MATADO AL SHOGUN!!! ATRAPENLO!!!";
        yield return new WaitForSeconds(5);
        FadeOut();
        SceneManager.LoadScene("Juego");
    }

    //Metodo para hacer Fade In
    public void FadeIn()
    {
        animCine.Play("FadeIn");
    }

    //Metodo para hacer Fade Out
    public void FadeOut()
    {
        animCine.Play("FadeOut");
    }
}
