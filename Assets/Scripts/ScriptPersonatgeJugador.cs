using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPersonatgeJugador : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _vel = 6;  // variavle parala velocidad 
    void Start()   
    {
        _rigidbody2D =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputHoritzontal = Input.GetAxisRaw("Horizontal") * _vel;

        _rigidbody2D.velocity = new Vector2(inputHoritzontal, _rigidbody2D.velocity.y);

        float inputVertical = Input.GetAxisRaw("Vertical") * _vel;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, inputVertical);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) //si colisiona con pj nos lleva a MapaDeCombate
        {
            SceneManager.LoadScene("ScenaLluita");
        }
        //else //nos manda al siguiente mapa
        //{
        //   SceneManager.LoadScene(siguentePantalla);
        //}



    }
}
    