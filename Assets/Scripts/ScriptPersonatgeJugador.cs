using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScriptPersonatgeJugador : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _vel = 8;
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
}
