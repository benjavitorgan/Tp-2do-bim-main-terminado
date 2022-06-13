﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehaviour : MonoBehaviour
{
    AudioSource source;
    public AudioClip muerte, salto, perdiste;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        //isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Salto()
    {
        source.clip = salto;
        source.Play();
    }

    public void Muerte()
    {
        source.clip = muerte;
        source.Play();
    }

    public void Perdiste()
    {
        source.clip = perdiste;
        source.Play();
    }
}
