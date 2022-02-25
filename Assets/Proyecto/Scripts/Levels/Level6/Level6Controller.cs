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
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase3.SetActive(false);
        phase4.SetActive(false);
        scenario.SetActive(false);
        timer = lightsOffTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {

        } else
        {
            timer -= Time.deltaTime;
        }
    }
}
