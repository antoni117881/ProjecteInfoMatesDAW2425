using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BarraOpciones : MonoBehaviour
{
    private bool juegoPausado = false;
    public TextMeshProUGUI textoPausa;
    public GameObject panelConfirmacionSalir;
    public GameObject panelpausa;

    public void PausarJuego()
    {
        if (juegoPausado)
        {
            Time.timeScale = 1f;
            juegoPausado = false;
            panelpausa.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            juegoPausado = true;
            panelpausa.SetActive(true);
        }
    }

    public void IrAControles()
    {
        PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        SceneManager.LoadScene("EscenaControles");
    }

    public void VolverAtras()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(PlayerPrefs.GetString("UltimaEscena"));
    }

    public void MostrarPanelConfirmacion()
    {
        panelConfirmacionSalir.SetActive(true);
        Time.timeScale = 0f;
    }

    public void VolverAlMenu()
    {
        PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("ScenaMenu");
    }

    public void CancelarSalida()
    {
        panelConfirmacionSalir.SetActive(false);
        Time.timeScale = 1f;
    }
}
