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
    private int phasecounter;

    // Start is called before the first frame update
    void Start()
    {
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase3.SetActive(false);
        phase4.SetActive(false);
        scenario.SetActive(true);
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
    }
}
