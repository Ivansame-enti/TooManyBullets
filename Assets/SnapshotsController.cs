using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotsController : MonoBehaviour
{
    public AudioMixerSnapshot normalHealth;
    public AudioMixerSnapshot lowHealth;
    public PlayerHealthController phc;
    public PauseController pc;
    public AudioMixerSnapshot pause;
    private bool bLow, bPause;
    // Start is called before the first frame update
    void Start()
    {
        bLow = false;
        bPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.pauseState)
        {
            if (phc.currentHealth < 2 && !bLow)
            {
                lowHealth.TransitionTo(.5f);
                bLow = true;
            }
            else if (phc.currentHealth == 3 && bLow)
            {
                normalHealth.TransitionTo(.01f);
                bLow = false;
            }
            else if (phc.currentHealth >= 2 && bLow)
            {
                normalHealth.TransitionTo(.5f);
                bLow = false;
            }
        }

        if (pc.pauseState && !bPause)
        {
            pause.TransitionTo(0f);
            bPause = true;
        } else if(!pc.pauseState && bPause)
        {
            if(bLow) lowHealth.TransitionTo(.01f);
            else normalHealth.TransitionTo(.01f);
            bPause = false;
        }
    }
}
