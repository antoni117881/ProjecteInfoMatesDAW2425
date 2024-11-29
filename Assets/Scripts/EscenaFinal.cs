using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaFinal : MonoBehaviour
{
    // Tiempo de espera antes de cambiar de escena
    public float delay = 5f;

    void Start()
    {
        // Iniciar la transición después del retraso
        StartCoroutine(SwitchSceneAfterDelay());
    }

    IEnumerator SwitchSceneAfterDelay()
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Cambiar a la escena llamada "EscenaFinal"
        SceneManager.LoadScene("ScenaMenu");
    }
}
