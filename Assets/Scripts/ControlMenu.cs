using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Victor Cobo
* Script para controlar los botones de los menus
*/
public class ControlMenu : MonoBehaviour
{
    //Panel del menu
    public GameObject Panel_Menu;

    //Panel de las opciones
    public GameObject Panel_Opciones;

    //Efectos de sonido del menu
    public MenuMusic SFX;

    //Metodo para cargar la escena de cinematica y reproducimos el efecto
    public void Jugar()
    {
        SceneManager.LoadScene("Cinematica");
        SFX.PlaySFX();
    }

    //Metodo para salir del juego
    public void Salir()
    {
        Application.Quit();
    }

    //Metodo para reiniciar la escena del juego
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    //Metodo para activar las opciones
    public void Opciones()
    {
        Panel_Menu.SetActive(false);
        Panel_Opciones.SetActive(true);
        SFX.PlaySFX();
    }

    //Metodo para volver al menu principal
    public void Volver()
    {
        Panel_Menu.SetActive(true);
        Panel_Opciones.SetActive(false);
        SFX.PlaySFX();
    }

    //Metodo para cargar la escena del menu
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}