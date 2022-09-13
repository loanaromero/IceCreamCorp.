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
    void Update()
    {

    } 

    public void Menu()
    {
        Camera.main.transform.LeanMoveLocal(new Vector3(destino.position.x, destino.position.y,-28.4f), 5).setEaseOutQuart();
        juego.SetActive(false);
        //Camera.main.transform.position = new Vector2(destino.position.x,destino.position.y);
    }
}
