using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walllvl4 : MonoBehaviour
{
    public GameObject escalon, player;
    float yOffset, zOffset;
    int i;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "NewPlayer")
        {
            while (i == 0)
            {
                yOffset += 0.15f;
                zOffset += 1f;
                Instantiate(escalon).transform.position += new Vector3(0, yOffset, zOffset);
                //Destroy(gameObject, 0.3f);
                i++;
            }
        }

    }
}
