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
    public GameObject phase21, phase22, phase23, phase24, phase25;
    public GameObject multi2, multi4;
    private GameObject multi2a, multi4a;
    private int phasecounter;
    private bool oneTime;
    private float time = 0.0f, timeaux = 0.0f;
    private bool cambio = true;
    private bool existe = false;
    private bool existe2 = false;
    // Start is called before the first frame update
    void Start()
    {


        // scenario.SetActive(true);
        //phase1.SetActive(true); 
        scenario.SetActive(true);
        phase1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase1.transform.childCount <=0)
        {

            phase2.SetActive(true);
            scenario.SetActive(false);
        }

        if (phase2 && phase21 == null &&phase22 == null && phase23==null && phase24 ==null && phase25==null)
        {

            phase2.SetActive(false);
            phase3.SetActive(true);

            if (!existe)
            {
                multi2a = Instantiate(multi2);
                existe = true;
            }
            if (!existe2)
            {
                multi4a = Instantiate(multi4);
                existe2 = true;
            }


            if (cambio){
      
                multi2a.SetActive(true);
                time += Time.deltaTime;
                if (time >= 5.0f)
                {
                    Destroy(multi2a);
                    existe = false;
                    cambio = false;
                    time = 0.0f;
                }
            }
            if (!cambio)
            {
             
                multi4a.SetActive(true);
                //multi4.SetActive(true);
                time += Time.deltaTime;
                if(time >= 5.0f)
                {

                    Destroy(multi4a);
                    existe2 = false;
                    cambio = true;
                    time = 0.0f;
                }
            }


       
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
