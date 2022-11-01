using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip tap;
    public AudioClip bomba;
    public AudioClip dorada1;
    public AudioClip dorada2;
    public AudioClip dorada3;
    public AudioClip bomba1;
    public AudioClip bomba2;
    public static SFXManager SFXinstancia;
    // Start is called before the first frame update
    private void Awake()
    {
        if(SFXinstancia!=null && SFXinstancia != this)
        {
            Destroy(this.gameObject);
            return;
        }
        SFXinstancia = this;
        DontDestroyOnLoad(this);

    }
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
}
