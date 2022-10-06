using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diniero : MonoBehaviour
{
    public int plata;
    //public int platatotal=0;
    public bool masdinero;
    public Text puntaje;

    void Update()
    {

        
        
       // puntaje.text = plata.ToString();
    }

    public void platafinal()
    {
        // plata=plata * 10;
        //platatotal = platatotal + plata;
        puntaje.text = plata.ToString();
       // Debug.Log("final "+ platatotal);
    }
}
