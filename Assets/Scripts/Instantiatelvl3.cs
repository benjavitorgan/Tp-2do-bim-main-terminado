﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatelvl3 : MonoBehaviour
{
    public Transform spawner;
    public GameObject objeto;
    GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    void Update ()
    {

    }

    IEnumerator ExampleCoroutine ()
    {
        while (true)
        {
            clone = Instantiate(objeto, spawner.transform.position, spawner.transform.rotation);
            Destroy(clone, 15);
            yield return new WaitForSeconds(2.7f);
            
        }
    }
}
