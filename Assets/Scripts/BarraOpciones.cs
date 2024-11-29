using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class BarraOpciones : MonoBehaviour
{


    // _______________  BOTON PAUSA_______________ // 
    private bool juegoPausado = false;
    public  TextMeshProUGUI  textoPausa; // Referencia al texto UI que mostrará el mensaje

    // Método para pausar el juego y mostrar texto
    public void PausarJuego()
    {
        if (juegoPausado)
        {
            Time.timeScale = 1f; // Reanudar el juego
            juegoPausado = false;
            textoPausa.gameObject.SetActive(false); // Ocultar el texto
        }
        else
        {
            Time.timeScale = 0f; // Pausar el juego
            juegoPausado = true;
            textoPausa.text = "El juego se ha pausado"; // Actualizar el mensaje
            textoPausa.gameObject.SetActive(true); // Mostrar el texto
        }
    }
}
    