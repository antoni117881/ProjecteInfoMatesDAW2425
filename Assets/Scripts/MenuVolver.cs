using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuVolver : MonoBehaviour
{
    public void VolverAlMenu(){
        SceneManager.LoadScene("ScenaMenu");
    }
}
