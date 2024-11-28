using System.Collections;
using UnityEngine;

public class ScriptEnemigo : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _vel = 8f;
    private Camera _camara;
    private Vector2 _direccionAleatoria;

    Vector2 pantallaMin;
    Vector2 pantallaMax;
    Vector2 direccionAleatoria;

    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        

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
    }

    void MovimentAleatori()
    {
        direccionAleatoria = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)).normalized;

        
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

       

        float x = Mathf.Clamp(transform.position.x, pantallaMin.x, pantallaMax.x);
        float y = Mathf.Clamp(transform.position.y, pantallaMin.y, pantallaMax.y);

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
