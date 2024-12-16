using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderEnemigos : MonoBehaviour
{
    public GameObject enemigo1;  // Asignar los enemigos 
    public GameObject enemigo2;  // Asignar los enemigos 



    public GameObject FondoPelea1; // Asigna este objeto 
    public GameObject FondoPelea2;
    public GameObject FondoPelea3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // Detectar si colisiona con un enemigo
        if (collision.gameObject == enemigo1 || collision.gameObject == enemigo2)
        {
            // Guardar el Indice de la escena actual antes de cambiar a ScenaLluita
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("EscenaActual", escenaActual);

            // Cargar ScenaLluita
            SceneManager.LoadScene("ScenaLluita");

            // Pasar el sprite del enemigo a la ScenaLluita
            string enemigoTag = collision.gameObject.tag;  // Obtener el tag del enemigo
            PlayerPrefs.SetString("EnemigoTag", enemigoTag);  // Guardar el tag del enemigo
            PlayerPrefs.Save();
            // Activa el fondo de pantalla
            
            
            if(enemigoTag == "Enemigo1" )
            {
                FondoPelea1.gameObject.SetActive(true);
            }
            else if (enemigoTag == "Enemigo2")
            {
                FondoPelea2.gameObject.SetActive(true);

            }
            else if(enemigoTag== "EnemigoFinal")
            {
                FondoPelea3.gameObject.SetActive(true);
            }
        }
    }
}

