using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nivel1 : MonoBehaviour
{
    public bool startLevel, clearPart1;
    public GameObject part1, part2,part3, scenarioAttacks,multiLaser,uniLaser;
    public float timer;
    private bool firstTime;
    public VictoryController victoryController;
    //public GameObject laser;
    public DashController dc;
    private AudioManagerController audio;
    public TextMeshProUGUI phaseInfo;
    public Animation textAnim;
    private bool textFlag2, textFlag3, textFlag4;
    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManagerController>();
        startLevel = false;
        clearPart1 = false;
        firstTime = true;
        textFlag2 = true;
        textFlag3 = true;
        textFlag4 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (startLevel == true && firstTime)
        {
            if (textFlag2 == true)
            {
                phaseInfo.text = "Stage 2/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag2 = false;
            }
            dc.canDash = true;
            firstTime = false;
            FindObjectOfType<Tutorial>().tutorialImageAttack.SetActive(false);
            part1.SetActive(true);
            //scenarioAttacks.SetActive(true);
        }

        if (part1.transform.childCount <= 0)
        {
            part2.SetActive(true);
            if (textFlag2 == true)
            {
                phaseInfo.text = "Stage 3/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag2 = false;
            }
        }

        if (part2.transform.childCount <= 0 && clearPart1 == false)
        {
            timer = 8f;
            clearPart1 = true;
            uniLaser.SetActive(false);
            multiLaser.SetActive(true);
            scenarioAttacks.SetActive(true);
            
        }

        if (part2.transform.childCount <= 0 && timer < 0)
        {
            part3.SetActive(true);
            if (textFlag3 == true)
            {
                phaseInfo.text = "Stage 4/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag3 = false;
            }
            //scenarioAttacks.SetActive(true);
            multiLaser.SetActive(false);
            uniLaser.SetActive(true);
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if(part3.transform.childCount <= 0)
        {
            victoryController.victory = true;
        }
    }
}
