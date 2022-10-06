using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rayito : MonoBehaviour
{
    public Transform lasercito;
    public Text puntaje;
    public GameObject cosito;
    public float pos;
    public int pos1;
    // Start is called before the first frame update
    void Start()
    {
        
        pos = lasercito.transform.position.y;
         pos1 = (int)pos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.right,out hit, 60f))
        {
            
            if (hit.transform.tag == "bochitas"|| hit.transform.tag=="conito")
            {
                Debug.DrawRay(transform.position, Vector3.right * 10f * Time.deltaTime, Color.red);
                
                altura();
                
                //Debug.Log(puntaje);
               // Invoke("altura", 2);
            }
            else
            {
                baja();
                
            }

        }
        else
        {
            baja();
        }
        pos = lasercito.transform.position.y;
         pos1 = (int)pos;
    }
    public void altura()
    {
        gameObject.transform.Translate(0, 0.05f, 0);
        
    }
    public void baja()
    {
        gameObject.transform.Translate(0, -0.05f , 0);

    }
    
}
