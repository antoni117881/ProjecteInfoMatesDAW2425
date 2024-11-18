using System.Collections;
using UnityEngine;

public class ScriptEnemigo : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _vel = 8;
    private Camera _camara;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _camara = Camera.main; // Obtener la cámara principal
        StartCoroutine(MoverAleatoriamente());
    }

    IEnumerator MoverAleatoriamente()
    {
        while (true)
        {
           
            Vector2 direccionAleatoria = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)).normalized;

            
            _rigidbody2D.velocity = direccionAleatoria * _vel;

            
            yield return new WaitForSeconds(2f);

            LimitarPosicionDentroDeCamara();
        }
    }

    void LimitarPosicionDentroDeCamara()
    {
  
        Vector2 pantallaMin = _camara.ViewportToWorldPoint(new Vector2(0, 0)); 
        Vector2 pantallaMax = _camara.ViewportToWorldPoint(new Vector2(1, 1)); 

    
        float x = Mathf.Clamp(transform.position.x, pantallaMin.x, pantallaMax.x);
        float y = Mathf.Clamp(transform.position.y, pantallaMin.y, pantallaMax.y);

        transform.position = new Vector2(x, y);
    }
}
