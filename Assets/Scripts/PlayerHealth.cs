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

    //Manager de SFX
    public AudioManager SFX;

    //Animator del GameObject
    public Animator animator;

    //bool de si está muerto
    bool muerto = false;

    //Panel de muerte
    public GameObject panelMuerto;

    //Panel de tutorial
    public GameObject panelTut;

    //Boton de pausa
    public GameObject botonPausa;

    //Sprites de la barra de vida
    public Sprite vidaFull;
    public Sprite vidaDos;
    public Sprite vidaUno;
    public Sprite vidaZero;


    void Start()
    {
        //animator del GameObject
        animator.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //Metodos de pruebas
        /*//si presionamos el 4 la vida baja
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
        }*/

    }

    //metodo para perder vida
    public void perderVida(float damage)
    {

        //Reproducimos el SFX de dolor y la animacion
        SFX.PlaySFX(SFX.dolor);
        animator.SetBool("Damage", true);

        //le quitamos la cantidad de vida y actualizamos la barra acordemente
        healthAmount -= damage;
        ActualizarBarra();

        //si la vida es 0 y no hemos muerto antes
        if (healthAmount == 0 && !muerto)
        {
            //llamamos al metodo morir
            Morir();
        }
    }

    //metodo para ganar vida
    public void ganarVida(float cura)
    {

        //le aumentamos la cantidad de vida, vemos que no se pase y llenamos la barra acordemente
        healthAmount += cura;
        ActualizarBarra();
    }

    //Metodo para actualizar la barra de vida
    public void ActualizarBarra()
    {
        //Cogemos el componente de la imagen
        Image healthImage = healthBar.GetComponent<Image>(); // Obt�n el componente una sola vez

        //Cambiamos el sprite dependiendo de la cantidad de vida
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

    //metodo de muerte al personaje
    public void Morir()
    {
        //Si ya estamos muertos no hacemos nada
        if (muerto)
        {
            return;
        }

        //Decimos que el personaje ha muerto y se lo pasamos al animator
        muerto = true;
        animator.SetBool("Muerto", true);
    }

    //Metodo para parar la animacion de muerte
    public void PararMuerte()
    {
        //Decimos al animator que no está muerto
        animator.SetBool("Muerto", false);

        //Activamos el panel de muerte y desactivamos el resto
        panelMuerto.SetActive(true);
        panelTut.SetActive(false);
        botonPausa.SetActive(false);

        //Paramos el tiempo del juego
        Time.timeScale = 0f;
    }

    //Metodo para parar la animacion de damage
    public void PararDamage()
    {
        //Le decimos al animator que ya no le estan haciendo damage
        animator.SetBool("Damage", false);
    }
}
