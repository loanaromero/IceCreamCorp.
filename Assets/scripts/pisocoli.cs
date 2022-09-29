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
            FindObjectOfType<diniero>().plata-=1;
            
            Destroy(collision.gameObject);
            


        }

    }
}
