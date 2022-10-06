using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timer : MonoBehaviour
{
    public Slider slidetiempo;
    public float tiempojuego;
    public float time;
    


    public bool parartiempo;
    // Start is called before the first frame update
    void Start()
    {
        parartiempo = false;
        slidetiempo.maxValue = tiempojuego;
        slidetiempo.value = tiempojuego;
        time = tiempojuego;
    }

    // Update is called once per frame
    void Update()
    {

        if (FindObjectOfType<GameManager>().juego.activeInHierarchy == true)
        {
            time -= 1 * Time.deltaTime;
        }
            
        
        
        
       

        int minuto = Mathf.FloorToInt(time / 60);
        int segundo = Mathf.FloorToInt(time - minuto * 60f);

       

        
        
            if (time <= 0)
            {
              parartiempo = true;
       
                GameOver();

            }

        
        if (parartiempo == false)
        {
          
            slidetiempo.value = time;
        }
    }

    void GameOver()
    {
        FindObjectOfType<GameManager>().derrota();
    }


}
