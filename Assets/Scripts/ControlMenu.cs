using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Victor Cobo
* Script para controlar los botones de los menus
*/
public class ControlMenu : MonoBehaviour
{
    //Metodo para cargar la escena del juego
    public void Jugar() {
        SceneManager.LoadScene("Juego");
    }

    //Metodo para salir del juego
    public void Salir() {
        Application.Quit();
    }

    //Metodo para abrir las opciones
    public void Opciones() {

    }

    //Metodo para cargar la escena del menu
    public void Menu() {
       SceneManager.LoadScene("Menu"); 
       Time.timeScale = 1f;
    }
}