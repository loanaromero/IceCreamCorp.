using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject juego;
    public GameObject fin;
    public GameObject pausamenu;
    public GameObject laseer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void derrota()
    {
        juego.SetActive(false);
        fin.SetActive(true);
        laseer.transform.LeanMoveLocal(new Vector3(-4, 1.3f, 0), 2);
        DestroyWithTag1("nuevabochita");
        DestroyWithTag2("efeto");
    }
    public void reset()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        FindObjectOfType<timer>().time = 60;
        FindObjectOfType<timer>().parartiempo= false;
        fin.SetActive(false);
        juego.SetActive(true);
        DestroyWithTag("bochitas");
      
        FindObjectOfType<ganerador>().nuevapieza();
      
        
        
    }
    void DestroyWithTag(string bochitas)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag("bochitas");
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
        
      
    }
    void DestroyWithTag1(string nuevabochita)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag("nuevabochita");
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);

        
    }
    void DestroyWithTag2(string efeto)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag("efeto");
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);


    }
    public  void pausa()
    {
        pausamenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("entro");

    }
    public  void reanudar()
    {
        pausamenu.SetActive(false);
            Time.timeScale = 1;
    }

}
