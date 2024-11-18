using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ColisionObjetos : MonoBehaviour
{

    private int siguentePantalla;

    // Start is called before the first frame update
    void Start()
    {
        siguentePantalla = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(siguentePantalla);

    }
}
