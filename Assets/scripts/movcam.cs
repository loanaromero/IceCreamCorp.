using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movcam : MonoBehaviour
{
    public Transform destino;
    public GameObject juego;
    public Transform camara;
  

    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // int y = FindObjectOfType<rayito>().pos1 + 7;
        /*float y = FindObjectOfType<rayito>().pos + 3;
        Camera.main.transform.LeanMoveLocal(new Vector3(0, y, -20), 1f);
        */
        if (FindObjectOfType<rayito>().pos>10)
        {
            if (Camera.main.orthographicSize <= 16)
            {
                Camera.main.orthographicSize += 0.05f;
                int x = 20;
                Camera.main.transform.rotation = Quaternion.Euler(x, 0, 0);
                Camera.main.transform.LeanMoveLocal(new Vector3(0, 24, -20),2);


            }
            

        }
       /* else
        {
            if (Camera.main.orthographicSize <=9)
            {
                Camera.main.orthographicSize += 0.5f;
                int x = 10;
                Camera.main.transform.rotation = Quaternion.Euler(x, 0, 0);
                Camera.main.transform.LeanMoveLocal(new Vector3(0, 10, -3), 2);


            }
        }*/
       if(FindObjectOfType<rayito>().pos < 10)
        {
            if (Camera.main.orthographicSize >= 9.95)
            {
                Camera.main.orthographicSize -= 0.05f;
                int x = 10;
                Camera.main.transform.rotation = Quaternion.Euler(x, 0, 0);
                Camera.main.transform.LeanMoveLocal(new Vector3(0, 10, -3), 0.5f);


            }
            
        }

        if (FindObjectOfType<rayito>().pos >= 20 /*&& FindObjectOfType<rayito>().pos <= 29*/)
        {
            
            int y = FindObjectOfType<rayito>().pos1+7;
            Camera.main.transform.LeanMoveLocal(new Vector3(0, y, -20), 1f);
          
           
           
        }



    } 

   
}
