using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class VisivlitatOperacions : MonoBehaviour
{
    public TextMeshProUGUI textoOperacion;
   
  
    public void MostrarTexto()
    {
        if (textoOperacion != null)
        {
            // Activa el texto si está desactivado
            textoOperacion.gameObject.SetActive(true);
        }
    }

}



