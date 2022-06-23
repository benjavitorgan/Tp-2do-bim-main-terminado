using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSong : MonoBehaviour
{
    AudioSource source;
    public AudioClip gano, suspenso, perdio;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = suspenso;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void win ()
    {
        source.clip = gano;
        source.Play();
    }
}
