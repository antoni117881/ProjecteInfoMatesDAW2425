using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ColisionObjetos : MonoBehaviour
{

    private int siguentePantalla;


    //[SerializeField] private string escenaCombate = "ScenaMuerte";
    // Start 
    void Start()
    {
        //recibe el index de cada mapa("id") +1 para que nos mande al siguente mapa dependiendo de su id 
        siguentePantalla = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) //si colisiona con pj nos lleva a MapaDeCombate
        {
           SceneManager.LoadScene("ScenaMuerte");
        }//else if (collision.CompareTag("Enemy")){
        //    Debug.Log("Colisión con un enemigo.");
        //}
        else //nos manda al siguiente mapa
        {
           SceneManager.LoadScene(siguentePantalla);
        }

        

    }
      
    
    


}
