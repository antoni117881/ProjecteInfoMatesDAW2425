using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptBootons : MonoBehaviour
{
    // Start is called before the first frame update
    public void AnarAPntallaInicial(){
        SceneManager.LoadScene("MapaUno");
    }
    public void AnarAPantallaOpcions()
    {
        SceneManager.LoadScene("ScenaOpcions");
    }
    public void AnaraASortir()
    {
        Debug.Log("El juego se ha cerrado.");
        Application.Quit();
    }
    public void VolverAlMenu(){
        SceneManager.LoadScene("ScenaMenu");
    }
    public void AnarAHistoria(){
        SceneManager.LoadScene("ScenaHistoria");
    }

}
