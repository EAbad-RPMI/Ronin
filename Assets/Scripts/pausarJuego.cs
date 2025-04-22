using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Berta Soto
* Script para pausar el juego
*/
public class pausarJuego : MonoBehaviour
{

    //GameObject del menu de pausa
    public GameObject menuPausa;

    //bool para saber si esta pausado
    public bool pausado;

    // Start is called before the first frame update
    void Start()
    {
        //Desactivamos el menu de pausa
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Si presionan ESC
        if(Input.GetKeyDown(KeyCode.Escape)) {

            //Si el juego esta pausado reanudamos
            if(pausado) {
                Reanudar();

            //Si el juego no esta pausado pausamos
            } else {
                Pausar();
            }
        }
    }

    //Metodo para pausar el juego
    public void Pausar() {

        //Activamos el menu de pausa
        menuPausa.SetActive(true);

        //Paramos el tiempo de juego
        Time.timeScale = 0f;

        //Decimos que el juego esta pausado
        pausado = true;
    }

    //Metodo para reanudar el juego
    public void Reanudar() {

        //Desactivamos el menu de pausa
        menuPausa.SetActive(false);

        //Reanudamos el tiempo de juego
        Time.timeScale = 1f;

        //Decimos que el juego no esta pausado
        pausado = false;
    }
}
