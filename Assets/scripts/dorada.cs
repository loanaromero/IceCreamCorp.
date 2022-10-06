using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class dorada : MonoBehaviour
{

    public float r;
    public Vector3 cambiar = Vector3.right;
    public GameObject efeto;
    public ContactPoint contato;
    public Quaternion rot;
    public Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {

        r = Random.Range(500, 800);

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

    // Update is called once per frame
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



    private bool collisonOccured = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collisonOccured)
            return;
        if (collision.gameObject.CompareTag("conito") || collision.gameObject.CompareTag("bochitas") || collision.gameObject.CompareTag("dorada"))
        {


            contato = collision.contacts[0];
            rot = Quaternion.FromToRotation(Vector3.up, contato.normal);
            pos = contato.point;
            Instantiate(efeto, pos, rot);


            gameObject.tag = "dorada";
            gameObject.AddComponent<HingeJoint>();
            gameObject.GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
            if (FindObjectOfType<timer>().time > 50)
            {
                gameObject.GetComponent<HingeJoint>().breakForce = 2000;

            }
            else
            {
                gameObject.GetComponent<HingeJoint>().breakForce = 1000;

            }
            gameObject.GetComponent<HingeJoint>().useLimits = true;
            FindObjectOfType<ganerador>().cambio();
            FindObjectOfType<diniero>().plata += 50;

            FindObjectOfType<ganerador>().nuevapieza();
            collisonOccured = true;

        }

        if (collision.gameObject.CompareTag("pisito"))
        {
            Destroy(this.gameObject);
            FindObjectOfType<ganerador>().nuevapieza();

        }



    }


}
