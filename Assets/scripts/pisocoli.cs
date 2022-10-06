using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisocoli : MonoBehaviour
{
    private bool collisonOccured = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collisonOccured)
            return;
        if (collision.gameObject.CompareTag("bochitas"))
        {
            FindObjectOfType<diniero>().plata-=10;
            
            Destroy(collision.gameObject);
            


        }
        if (collision.gameObject.CompareTag("dorada"))
        {
            FindObjectOfType<diniero>().plata -= 50;

            Destroy(collision.gameObject);



        }

    }
}
