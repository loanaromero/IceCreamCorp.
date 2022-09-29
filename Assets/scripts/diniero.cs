using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diniero : MonoBehaviour
{
    public int plata=0;
    public bool masdinero;
    public Text puntaje;

    void Update()
    {
       
       
        if (FindObjectOfType<timer>().parartiempo==true)
        {
            plata=plata * 10;
        }
        puntaje.text = plata.ToString();
    }
}
