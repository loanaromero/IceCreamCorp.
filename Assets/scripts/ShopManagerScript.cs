using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public int coins;
    public Text CoinsTXT;
    public bool activar1=false;
  


    void Start()
    {
        coins = FindObjectOfType<GameManager>().platatotal;
        CoinsTXT.text =coins.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 1700;
        shopItems[2, 3] = 4000;
        shopItems[2, 4] = 10000;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

     
       
    }

    public void FixedUpdate()
    {
        coins = FindObjectOfType<GameManager>().platatotal;
        CoinsTXT.text =coins.ToString();
      
    }
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        
        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID] )
        {
            FindObjectOfType<GameManager>().platatotal -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
           // shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]= shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]+1;
           
            CoinsTXT.text = "platita: " + coins.ToString();
            // ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
         
        }


    }
}
