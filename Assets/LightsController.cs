using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour
{
    public float lightsOffTimer;
    public float lightsOffDuration;
    private float timer;
    private float timer2;

    // Start is called before the first frame update
    void Start()
    {
        timer = lightsOffTimer;
        timer2 = lightsOffDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            this.GetComponent<Animator>().SetBool("LightsOff", true);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void LightsOff(string mensaje)
    {
        if (mensaje.Equals("LightsOff"))
        {
            if (timer2 <= 0)
            {
                this.GetComponent<Animator>().SetBool("LightsOff", false);
                timer = lightsOffTimer;
                timer2 = lightsOffDuration;
            }
            else
            {
                timer2 -= Time.deltaTime;
            }
        }
    }
}
