using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Victor Cobo
* Script para manejar los tutoriales
*/
public class ControlTutorial : MonoBehaviour
{
    //int del numero del tutorial y texto donde vamos a escribir el tutorial
    public int numTut;
    public Text textTut;
    public Image panel;

    //Cuando algo choque con el objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //si es el jugador
        if (collision.CompareTag("Player"))
        {

            //dependiendo del numero del tutorial
            switch (numTut)
            {

                //si es el caso 0 es para borrar el texto
                case 0:
                    textTut.text = "";
                    panel.color = new Color(1, 1, 1, 0);
                    break;

                //si es el primero es el de movimiento
                case 1:
                    textTut.text = "Pulsa AD para moverte";
                    panel.color = new Color32(145, 145, 145, 204);
                    break;

                //si es el segundo es el de salto
                case 2:
                    textTut.text = "Pulsa SPACE para saltar";
                    panel.color = new Color32(145, 145, 145, 204);
                    break;

                //si es el segundo es el de salto
                case 3:
                    textTut.text = "Click izquierdo para atacar\nClick derecho para bloquer ataques";
                    panel.color = new Color32(145, 145, 145, 204);
                    break;

                //si es el tercero es el de escalada
                case 4:
                    textTut.text = "Pulsa W para escalar paredes grandes";
                    panel.color = new Color32(145, 145, 145, 204);
                    break;
            }

        }
    }
}
