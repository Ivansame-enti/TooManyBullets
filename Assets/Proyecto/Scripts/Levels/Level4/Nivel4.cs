using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel4 : MonoBehaviour
{
    public bool startLevel;
    public VictoryController victorycontroller;
    public GameObject scenarioAttacks, scenarioattack1, tutorialUI,tutorialEnemies;
    public GameObject part1, part2, part3, part4, player, shilds;
    public GameObject plantTutorial, plantXbox, plantPS4, plantKeyboard;

    // Start is called before the first frame update
    void Start()
    {
        startLevel = false;
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
            shilds.SetActive(true);
            plantTutorial.SetActive(false);
        }

        if (part2.transform.childCount <= 0)
        {
            part3.SetActive(true);
            shilds.SetActive(false);
            scenarioattack1.SetActive(false);
        }
        if (part3.transform.childCount <= 0)
        {
            part4.SetActive(true);
            scenarioattack1.SetActive(true);
        }

        if (part4.transform.childCount <= 0)
        {
            victorycontroller.victory = true;

        }
    }
}
