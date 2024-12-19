using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBootons : MonoBehaviour
{
    private bool juegoPausado = false;
    // Funcionamiento de Botones 
    void Start()
    {
        if (!PlayerPrefs.HasKey("UltimaEscena"))
        {
            PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
        }
    }

    public void AnarAPntallaInicial()
    {

        PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MapaUno");
    }

    public void AnarAPantallaOpcions()
    {
        PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("ScenaOpcions");

        int escenaActualControles = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("EscenaActual", escenaActualControles);
    }

    public void AnaraASortir()
    {
        Debug.Log("El juego se ha cerrado.");
        Application.Quit();
    }

    public void VolverAlMenu()
    {
        PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("ScenaMenu");
    }

    public void AnarAHistoria()
    {
        PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("ScenaHistoria");
    }

    public void RetrocederEscena()
    {

        Time.timeScale = 1f; // El tiempo vuelve a la normalidad 
        juegoPausado = false;
        
        int escenaAnterior = PlayerPrefs.GetInt("EscenaActual");
        SceneManager.LoadScene(escenaAnterior );

           
    }
   
}