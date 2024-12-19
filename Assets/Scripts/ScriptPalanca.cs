using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPalanca : MonoBehaviour
{




    public Transform leverHandle; // La parte de la palanca que se mover� 
    public Vector3 targetRotation; // Rotaci�n final de la palanca 
    public float rotationSpeed = 5f; // Velocidad de movimiento 
    public GameObject interactionSprite; // Referencia al sprite de interacci�n 
    public GameObject Puerta;
    public Vector3 targetRotation2;

    private bool isPlayerTouching = false; // Indica si el jugador est� tocando la palanca
    private bool isActivated = false; // Indica si la palanca est� activada

    void Start()
    {
        //Asegurarse de que el sprite de interacci�n est� oculto al inicio
        if (interactionSprite != null)
        {
            interactionSprite.SetActive(false);
        }
    }

    void Update()
    {
        // Detectar si el jugador presiona "E" y est� tocando la palanca
        if (isPlayerTouching && Input.GetKeyDown(KeyCode.E))
        {
            isActivated = true; // Alternar el estado de la palanca
            Debug.Log(" APRIETA LA E");
        }

        // Rotar la palanca hacia la posici�n objetivo
        if (isActivated)
        {
            leverHandle.localRotation = Quaternion.Lerp(
                leverHandle.localRotation,
                Quaternion.Euler(targetRotation),
                Time.deltaTime * rotationSpeed

            );
            Puerta.SetActive(false);
            Debug.Log(" � ESTA ACTIVADO");
        }
        else
        {
            // Volver a la posici�n inicial si no est� activada
            leverHandle.localRotation = Quaternion.Lerp(
                leverHandle.localRotation,
                Quaternion.identity,
                Time.deltaTime * rotationSpeed
            );
        }
    }

    // Detectar si el jugador est� tocando la palanca
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador toc� la palanca");
            isPlayerTouching = true;

            // Mostrar el sprite de interacci�n
            if (interactionSprite != null)
            {
                interactionSprite.SetActive(true);
            }
            if (collision.gameObject.CompareTag("Tocar"))
            {
                Debug.Log("jugador toco para ir a otra scena ");
                isPlayerTouching = true;
                PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("ScenaFinal");


            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador dej� de tocar la palanca");
            isPlayerTouching = false;

            // Ocultar el sprite de interacci�n
            if (interactionSprite != null)
            {
                interactionSprite.SetActive(false);
            }
        }
       
    }
}