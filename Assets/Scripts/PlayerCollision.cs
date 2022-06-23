using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    //Audio

    public SoundBehaviour myAM;
    public BackSong myBS;

    //Colisiones tiempo y vida

    int Timecounter;
    float timeToChange, spawnx, spawny, spawnz;
    public Button restart;
    public int counter;
    public Text vidas, GO, Ganaste, nivel, txtCountdown, txtboton;
    public GameObject InicialBase, checkpoint, camara, confeti, spawnerr;
    bool isCounting = true;
    // Start is called before the first frame update
    void Start()
    {
        // Colisiones y vida

        Timecounter = 100;
        counter = 3;
        GO.text = "";
        spawnx = InicialBase.transform.position.x;
        spawny = 1;
        spawnz = InicialBase.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Colisiones 
        if (isCounting)
        {
            if (timeToChange < Time.timeSinceLevelLoad)
            {
                if (Timecounter > 0)
                {
                    Timecounter--;
                    txtCountdown.text = "Tiempo: " + Timecounter.ToString();
                    timeToChange++;
                }
                else
                {
                    counter = 0;
                    Timecounter = 0;
                }
            }
        }

        if (transform.position.y < 0.1f)
        {
            transform.position = new Vector3(spawnx, spawny, spawnz);
            counter--;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        vidas.text = "Vidas: " + counter.ToString();


        if (counter > 0)
        {
            if (col.gameObject.name == "Checkpoint")
            {
                spawnx = checkpoint.transform.position.x;
                spawny = checkpoint.transform.position.y + 0.2f;
                spawnz = checkpoint.transform.position.z;
            }

            if (col.gameObject.name == "Meta")
            {
                myBS.win();
                Ganaste.text = "¡GANASTE!";
                camara.SetActive(true);
                //Time.timeScale = 0;
                isCounting = false;

                for (int i = 0; i < 75; i++)
                {
                    GameObject confeticlon;
                    confeticlon = Instantiate(confeti, spawnerr.transform.position + new Vector3 (1,0,0), spawnerr.transform.rotation);
                    Destroy(confeticlon, 4);
                    Debug.Log(i);
                }
            }


            if (col.gameObject.tag == "Killer")
            {
                myAM.Muerte();
                transform.position = new Vector3(spawnx, spawny, spawnz);
                counter--;
                
            }

        } else
        {
            myAM.Perdiste();
            gameObject.SetActive(false);
            GO.text = "¡Game Over!";
            camara.SetActive(true);
            //Time.timeScale = 0;
            isCounting = false;
        }
        
    }

    public void reiniciar()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
