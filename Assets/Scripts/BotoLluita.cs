using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;


public class BotoLluita : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Lluita;
    public GameObject Mochila;
    public GameObject Escapar;
    public GameObject Resposta;
    public TextMeshProUGUI textoOperacion; // Texto para mostrar la operación
    public TextMeshProUGUI resultadoText; // Texto para mostrar si es correcto o incorrecto
    public TMP_InputField respuestaInput; // Campo para ingresar la respuesta
    public TextMeshProUGUI VidasEnemic;
    public TextMeshProUGUI VidasJugador;
    public TextMeshProUGUI Temporizador;
    private int numero1;
    private int numero2;
    private string operacion;
    private int resultadoCorrecto;
    public int vidasJuga;
    public int vidasEnemi;
    public float tiempoInicial = 5f;
    public float tiempoRestante;
    private bool temporizadorEnMarcha = false;


    void Start()
    {

        resultadoText.gameObject.SetActive(false) ; // hace ivisible el texto 
        textoOperacion.gameObject.SetActive(false); // HACE INVISIBLEEL TEXTO
        Resposta.SetActive(false);
        respuestaInput.gameObject.SetActive(false);
        VidasEnemic.text = "";
        VidasJugador.text = "";
        vidasJuga = 3 ;
        vidasEnemi = 3;
        Temporizador.text = "";
}   

    public void OcultarBotones()
    {
        if (Lluita != null)
        {
            Lluita.SetActive(false); // Oculta el botón de lucha
            Mochila.SetActive(false); // Oculta el botón de Mochila
            Escapar.SetActive(false); // Oculta el botón de Escapar
            Resposta.SetActive(true); // hacer que se vea bton de respuesta 
            respuestaInput.gameObject.SetActive(true); // hacer que se vea el recuadr pra a respuesta 
            textoOperacion.gameObject.SetActive(true); 
            resultadoText.gameObject.SetActive(true);
            VidasEnemic.text=$"vidas x {vidasEnemi}";
            VidasJugador.text=$"vidas x {vidasJuga}";
            IniciarTemporizador();

            if (temporizadorEnMarcha)
            {
                ActualizarTemporizador();
            }
        }

        // Genera y muestra una operación matemática
        GenerarOperacion();
    }
    public void IniciarTemporizador()
    {
        tiempoRestante = tiempoInicial;
        temporizadorEnMarcha = true;
    }

    void ActualizarTemporizador()
    {
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            temporizadorEnMarcha = false;
            TemporizadorFinalizado(); // Llamada al evento al finalizar
        }

        // Actualizar el texto en pantalla
        ActualizarTextoTemporizador();
    }

void ActualizarTextoTemporizador()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60); // Calcula los minutos
        int segundos = Mathf.FloorToInt(tiempoRestante % 60); // Calcula los segundos
        Temporizador.text = string.Format("{0:00}:{1:00}", minutos, segundos); // Formato MM:SS
    }
    void Update()
    {
        if (temporizadorEnMarcha)
        {
            ActualizarTemporizador();
        }
    }

    void TemporizadorFinalizado()
    {
        //  Debug.Log("¡Se te ha acabo el tiempo ");
        // Aquí puedes añadir lo que pasa al finalizar el temporizador.
    }


private void GenerarOperacion()
    {
        // Generar números aleatorios y tipo de operación
        numero1 = Random.Range(1, 10); // Números entre 1 y 100
        numero2 = Random.Range(1, 10);
        int tipoOperacion = Random.Range(0, 2); // 0 = suma, 1 = resta

        if (tipoOperacion == 0)
        {
            operacion = "+";
            resultadoCorrecto = numero1 + numero2;
        }
        else{
            operacion = "-";
            if (numero2 > numero1)
            {
                int numAux = numero1;
                numero1 = numero2;
                numero2 = numAux;
            }
          //  Debug.Log("tipoOperacion " + tipoOperacion + "numero1=" + numero1 + " - numero2=" + numero2);
            resultadoCorrecto = numero1 - numero2;
        }
        
        
    

        // Muestra la operación en pantalla
        textoOperacion.text = $"¿Cuánto es {numero1} {operacion} {numero2} ?";
        textoOperacion.gameObject.SetActive(true); // hace   que el texto sea visible
    }

    public void VerificarRespuesta()
    {
        // Verifica si el jugador ingresó la respuesta correcta
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
                resultadoText.text = "¡Correcto!";
                vidasEnemi = vidasEnemi - 1; 
                VidasEnemic.text = $"vidas x {vidasEnemi}";
                GenerarOperacion();
                IniciarTemporizador();
            }
            else
            {
                resultadoText.text = "¡Has fallado!";
                vidasJuga = vidasJuga - 1;
                VidasJugador.text = $"vidas x {vidasJuga}";
                GenerarOperacion();
                IniciarTemporizador();
            }
        }
        else
        {
            resultadoText.text = "Por favor, ingresa un número válido.";
        }
    }
}

