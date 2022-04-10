using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject enemigo31, enemigo32, enemigo33, enemigo34, enemigo35, enemigo36;
    public GameObject enemigo41, enemigo42, enemigo43, enemigo44, enemigo45, enemigo46;
    private int phasecounter;
    private bool oneTime;
    private float time = 0.0f, timeaux = 0.0f;
    private bool cambio = true;
    private bool existe = false;
    private bool existe2 = false;
    private AudioManagerController audio;
    public TextMeshProUGUI phaseInfo;
    public Animation textAnim;
    private bool textFlag2, textFlag3, textFlag4;
    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManagerController>();
        phaseInfo.text = "Phase 1/4";
        textAnim.Play("phaseInfo");
        textFlag2 = true;
        textFlag3 = true;
        textFlag4 = true;
        scenario.SetActive(true);
       phase1.SetActive(true); 
       // scenario.SetActive(false);
    //    phase4.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase1.transform.childCount <=0)
        {

            phase2.SetActive(true);
            if (textFlag2 == true)
            {
                phaseInfo.text = "Phase 2/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag2 = false;
            }
            scenario.SetActive(false);
        }

        if (phase2 && phase21 == null &&phase22 == null && phase23==null && phase24 ==null && phase25==null)
        {

            phase2.SetActive(false);
            phase3.SetActive(true);
            if (textFlag3 == true)
            {
                phaseInfo.text = "Phase 3/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag3 = false;
            }

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
        if (phase3 && enemigo31 == null && enemigo32 == null && enemigo33 == null && enemigo34 == null && enemigo35 == null && enemigo36==null)
        {
            phase3.SetActive(false);
            multi2a.SetActive(false);
            multi4a.SetActive(false);
            phase4.SetActive(true);
            if (textFlag4 == true)
            {
                phaseInfo.text = "Phase 4/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag4 = false;
            }
            scenario.SetActive(false);
        }


            if (phase4 && enemigo41 == null && enemigo42 == null && enemigo43 == null && enemigo44 == null && enemigo45 == null && enemigo46 == null)
        {
            victorycontroller.victory = true;

        }
    }
}
