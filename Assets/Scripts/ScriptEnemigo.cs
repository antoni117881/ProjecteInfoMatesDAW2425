using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScriptEnemigo : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _vel = 8f;
    private Camera _camara;
    private Vector2 _direccionAleatoria;
    private SpriteRenderer _spriteRenderer;

    public Sprite spriteArriba;  // Sprite para cuando el enemigo se mueve hacia arriba
    public Sprite spriteAbajo;  // Sprite para cuando el enemigo se mueve hacia abajo
    public Sprite spriteIzquierda;  // Sprite para cuando el enemigo se mueve hacia la izquierda
    public Sprite spriteDerecha;  // Sprite para cuando el enemigo se mueve hacia la derecha


    







    Vector2 pantallaMin;
    Vector2 pantallaMax;
    Vector2 direccionAleatoria;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();  // Obtiene el SpriteRenderer del objeto

        pantallaMin = new Vector2(-7.3f, -3.3f);
        pantallaMax = new Vector2(5.3f, 3f);

        InvokeRepeating("MovimentAleatori", 0f, 1f);
    }

    private void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos = novaPos + _vel * direccionAleatoria * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, pantallaMin.x, pantallaMax.x);
        novaPos.y = Mathf.Clamp(novaPos.y, pantallaMin.y, pantallaMax.y);

        transform.position = novaPos;

        CambiarSpriteDireccion(); // Llamamos al método que cambia el sprite
    }

    void MovimentAleatori()
    {
        direccionAleatoria = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)).normalized;
    }

    void CambiarSpriteDireccion()
    {
        // Cambia el sprite dependiendo de la dirección del movimiento
        if (direccionAleatoria.y > 0 && Mathf.Abs(direccionAleatoria.y) > Mathf.Abs(direccionAleatoria.x))
        {
            _spriteRenderer.sprite = spriteArriba; // Movimiento hacia arriba
        }
        else if (direccionAleatoria.y < 0 && Mathf.Abs(direccionAleatoria.y) > Mathf.Abs(direccionAleatoria.x))
        {
            _spriteRenderer.sprite = spriteAbajo; // Movimiento hacia abajo
        }
        else if (direccionAleatoria.x > 0)
        {
            _spriteRenderer.sprite = spriteDerecha; // Movimiento hacia la derecha
        }
        else if (direccionAleatoria.x < 0)
        {
            _spriteRenderer.sprite = spriteIzquierda; // Movimiento hacia la izquierda
        }
    }

    


}
