using System.Collections;
using UnityEngine;

public class ScriptEnemigo : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _vel = 8f;
    private Camera _camara;
    private Vector2 _direccionAleatoria;

    [SerializeField] private Sprite spriteIzquierda;
    [SerializeField] private Sprite spriteDerecha;
    [SerializeField] private Sprite spriteAtras;
    [SerializeField] private Sprite spriteFrente;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _camara = Camera.main;
        StartCoroutine(MoverAleatoriamente());
    }

    void Update()
    {
        _rigidbody2D.velocity = _direccionAleatoria * _vel;
        CambiarSpriteDireccion();
        LimitarPosicionDentroDeCamara();
    }

    private IEnumerator MoverAleatoriamente()
    {
        while (true)
        {
            _direccionAleatoria = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            yield return new WaitForSeconds(2f);
        }
    }

    private void CambiarSpriteDireccion()
    {
        if (_direccionAleatoria.x < 0)
            _spriteRenderer.sprite = spriteIzquierda;
        else if (_direccionAleatoria.x > 0)
            _spriteRenderer.sprite = spriteDerecha;
        else if (_direccionAleatoria.y > 0)
            _spriteRenderer.sprite = spriteAtras;
        else if (_direccionAleatoria.y < 0)
            _spriteRenderer.sprite = spriteFrente;
    }

    private void LimitarPosicionDentroDeCamara()
    {
        Vector2 pantallaMin = _camara.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 pantallaMax = _camara.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 posicionActual = transform.position;

        if (posicionActual.x < pantallaMin.x || posicionActual.x > pantallaMax.x)
        {
            _direccionAleatoria.x = -_direccionAleatoria.x;
            posicionActual.x = Mathf.Clamp(posicionActual.x, pantallaMin.x, pantallaMax.x);
        }

        if (posicionActual.y < pantallaMin.y || posicionActual.y > pantallaMax.y)
        {
            _direccionAleatoria.y = -_direccionAleatoria.y;
            posicionActual.y = Mathf.Clamp(posicionActual.y, pantallaMin.y, pantallaMax.y);
        }

        transform.position = posicionActual;
    }
}
