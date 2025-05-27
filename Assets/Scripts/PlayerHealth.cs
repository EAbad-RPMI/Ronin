using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* Berta Soto
* Script para manejar la vida del jugador
*/
public class PlayerHealth : MonoBehaviour
{

    //Imagen de la barra de vida y la cantidad de vida
    public GameObject healthBar;
    public float healthAmount = 60f;

    public AudioManager SFX;

    public Animator animator;

    bool muerto = false;

    public GameObject panelMuerto;

    public GameObject panelTut;

    public GameObject botonPausa;

    public Sprite vidaFull;
    public Sprite vidaDos;
    public Sprite vidaUno;
    public Sprite vidaZero;


    void Start()
    {
        animator.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //si presionamos el 4 la vida baja
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //perdemos 20 puntos de vida
            perderVida(20f);
        }

        //si presionamos el 5 la vida baja
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //ganamos 20 puntos de vida
            ganarVida(20f);
        }

    }

    //metodo para perder vida
    public void perderVida(float damage)
    {

        SFX.PlaySFX(SFX.dolor);

        //le quitamos la cantidad de vida y llenamos la barra acordemente
        healthAmount -= damage;
        ActualizarBarra();
        //healthBar.fillAmount = healthAmount / 60f;

        if (healthAmount == 0 && !muerto)
        {
            Morir();
        }
    }

    //metodo para ganar vida
    public void ganarVida(float cura)
    {

        //le aumentamos la cantidad de vida, vemos que no se pase y llenamos la barra acordemente
        healthAmount += cura;
        ActualizarBarra();
        //healthAmount = Mathf.Clamp(healthAmount, 0, 60);
        //healthBar.fillAmount = healthAmount / 60f;
    }

    public void ActualizarBarra()
    {
        Image healthImage = healthBar.GetComponent<Image>(); // Obtén el componente una sola vez

        if (healthAmount >= 60f)
        {
            healthImage.sprite = vidaFull;
        }
        else if (healthAmount >= 40f)
        {
            healthImage.sprite = vidaDos;
        }
        else if (healthAmount >= 20f)
        {
            healthImage.sprite = vidaUno;
        }
        else if (healthAmount >= 0f)
        {
            healthImage.sprite = vidaZero;
        }
    }

    public void Morir()
    {
        if (muerto)
        {
            return;
        }

        muerto = true;
        animator.SetBool("Muerto", true);
    }

    public void PararMuerte()
    {
        animator.SetBool("Muerto", false);
        panelMuerto.SetActive(true);
        panelTut.SetActive(false);
        botonPausa.SetActive(false);
        Time.timeScale = 0f;
    }
}
