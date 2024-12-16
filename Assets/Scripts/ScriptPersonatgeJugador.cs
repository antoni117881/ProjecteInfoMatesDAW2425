using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPersonatgeJugador : MonoBehaviour
{
    private int siguentePantalla;

    private Rigidbody2D _rigidbody2D;
    private float _vel = 6;  // variable para la velocidad

    //public string sceneName = "ScenaLluita"; // Nombre de la escena de lucha
    //public int enemyID; // Identificador único del enemigo

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        // Recibe el index de cada mapa ("id") +1 para que nos mande al siguiente mapa dependiendo de su id
        siguentePantalla = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update
    void Update()
    {
        // Obtener inputs horizontales y verticales
        float inputHoritzontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        // Crear el vector de movimiento
        Vector2 movement = new Vector2(inputHoritzontal, inputVertical);

        // Normalizar el vector de movimiento para evitar velocidad extra en diagonales
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        // Aplicar el movimiento con la velocidad configurada
        _rigidbody2D.velocity = movement * _vel;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.CompareTag("Enemy")) //si colisiona con pj nos lleva a MapaDeCombate
    //    {
    //        //DadesGlobalsLluita.setEnemigoActual(collision.gameObject);
    //        //DadesGlobalsLluita.setposicioEnemigo(collision.gameObject.transform.position);
    //        //DadesGlobalsLluita.setposicioJugadr(this.gameObject.transform.position);
    //        Debug.Log("Jugador chocó con el enemigo ID: " + enemyID);
    //        // Puedes guardar el ID del enemigo para usarlo en la escena de lucha
    //        PlayerPrefs.SetInt("LastEnemyID", enemyID);
    //        SceneManager.LoadScene("ScenaLluita");
    //    }

    //    //else //nos manda al siguiente mapa
    //    //{
    //    //   SceneManager.LoadScene(siguentePantalla);
    //    //}

    //}
}
