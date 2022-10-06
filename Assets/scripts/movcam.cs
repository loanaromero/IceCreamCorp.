using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movcam : MonoBehaviour
{
    public Transform destino;
    public GameObject juego;
    
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (FindObjectOfType<rayito>().pos>=10)
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
       if(FindObjectOfType<rayito>().pos <= 10)
        {
            if (Camera.main.orthographicSize >= 10)
            {
                Camera.main.orthographicSize -= 0.05f;
                int x = 10;
                Camera.main.transform.rotation = Quaternion.Euler(x, 0, 0);
                Camera.main.transform.LeanMoveLocal(new Vector3(0, 10, -3), 0.5f);


            }
        }

        if (FindObjectOfType<rayito>().pos >= 20)
        {
            Camera.main.transform.LeanMoveLocal(new Vector3(0, 40, -20), 2);
           /* if (Camera.main.orthographicSize <= 16)
            {
                Camera.main.orthographicSize += 0.05f;
                int x = 20;
                Camera.main.transform.rotation = Quaternion.Euler(x, 0, 0);
              


            }*/
        }
    } 

    public void Menu()
    {
        Camera.main.transform.LeanMoveLocal(new Vector3(destino.position.x, destino.position.y,-28.4f), 5).setEaseOutQuart();
        juego.SetActive(false);
        //Camera.main.transform.position = new Vector2(destino.position.x,destino.position.y);
    }
}
