using UnityEngine;

public class EnemigoDisplay : MonoBehaviour
{
    public GameObject enemigo1Prefab;  // Asigna el prefab del enemigo 1 en el Inspector
    public GameObject enemigo2Prefab;  // Asigna el prefab del enemigo 2 en el Inspector
    public GameObject enemigo3Prefab; 
    public GameObject enemigoFinalPrefab; 
    public GameObject enemicGeneral; 

    void Start()
    {
        // Obtener el tag del enemigo que colision en la escena anterior
        string enemigoTag = PlayerPrefs.GetString("EnemigoTag");

        // Cargar el contenido del prefab en el GameObject 
        if (enemigoTag == "Enemigo1")  // Si el tag es "Enemigo1"
        {
            ReemplazarContenido(enemigo1Prefab);
        }
        else if (enemigoTag == "Enemigo2")  // Si el tag es "Enemigo2"
        {
            ReemplazarContenido(enemigo2Prefab);
        }else if (enemigoTag == "Enemigo3")  // Si el tag es "Enemigo3"
        {
            ReemplazarContenido(enemigo3Prefab);
        }else if (enemigoTag == "EnemigoFinal")  // Si el tag es "EnemigoFinal"
        {
            ReemplazarContenido(enemigoFinalPrefab);
        }
    }

    void ReemplazarContenido(GameObject prefab)
    {
        // Eliminar todos los hijos actuales del GameObject 
        foreach (Transform child in enemicGeneral.transform)
        {
            Destroy(child.gameObject);
        }

        // Instanciar el prefab como hijo del GameObject 
        GameObject nuevoEnemigo = Instantiate(prefab, enemicGeneral.transform);


        
    }
}