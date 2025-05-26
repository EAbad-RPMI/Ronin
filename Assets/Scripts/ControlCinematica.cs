using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControlCinematica : MonoBehaviour
{

    public Animator animCine;
    public TMP_Text texto;
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public GameObject img4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        texto.text = "Samurai, no cumpliste tu misión... Suicídate.";
        yield return new WaitForSeconds(5);
        img1.SetActive(false);
        texto.text = "*hhhnnggg....* No, Abuelo!!!\n ME VENGARÉ!";
        yield return new WaitForSeconds(5);
        img2.SetActive(false);
        texto.text = "*ahhhgg..* Esto va por ti, Abuelo...";
        yield return new WaitForSeconds(5);
        img3.SetActive(false);
        texto.text = "HA MATADO AL SHOGUN!!! ATRÁPENLO!!!";
        yield return new WaitForSeconds(5);
        FadeOut();
        SceneManager.LoadScene("Juego");
    }

    public void FadeIn()
    {
        animCine.Play("FadeIn");
    }

    public void FadeOut()
    {
        animCine.Play("FadeOut");
    }
}
