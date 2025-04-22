using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Berta Soto
* Script para manejar la vida del jugador
*/
public class PlayerHealth : MonoBehaviour
{

    //Imagen de la barra de vida y la cantidad de vida
    public Image healthBar;
    public float healthAmount = 60f;

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
    public void perderVida(float damage) {

        //le quitamos la cantidad de vida y llenamos la barra acordemente
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 60f;
    }

    //metodo para ganar vida
    public void ganarVida(float cura) {

        //le aumentamos la cantidad de vida, vemos que no se pase y llenamos la barra acordemente
        healthAmount += cura;
        healthAmount = Mathf.Clamp(healthAmount, 0, 60);
        healthBar.fillAmount = healthAmount / 60f;
    }

    //metodo morir
}
