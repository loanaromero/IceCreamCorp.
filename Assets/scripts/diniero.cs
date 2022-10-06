using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diniero : MonoBehaviour
{
    public int plata;
    public bool masdinero;
    public Text puntaje;

    void Update()
    {

        Debug.Log(plata);
        
       // puntaje.text = plata.ToString();
    }

    public void platafinal()
    {
       // plata=plata * 10;
        puntaje.text = plata.ToString();
    }
}
