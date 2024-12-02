using UnityEngine;
using UnityEngine.UI;

public class EnemigoDisplay : MonoBehaviour
{
    public Image imageEnemigo;  // El componente Image en el que mostrar el sprite
    public Sprite enemigo1Sprite;  // Asigna los sprites de los enemigos en el Inspector
    public Sprite enemigo2Sprite;  // Asigna los sprites de los enemigos en el Inspector

    void Start()
    {
        // Obtener el tag del enemigo que colisionó en la escena anterior
        string enemigoTag = PlayerPrefs.GetString("EnemigoTag");

        // Mostrar el sprite adecuado dependiendo del tag
        if (enemigoTag == "Enemigo1")  // Si el tag es "Enemigo1", mostrar el sprite del Enemigo 1
        {
            imageEnemigo.sprite = enemigo1Sprite;
        }
        else if (enemigoTag == "Enemigo2")  // Si el tag es "Enemigo2", mostrar el sprite del Enemigo 2
        {
            imageEnemigo.sprite = enemigo2Sprite;
        }
    }

   
}