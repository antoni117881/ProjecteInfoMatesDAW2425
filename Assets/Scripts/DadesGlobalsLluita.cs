using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DadesGlobalsLluita
{
    public static Vector2 posicionJugador; // Guarda la posición del jugador
    public static Vector2 posicionEnemigo; // guardar la posicion del enemigo 
    private static GameObject EnemigoActual;


    public static void  setEnemigoActual(GameObject enemigo)
    {
        EnemigoActual = enemigo;
        Debug.Log(enemigo.name);
    }

    public static void setposicioEnemigo(Vector2 posEnemigo)
    {
        posicionEnemigo = posEnemigo;
        Debug.Log(posEnemigo);
    }
    public static void setposicioJugadr(Vector2 posJugador)
    {
        posicionJugador = posJugador;
        Debug.Log(posJugador);
    }
}

