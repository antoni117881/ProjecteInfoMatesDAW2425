using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptlluita1 : MonoBehaviour
{
   
    public GameObject Jugador;// El GameObject "Jugador" que deseas mover
    public GameObject Enemic1;
    public GameObject Enemic2;
    public GameObject Enemic3;
    public GameObject Enemic4;
    public float distanciaMovimiento = 0.5f; // Distancia hacia cada lado
    public float velocidadMovimiento = 9f; // Velocidad del movimiento
    private Vector3 posicionInicialJugador;
    private Vector3 posicionInicialEnemic;


    void Start()
    {
        
        // Guardar la posición inicial del objeto
        if (Jugador != null)
        {
            posicionInicialJugador = Jugador.transform.position;
        }
        if (Enemic1 != null)
        {
            posicionInicialEnemic = Jugador.transform.position;
        }
        if (Enemic2 != null)
        {
            posicionInicialEnemic = Jugador.transform.position;
        }
    }

    // Método público que se puede llamar desde otros scripts
    public void MoverJugador()
    {
        if (Jugador != null)
        {
            // Inicia la corutina para mover al jugador
            StartCoroutine(MoverIdaYVuelta());
        }
        else
        {
            Debug.LogError("El objeto Jugador no está asignado en el script.");
        }
    }

    private IEnumerator MoverIdaYVuelta()
    {
        Vector3 posicionOriginal = Jugador.transform.position;

        // Mover a la derecha
        Vector3 posicionDerecha = posicionOriginal + Vector3.right * distanciaMovimiento;
        yield return MoverHacia(posicionDerecha);

        // Mover a la izquierda
        Vector3 posicionIzquierda = posicionOriginal + Vector3.left * distanciaMovimiento;
        yield return MoverHacia(posicionIzquierda);

        // Volver a la posición original
        yield return MoverHacia(posicionOriginal);
    }

    private IEnumerator MoverHacia(Vector3 destino)
    {
        while (Vector3.Distance(Jugador.transform.position, destino) > 0.01f)
        {
            // Mueve al jugador suavemente hacia el destino
            Jugador.transform.position = Vector3.MoveTowards(
                Jugador.transform.position,
                destino,
                velocidadMovimiento * Time.deltaTime
            );

            // Espera hasta el siguiente frame
            yield return null;
        }
    }
    public void MoverEnemic( ) // funcion para mover al enemigo en la escena de lucha 
    {
        if (Enemic1 != null)
        {
            // Inicia la corutina para mover al Enemic
            StartCoroutine(MoverIdaYVueltaEnemic1());
            
        }
        else
        {
            Debug.LogError("El objeto Enemic no está asignado en el script.");
        }
    }
    private IEnumerator MoverIdaYVueltaEnemic1()
    {
        Vector3 posicionOriginal = Enemic1.transform.position;
       
        // Mover a la derecha
        Vector3 posicionDerecha = posicionOriginal + Vector3.right * distanciaMovimiento;
        yield return MoverHacia1(posicionDerecha);

        // Mover a la izquierda
        Vector3 posicionIzquierda = posicionOriginal + Vector3.left * distanciaMovimiento;
        yield return MoverHacia1(posicionIzquierda);

        // Volver a la posición original
        yield return MoverHacia1(posicionOriginal);
    }
    private IEnumerator MoverHacia1(Vector3 destino)
    {
        while (Vector3.Distance(Enemic1.transform.position, destino) > 0.01f)
        {
            // Mueve al jugador suavemente hacia el destino
            Enemic1.transform.position = Vector3.MoveTowards(
                Enemic1.transform.position,
                destino,
                velocidadMovimiento * Time.deltaTime
            );

            // Espera hasta el siguiente frame
            yield return null;
        }
    }
    
    private IEnumerator MoverHacia2(Vector3 destino)
    {
        while (Vector3.Distance(Enemic2.transform.position, destino) > 0.01f)
        {
            // Mueve al jugador suavemente hacia el destino
            Enemic1.transform.position = Vector3.MoveTowards(
                Enemic1.transform.position,
                destino,
                velocidadMovimiento * Time.deltaTime
            );

            // Espera hasta el siguiente frame
            yield return null;
        }
    }

}
