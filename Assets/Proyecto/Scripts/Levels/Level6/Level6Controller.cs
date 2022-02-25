using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6Controller : MonoBehaviour
{
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject scenario;
    public GameObject lightsOff;
    public float lightsOffTimer;
    public float lightsOffDuration;
    private float timer;
    private float timer2;
    private int phasecounter;

    // Start is called before the first frame update
    void Start()
    {
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase3.SetActive(false);
        phase4.SetActive(false);
        scenario.SetActive(true);
        timer = lightsOffTimer;
        timer2 = lightsOffDuration;
        phasecounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (phase1.transform.childCount <= 0 && phasecounter == 0)
        {
            phase2.SetActive(true);
            phase1.SetActive(false);
            phasecounter++;
        }

        if (timer <= 0)
        {
            lightsOff.GetComponent<Animator>().SetBool("LightsOff", true);
            if (!lightsOff.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("LightsOffs"))
            {
                if (timer2 <= 0)
                {
                    lightsOff.GetComponent<Animator>().SetBool("LightsOff", false);
                    timer = lightsOffTimer;
                    timer2 = lightsOffDuration;
                }
                else
                {
                    timer2 -= Time.deltaTime;
                }
            }
        } else
        {
            timer -= Time.deltaTime;
        }
    }
}
