using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotoLluita : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Lluita;
    public GameObject Mochila;
    public GameObject Escapar;
    public GameObject Resposta;

    public TextMeshProUGUI textoOperacion;
    public TextMeshProUGUI resultadoText;
    public TMP_InputField respuestaInput;
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
    public Scriptlluita1 scriptlluita1;

    private int siguentePantalla;

    // Variable para almacenar el tag del enemigo
    private string enemigoTag;

    // corazones
    public List<Image> corazonesJugador;
    public List<GameObject> vidasJugador;
    public List<Image> corazonesEnemigo;
    public bool jugadorRecibeDaño = false;
    void Start()
    {
        resultadoText.gameObject.SetActive(false);
        textoOperacion.gameObject.SetActive(false);
        Resposta.SetActive(false);
        respuestaInput.gameObject.SetActive(false);
        VidasEnemic.text = "";
        VidasJugador.text = "";
        vidasJuga = 3;
        vidasEnemi = 1;
        Temporizador.text = "";
        scriptlluita1 = GetComponent<Scriptlluita1>();
        //siguentePantalla = SceneManager.GetActiveScene().buildIndex + 1;

        // Recuperar el tag del enemigo desde PlayerPrefs, si no existe asignamos un valor vacío
        string enemigoTag = PlayerPrefs.GetString("EnemigoTag");

        if (string.IsNullOrEmpty(enemigoTag))  // Comprobamos si el tag es nulo o vacío
        {
         //   Debug.LogError("El tag del enemigo no está definido correctamente.");
        }
    }

    // Funci�n para almacenar el tag del enemigo cuando el jugador lo detecta
    public void ColisionarConEnemigo(string tagEnemigo)
    {
        enemigoTag = tagEnemigo;  // Guardamos el tag del enemigo
        PlayerPrefs.SetString("EnemigoTag", tagEnemigo);  // Guardamos el tag en PlayerPrefs
    }

    public void OcultarBotones()
    {
        if (Lluita != null)
        {
            
            Mochila.SetActive(false);
            Escapar.SetActive(false);
            Resposta.SetActive(true);
            respuestaInput.gameObject.SetActive(true);
            textoOperacion.gameObject.SetActive(true);
            resultadoText.gameObject.SetActive(true);
            VidasEnemic.text = $"vidas x {vidasEnemi}";
            VidasJugador.text = $"vidas x {vidasJuga}";
            IniciarTemporizador();

            if (temporizadorEnMarcha)
            {
                ActualizarTemporizador();
            }
        }

        // Genera y muestra una operacion matematica
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
            
            TemporizadorFinalizado();
            
        }

        ActualizarTextoTemporador();
    }

    void ActualizarTextoTemporador()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        Temporizador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void Update()
    {
        if(jugadorRecibeDaño){
          
            ActualizarVidasJugador();
        }
        if (temporizadorEnMarcha)
        {
            ActualizarTemporizador();
            
        }
    }

    void TemporizadorFinalizado()
    {
        IniciarTemporizador();
        vidasJuga -= 1;
        VidasJugador.text = $"vidas x {vidasJuga}";
        if (vidasJuga == 0)
        {
            SceneManager.LoadScene("ScenaMuerte");
        }
    }

    private void GenerarOperacion()
    {
        numero1 = Random.Range(10, 40);
        numero2 = Random.Range(10, 40);
        int tipoOperacion = Random.Range(0, 2);

        if (tipoOperacion == 0)
        {
            operacion = "+";
            resultadoCorrecto = numero1 + numero2;
        }
        else
        {
            operacion = "-";
            if (numero2 > numero1)
            {
                int numAux = numero1;
                numero1 = numero2;
                numero2 = numAux;
            }
            resultadoCorrecto = numero1 - numero2;
        }

        textoOperacion.text = $"Quant és {numero1} {operacion} {numero2}?";
        textoOperacion.gameObject.SetActive(true);
    }

    public void VerificarRespuesta()
    {
        if (string.IsNullOrEmpty(respuestaInput.text))
        {
            resultadoText.text = "Introdueix una resposta";
            return;
        }

        int respuestaJugador;
        if (int.TryParse(respuestaInput.text, out respuestaJugador))
        {
            if (respuestaJugador == resultadoCorrecto)
            {
                resultadoText.text = "CORRECTE!";
                vidasEnemi -= 1;
                VidasEnemic.text = $"vidas x {vidasEnemi}";
                ActualizarCorazones(corazonesEnemigo, vidasEnemi);
                GenerarOperacion();
                IniciarTemporizador();
                scriptlluita1.MoverEnemic();
            }
            else
            {
                
                resultadoText.text = "HAS FALLAT!";
                vidasJuga -= 1;
                jugadorRecibeDaño = true;               
                VidasJugador.text = $"vidas x {vidasJuga}";     
                GenerarOperacion();
                IniciarTemporizador();
                scriptlluita1.MoverJugador();
            }
        }
        else
        {
            resultadoText.text = "Introdueix un número";
        }
        if (vidasJuga == 0)
        {
            SceneManager.LoadScene("ScenaMuerte");
        }
        else if (vidasEnemi == 0)
        {
            int escenaAnterior = PlayerPrefs.GetInt("EscenaActual");
            SceneManager.LoadScene(escenaAnterior + 1);
        }
    }

    // corazones Actualizar corazones
    private void ActualizarCorazones(List<Image> corazones, int vidasRestantes)
    {
        for (int i = 0; i < corazones.Count; i++)
        {
            corazones[i].enabled = false /* i < vidasRestantes*/;
        }
    }

    private void ActualizarVidasJugador(){
        for(int i =0; i < vidasJugador.Count; i++){
            if(i < vidasJuga){
            vidasJugador[i].SetActive(false);
            } 
        }
        jugadorRecibeDaño = false;
        Debug.LogError("El tag del enemigo no está definido correctamente.");
    }
}
