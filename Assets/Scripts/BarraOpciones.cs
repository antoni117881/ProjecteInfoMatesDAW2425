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
    public TextMeshProUGUI textoPausa; // Referencia al texto UI que mostrar� el mensaje

    // Panel de confirmaci�n de salida
    public GameObject panelConfirmacionSalir; // Panel con los botones "S�" y "No"

    // M�todo para pausar el juego y mostrar texto
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

    // Mostrar el panel de confirmaci�n cuando se intenta salir del juego
    public void MostrarPanelConfirmacion()
    {
        panelConfirmacionSalir.SetActive(true); // Activar el panel de confirmaci�n
        Time.timeScale = 0f; // Pausar el juego al mostrar el panel
    }

    // Si el jugador hace clic en "S�", volver al men� principal
    public void VolverAlMenu()
    {
        PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("ScenaMenu");
    }

    // Si el jugador hace clic en "No", cerrar el panel y continuar con el juego
    public void CancelarSalida()
    {
        panelConfirmacionSalir.SetActive(false); // Desactivar el panel de confirmaci�n
        Time.timeScale = 1f; // Reanudar el juego
    }
}
    