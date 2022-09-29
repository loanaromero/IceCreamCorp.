using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganerador : MonoBehaviour
{
    public GameObject[] piezas;
    public Vector3 pos1;
    public float y; 

    // Start is called before the first frame update
    void Start()
    {
        nuevapieza();
        cambio();
       
        pos1 = new Vector3(5.32f, y, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        y = FindObjectOfType<rayito>().cosito.transform.position.y + 2;
         pos1 = new Vector3(5.32f, y, 0);
        cambio();
        
    }
    public void nuevapieza()
    {
       
        Instantiate(piezas[Random.Range(0, piezas.Length)], transform.position, Quaternion.identity);

        

    }
    public bool cambio()
    {
        if (gameObject.transform.position==pos1)
        {
            gameObject.transform.position = new Vector3(-5.32f, y, 0);
            return true;
        }
        else
        {
            
            gameObject.transform.position = new Vector3(5.32f, y, 0);
            return false;
        }
        
      
    }
   
}
