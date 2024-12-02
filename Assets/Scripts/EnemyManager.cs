using UnityEngine;
using UnityEngine.UI;  // A�adir esta l�nea para poder usar Image

public class EnemyManager : MonoBehaviour
{
    public Sprite[] enemySprites;  // Arreglo de sprites de los enemigos
    public Image enemyImage;  // Componente Image de UI donde se mostrar� el sprite

    // Este m�todo se llama cuando el jugador choca con un enemigo
    public void SetEnemySprite(int index)
    {
        // Guardamos el �ndice del sprite en PlayerPrefs
        PlayerPrefs.SetInt("EnemySpriteIndex", index);
        PlayerPrefs.Save();  // Aseg�rate de guardar
    }
}