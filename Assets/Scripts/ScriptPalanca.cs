using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPalanca : MonoBehaviour


{
    public Transform leverHandle; // La parte de la palanca que se moverá
    public Vector3 targetRotation; // Rotación final de la palanca
    public float rotationSpeed = 5f; // Velocidad de movimiento
    public GameObject interactionSprite; // Referencia al sprite de interacción

    private bool isPlayerTouching = false; // Indica si el jugador está tocando la palanca
    private bool isActivated = false; // Indica si la palanca está activada

    void Start()
    {
        // Asegurarse de que el sprite de interacción esté oculto al inicio
        if (interactionSprite != null)
        {
            interactionSprite.SetActive(false);
        }
    }

    void Update()
    {
        // Detectar si el jugador presiona "E" y está tocando la palanca
        if (isPlayerTouching && Input.GetKeyDown(KeyCode.E))
        {
            isActivated = true; // Alternar el estado de la palanca
        }

        // Rotar la palanca hacia la posición objetivo
        if (isActivated)
        {
            leverHandle.localRotation = Quaternion.Lerp(
                leverHandle.localRotation,
                Quaternion.Euler(targetRotation),
                Time.deltaTime * rotationSpeed
            );
        }
        else
        {
            // Volver a la posición inicial si no está activada
            leverHandle.localRotation = Quaternion.Lerp(
                leverHandle.localRotation,
                Quaternion.identity,
                Time.deltaTime * rotationSpeed
            );
        }
    }

    // Detectar si el jugador está tocando la palanca
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador tocó la palanca");
            isPlayerTouching = true;


            // Mostrar el sprite de interacción
            if (interactionSprite != null)
            {
                interactionSprite.SetActive(true);
            }
        }
    }
    // Detectar si el jugador deja de tocar la palanca
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = false;

            // Ocultar el sprite de interacción
            if (interactionSprite != null)
            {
                interactionSprite.SetActive(false);
            }
        }
    }


 
   
}


