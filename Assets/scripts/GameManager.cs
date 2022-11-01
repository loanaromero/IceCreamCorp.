using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //pantallas
    public GameObject juego;
    public GameObject fin;
    public GameObject pausamenu;
    public GameObject menupcipal;
    public GameObject tienda;
    public GameObject laseer;
    public GameObject config;

    //conos
    public GameObject cono1;
    public GameObject cono2;
    public GameObject cono3;
    public GameObject cono4;
    public GameObject cono5;

    //activar botones
    public GameObject botonselec1;
    public GameObject botonselec2;
    public GameObject botonselec3;
    public GameObject botonselec4;

    //txt
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;
    public GameObject txt4;

    //movimiento botones menu
    public GameObject btnplay;
    public GameObject movilcongif;
    public GameObject moviltienda;
    public GameObject movilfin;

    //mutear musica
    public GameObject musica;
    public GameObject botonON;
    public GameObject botonOFF;

    public bool guille = false;
    public int platatotal = 0;
    bool laputamadre;
    
    // Start is called before the first frame update
    void Start()
    {
        juego.SetActive(true);
        juego.SetActive(false);
        platatotal = PlayerPrefs.GetInt("plata");
        //btnplay.transform.LeanMoveLocal(new Vector3(24, -150, 0), 3).setEaseInOutBack();

        btnplay.transform.LeanScale(new Vector3(0.8f, 0.8f, 0.8f), 1).setEaseLinear().setLoopPingPong();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // platatotal = FindObjectOfType<ShopManagerScript>().coins;
    
    }
    public void volvermenu()
    {
        SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.tap);
        guille = true;
        FindObjectOfType<timer>().time = 60;
        FindObjectOfType<timer>().parartiempo = false;
        DestroyWithTag("bochitas");
        DestroyWithTag3("dorada");
        fin.SetActive(false);
        movilfin.transform.LeanMoveLocal(new Vector3(0, -1500, 0), 1).setEaseOutBack();
        juego.SetActive(false);
        tienda.SetActive(false);
        config.SetActive(false);
        movilcongif.transform.LeanMoveLocal(new Vector3(-414, -2200, -92), 1).setEaseInOutBack();
        moviltienda.transform.LeanMoveLocal(new Vector3(0, -2400, 0), 1).setEaseOutBack();
        pausamenu.SetActive(false);
        platatotal = PlayerPrefs.GetInt("plata");
        Time.timeScale = 1;
        laseer.transform.LeanMoveLocal(new Vector3(-4, 1.3f, 0), 2);
        
        menupcipal.SetActive(true);
    }
    public void tiendaabrir()
    {
        SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.tap);
        //menupcipal.SetActive(false);
        tienda.SetActive(true);
        moviltienda.transform.LeanMoveLocal(new Vector3(0, 0, 0), 1).setEaseOutBack();
        
        
    }
    public void empezar()
    {
        SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.tap);
        FindObjectOfType<timer>().var = false;
        FindObjectOfType<diniero>().plata = 0;
        menupcipal.SetActive(false);
        juego.SetActive(true);
        if (guille == true)
        {
            FindObjectOfType<ganerador>().nuevapieza();
            guille = false;
        }
        
    }

   public void derrota()
    {
        
        FindObjectOfType<diniero>().platafinal();
        platatotal = platatotal + FindObjectOfType<diniero>().plata;
        Debug.Log("saldo " + platatotal); 
        juego.SetActive(false);
        fin.SetActive(true);
        movilfin.transform.LeanMoveLocal(new Vector3(0, 75, 0), 1).setEaseOutBack();
        laseer.transform.LeanMoveLocal(new Vector3(-4, 1.3f, 0), 2);
        DestroyWithTag1("nuevabochita");
        DestroyWithTag2("efeto");
        PlayerPrefs.SetInt("plata", platatotal);
        
    }
    public void reset()
    {
        SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.tap);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<timer>().var = false;
        FindObjectOfType<diniero>().plata = 0;
        FindObjectOfType<timer>().time = 60;
        FindObjectOfType<timer>().parartiempo= false;
        fin.SetActive(false);
        movilfin.transform.LeanMoveLocal(new Vector3(0, -1500, 0), 1).setEaseOutBack();
        juego.SetActive(true);
        DestroyWithTag("bochitas");
        DestroyWithTag3("dorada");
        FindObjectOfType<ganerador>().nuevapieza();
        //laseer.transform.LeanMoveLocal(new Vector3(-4, 1.3f, 0), 0.2f);


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
    void DestroyWithTag3(string dorada)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag("dorada");
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);


    }

    public void configuracion()
    {
        SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.tap);
        config.SetActive(true);
        menupcipal.SetActive(false);
        movilcongif.transform.LeanMoveLocal(new Vector3(-414, -776, -79), 1).setEaseOutBack();
    }


    public  void pausa()
    {
        SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.tap);
        pausamenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("entro");

    }
    public  void reanudar()
    {
        SFXManager.SFXinstancia.Audio.PlayOneShot(SFXManager.SFXinstancia.tap);
        pausamenu.SetActive(false);
            Time.timeScale = 1;
    }

    //conos
    public void Cono1()
    {
        if (platatotal >=0)
        {
            cono1.SetActive(true);
            cono2.SetActive(false);
            cono3.SetActive(false);
            cono4.SetActive(false);
            cono5.SetActive(false);
            

        }
    }

    public void Cono2()
    {
        if (platatotal>=100)
        {
            cono1.SetActive(false);
            cono2.SetActive(true);
            cono3.SetActive(false);
            cono4.SetActive(false);
            cono5.SetActive(false);
            txt1.SetActive(false);
            botonselec1.SetActive(true);

        }
    }
    public void Cono3()
    {
        if (platatotal >= 1700)
        {
            cono1.SetActive(false);
            cono2.SetActive(false);
            cono3.SetActive(true);
            cono4.SetActive(false);
            cono5.SetActive(false);
            txt2.SetActive(false);
            botonselec2.SetActive(true);
        }
    }
    public void Cono4()
    {
        if (platatotal >= 4000)
        {
            cono1.SetActive(false);
            cono2.SetActive(false);
            cono3.SetActive(false);
            cono4.SetActive(true);
            cono5.SetActive(false);
            txt3.SetActive(false);
            botonselec3.SetActive(true);
        }
    }
    public void Cono5()
    {
        if (platatotal >= 10000)
        {
            cono1.SetActive(false);
            cono2.SetActive(false);
            cono3.SetActive(false);
            cono4.SetActive(false);
            cono5.SetActive(true);
            txt4.SetActive(false);
            botonselec4.SetActive(true);
        }
    }
  
  
    public void selecbtn1()
    {
        cono1.SetActive(false);
        cono2.SetActive(true);
        cono3.SetActive(false);
        cono4.SetActive(false);
        cono5.SetActive(false);
    }
    public void selecbtn2()
    {
        cono1.SetActive(false);
        cono2.SetActive(false);
        cono3.SetActive(true);
        cono4.SetActive(false);
        cono5.SetActive(false);
    }
    public void selecbtn3()
    {
        cono1.SetActive(false);
        cono2.SetActive(false);
        cono3.SetActive(false);
        cono4.SetActive(true);
        cono5.SetActive(false);
    }
    public void selecbtn4()
    {
        cono1.SetActive(false);
        cono2.SetActive(false);
        cono3.SetActive(false);
        cono4.SetActive(false);
        cono5.SetActive(true);
    }
    public void mutear()
    {
        musica.SetActive(false);
        botonON.SetActive(false);
        botonOFF.SetActive(true);
    }
    public void desmutear()
    {
        musica.SetActive(true);
        botonON.SetActive(true);
        botonOFF.SetActive(false);
    }

    
}
