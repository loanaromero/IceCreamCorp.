using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    public GameObject bombita;
    public float poder=5.0f;
    public float radio = 5.0f;
    public float arribafuerza = 1.0f;

    public float r;
    public Vector3 cambiar = Vector3.right;


    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(170, 500);

        gameObject.tag = "nuevabochita";
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
        if (FindObjectOfType<ganerador>().cambio() == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * r);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * r);
        }


    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.CompareTag("nuevabochita"))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 1000);
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }


    }

 
    public void OnCollisionEnter(Collision collision)
    {
        detonar();
       
       
    }
    void detonar()
    {
        Vector3 explosionposicion = bombita.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionposicion, radio);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb!=null)
            {
                rb.AddExplosionForce(poder, explosionposicion, radio, arribafuerza, ForceMode.Impulse);
            }
            

        }

        Destroy(gameObject);
        FindObjectOfType<ganerador>().nuevapieza();
    }
}
