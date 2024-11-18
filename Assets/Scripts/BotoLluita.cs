using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BotoLluita : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Lluita;
    public GameObject Mochila;
    public GameObject Escapar;
    public TextMeshProUGUI textoOperacion; // Cambia a Text si usas UI est�ndar
    public TextMeshProUGUI resultadoText; // Texto para mostrar si es correcto o incorrecto
    public TMP_InputField respuestaInput; // Campo para ingresar la respuesta

    private int numero1;
    private int numero2;
    private string operacion;
    private int resultadoCorrecto;
    void Start()
    {
        
        resultadoText.text = ""; // Limpia el texto al inicio
        textoOperacion.text = ""; // Vac�a el texto para que no sea visible
    }

    public void OcultarBotones()
    {
        if (Lluita != null)
        {
            Lluita.SetActive(false);// Oculta el bot�n de lucha
            Mochila.SetActive(false);// Oculta el bot�n de Mochila
            Escapar.SetActive(false);// Oculta el bot�n de Escapar 
        }
        
        void GenerarOperacion()
        {
            // Generar n�meros aleatorios y tipo de operaci�n
            numero1 = Random.Range(1, 101); // N�meros entre 1 y 100
            numero2 = Random.Range(1, 101);
            int tipoOperacion = Random.Range(0, 2); // 0 = suma, 1 = resta

            if (tipoOperacion == 0)
            {
                operacion = "+";
                resultadoCorrecto = numero1 + numero2;
            }
            else
            {
                operacion = "-";
                resultadoCorrecto = numero1 - numero2;
            }

            // Muestra la operaci�n en pantalla
            textoOperacion.text = $"�Cu�nto es {numero1} {operacion} {numero2}?";
        }

         void VerificarRespuesta()
        {
            // Verifica si el jugador ingres� la respuesta correcta
            if (string.IsNullOrEmpty(respuestaInput.text))
            {
                resultadoText.text = "Por favor, ingresa una respuesta.";
                return;
            }

            int respuestaJugador;
            if (int.TryParse(respuestaInput.text, out respuestaJugador))
            {
                if (respuestaJugador == resultadoCorrecto)
                {
                    resultadoText.text = "�Correcto!";
                }
                else
                {
                    resultadoText.text = "�Has fallado!";
                }
            }
            else
            {
                resultadoText.text = "Por favor, ingresa un n�mero v�lido.";
            }
        }

    }
}
