using UnityEngine;

public class EnemigoDisplay : MonoBehaviour
{
    public GameObject enemigo1Prefab;  // Asigna el prefab del enemigo 1 en el Inspector
    public GameObject enemigo2Prefab;  // Asigna el prefab del enemigo 2 en el Inspector

    public GameObject enemicGeneral; // GameObject vac�o que contendr� el enemigo

    void Start()
    {
        // Obtener el tag del enemigo que colision� en la escena anterior
        string enemigoTag = PlayerPrefs.GetString("EnemigoTag");

        // Cargar el contenido del prefab en el GameObject vac�o
        if (enemigoTag == "Enemigo1")  // Si el tag es "Enemigo1"
        {
            ReemplazarContenido(enemigo1Prefab);
        }
        else if (enemigoTag == "Enemigo2")  // Si el tag es "Enemigo2"
        {
            ReemplazarContenido(enemigo2Prefab);
        }
    }

    void ReemplazarContenido(GameObject prefab)
    {
        // Eliminar todos los hijos actuales del GameObject vac�o
        foreach (Transform child in enemicGeneral.transform)
        {
            Destroy(child.gameObject);
        }

        // Instanciar el prefab como hijo del GameObject vac�o
        GameObject nuevoEnemigo = Instantiate(prefab, enemicGeneral.transform);


        //// Opcional: Resetear posici�n y rotaci�n local para alinear con el padre
        //nuevoEnemigo.transform.localPosition = Vector3.zero;
        //nuevoEnemigo.transform.localRotation = Quaternion.identity;
        //nuevoEnemigo.transform.localScale = Vector3.one;
    }
}