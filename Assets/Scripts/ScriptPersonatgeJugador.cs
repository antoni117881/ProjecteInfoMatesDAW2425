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

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        // Recibe el index de cada mapa ("id") +1 para que nos mande al siguiente mapa dependiendo de su id
        siguentePantalla = SceneManager.GetActiveScene().buildIndex + 1;
    }


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

   
}
