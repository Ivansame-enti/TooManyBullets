using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7Controller : MonoBehaviour
{
    public VictoryController victorycontroller;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject scenario;
    public GameObject phase21, phase22, phase23;
    private int phasecounter;
    private bool oneTime;
    // Start is called before the first frame update
    void Start()
    {


       // scenario.SetActive(true);
        phase1.SetActive(true);
        scenario.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase1.transform.childCount <=0)
        {

            phase2.SetActive(true);
            scenario.SetActive(false);
        }

        if (phase2 && phase21 == null &&phase22 == null && phase23==null)
        {
            phase2.SetActive(false);
            phase3.SetActive(true);

       
        }
        if (phase3.transform.childCount <= 1)
        {
            phase4.SetActive(true);
        }

            if (phase4.transform.childCount <= 0)
        {
            //victorycontroller.victory = true;

        }
    }
}
