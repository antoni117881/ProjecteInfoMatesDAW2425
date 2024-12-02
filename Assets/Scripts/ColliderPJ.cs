using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderEnemigos : MonoBehaviour
{
    public GameObject enemigo1;  // Asignar los enemigos en el Inspector
    public GameObject enemigo2;  // Asignar los enemigos en el Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detectar si colisiona con un enemigo
        if (collision.gameObject == enemigo1 || collision.gameObject == enemigo2)
        {
            // Guardar el índice de la escena actual antes de cambiar a ScenaLluita
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("EscenaActual", escenaActual);

            // Cargar ScenaLluita
            SceneManager.LoadScene("ScenaLluita");

            // Pasar el sprite del enemigo a la ScenaLluita
            string enemigoTag = collision.gameObject.tag;  // Obtener el tag del enemigo
            PlayerPrefs.SetString("EnemigoTag", enemigoTag);  // Guardar el tag del enemigo
            PlayerPrefs.Save();
        }
    }
}

