using UnityEngine;
using UnityEngine.UI;  // Añadir esta línea para poder usar Image

public class EnemyManager : MonoBehaviour
{
    public Sprite[] enemySprites;  // Arreglo de sprites de los enemigos
    public Image enemyImage;  // Componente Image de UI donde se mostrará el sprite

    // Este método se llama cuando el jugador choca con un enemigo
    public void SetEnemySprite(int index)
    {
        // Guardamos el índice del sprite en PlayerPrefs
        PlayerPrefs.SetInt("EnemySpriteIndex", index);
        PlayerPrefs.Save();  // Asegúrate de guardar
    }
}