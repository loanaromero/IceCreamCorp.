using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class bolitas : MonoBehaviour
{
    public float r;
    public Vector3 cambiar = Vector3.right;
    
    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(170, 500);
       
        gameObject.tag = "nuevabochita";
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up *500);
        if (FindObjectOfType<ganerador>().cambio()==true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * r);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * r);
        }
       
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.CompareTag("nuevabochita"))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 700);
                gameObject.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
            }
        }
    }
  
    
    
    private bool collisonOccured = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collisonOccured)
            return;
        if (collision.gameObject.CompareTag("conito") ||  collision.gameObject.CompareTag("bochitas"))
        {

          
            gameObject.tag = "bochitas";
            /*gameObject.AddComponent<HingeJoint>();
            gameObject.GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
            gameObject.GetComponent<HingeJoint>().connectedArticulationBody = collision.articulationBody;*/
            FindObjectOfType<ganerador>().cambio();
            transform.SetParent(collision.gameObject.transform, true);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
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
