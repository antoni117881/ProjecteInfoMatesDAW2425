using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBootons : MonoBehaviour
{
    private bool juegoPausado = false;
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
        if (PlayerPrefs.HasKey("UltimaEscena"))
        {
            string ultimaEscena = PlayerPrefs.GetString("UltimaEscena");
            if (!string.IsNullOrEmpty(ultimaEscena) && ultimaEscena != SceneManager.GetActiveScene().name)
            {
                Time.timeScale = 1f; // El tiempo vuelve a la normalidad
                juegoPausado = false;
                SceneManager.LoadScene(ultimaEscena);
                
            }
        }
    }
}