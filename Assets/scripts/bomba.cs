using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    public GameObject bombita;
    public float poder=5.0f;
    public float radio = 5.0f;
    public float arribafuerza = 1.0f;


    public GameObject efeto;
    public ContactPoint contato;
    public Quaternion rot;
    public Vector3 pos;

    public float r;
    public Vector3 cambiar = Vector3.right;


    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(170, 500);
        int f = Random.Range(1, 2);
        if (f == 1)
        {
            SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.bomba1);
        }
        else 
        {
            SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.bomba2);
        }
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
        if (collision.gameObject.CompareTag("bochitas")||collision.gameObject.CompareTag("conito")|| collision.gameObject.CompareTag("dorada"))
        {

            detonar();
            if (!collision.gameObject.CompareTag("conito"))
            {
                contato = collision.contacts[0];
                rot = Quaternion.FromToRotation(Vector3.up, contato.normal);
                pos = contato.point;
                Instantiate(efeto, pos, rot);
                Handheld.Vibrate();
                Destroy(collision.gameObject);
            }
            
        }
        else
        {
            Destroy(gameObject);
            FindObjectOfType<ganerador>().nuevapieza();
        }
        
       
       
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
                SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.bomba);
            }
            

        }

        Destroy(gameObject);
        FindObjectOfType<ganerador>().nuevapieza();
    }
}
