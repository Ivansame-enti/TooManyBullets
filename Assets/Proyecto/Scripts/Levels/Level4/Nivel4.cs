using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nivel4 : MonoBehaviour
{
    public bool startLevel;
    public VictoryController victorycontroller;
    public GameObject scenarioAttacks, scenarioattack1, tutorialUI,tutorialEnemies;
    public GameObject part1, part2, part3, part4, player, shilds;
    public GameObject plantTutorial, plantXbox, plantPS4, plantKeyboard;
    private bool textFlag2, textFlag3, textFlag4;
    private AudioManagerController audio;
    public TextMeshProUGUI phaseInfo;
    public Animation textAnim;

    // Start is called before the first frame update
    void Start()
    {
        startLevel = false;
        audio = FindObjectOfType<AudioManagerController>();
        phaseInfo.text = "Stage 1/4";
        textAnim.Play("phaseInfo");
        textFlag2 = true;
        textFlag3 = true;
        textFlag4 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerInput.Xbox_One_Controller == true)
        {
            plantXbox.SetActive(true);
            plantPS4.SetActive(false);
            plantKeyboard.SetActive(false);
        }
        else if (ControllerInput.PS4_Controller == true)
        {
            plantXbox.SetActive(false);
            plantPS4.SetActive(true);
            plantKeyboard.SetActive(false);
        }
        else if (ControllerInput.Xbox_One_Controller == false && ControllerInput.PS4_Controller == false)
        {
            plantXbox.SetActive(false);
            plantPS4.SetActive(false);
            plantKeyboard.SetActive(true);
        }
        if (part1.transform.childCount <= 0 && tutorialEnemies.transform.childCount <= 0)
        {
            tutorialUI.SetActive(false);
            part2.SetActive(true);
            if (textFlag2 == true)
            {
                phaseInfo.text = "Stage 2/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag2 = false;
            }
            shilds.SetActive(true);
            plantTutorial.SetActive(false);
        }

        if (part2.transform.childCount <= 0)
        {
            part3.SetActive(true);
            if (textFlag3 == true)
            {
                phaseInfo.text = "Stage 3/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag3 = false;
            }
            shilds.SetActive(false);
            scenarioattack1.SetActive(false);
        }
        if (part3.transform.childCount <= 0)
        {
            part4.SetActive(true);
            if (textFlag4 == true)
            {
                phaseInfo.text = "Stage 4/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag4 = false;
            }
            // scenarioattack1.SetActive(true);
        }

        if (part4.transform.childCount <= 0)
        {
            victorycontroller.victory = true;

        }
    }
}
