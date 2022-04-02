using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotsController : MonoBehaviour
{
    public AudioMixerSnapshot normalHealth;
    public AudioMixerSnapshot lowHealth;
    public PlayerHealthController phc;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(phc.currentHealth < 2)
        {
            lowHealth.TransitionTo(.5f);
        } else if(phc.currentHealth == 3)
        {
            normalHealth.TransitionTo(.01f);
        } else
        {
            normalHealth.TransitionTo(.5f);
        }
    }
}
