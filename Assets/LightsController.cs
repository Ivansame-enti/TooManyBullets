using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour
{
    public float lightsOffTimer;
    public float lightsOffDuration;
    public float timer;
    public float timer2;
    private bool animFinished;
    private bool animFinished2;
    private bool lightOn = true;
    public GameObject playerLight;

    // Start is called before the first frame update
    void Start()
    {
        timer = lightsOffTimer;
        timer2 = lightsOffDuration;
        animFinished = true;
        animFinished2 = true;
        //animFinished2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(animFinished);
        if (animFinished2)
        {
            if (timer <= 0)
            {
                timer = lightsOffTimer;
                animFinished = false;
                playerLight.SetActive(true);
                this.GetComponent<Animator>().SetBool("LightsOff", true);
                playerLight.GetComponent<Animator>().SetBool("LightsOff", true);
                //Debug.Log("S");
                lightOn = false;
            }
            else
            {
                if (lightOn) timer -= Time.deltaTime;
            }
        }

        if (animFinished)
        {
            if (timer2 <= 0)
            {
                //Debug.Log("SA");
                this.GetComponent<Animator>().SetBool("LightsOff", false);
                playerLight.GetComponent<Animator>().SetBool("LightsOff", false);
                animFinished2 = false;
                timer2 = lightsOffDuration;
                lightOn = true;
            }
            else
            {
                if (!lightOn) timer2 -= Time.deltaTime;
            }
        }

    }
    /*
    if (timer <= 0)
    {
        if (animFinished)
        {
            if (timer2 <= 0)
            {
                this.GetComponent<Animator>().SetBool("LightsOff", false);
                timer = lightsOffTimer;
                timer2 = lightsOffDuration;
                animFinished = false;
                Debug.Log("Ey");
                firstTime = true;
            }
            else
            {
                timer2 -= Time.deltaTime;
            }
        } else
        {
            if (animFinished2)
            {
                this.GetComponent<Animator>().SetBool("LightsOff", true);
            }
        }
    }
    else
    {
        timer -= Time.deltaTime;
    }*/

    public void LightsOff(string mensaje)
    {
        if (mensaje.Equals("LightsOff"))
        {
            animFinished = true;
        }
    }

    public void LightsOn(string mensaje)
    {
        if (mensaje.Equals("LightsOn"))
        {
            animFinished2 = true;
            playerLight.SetActive(false);
        }
    }
}
