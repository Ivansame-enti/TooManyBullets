using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel4 : MonoBehaviour
{
    public bool startLevel;
    public VictoryController victorycontroller;
    public GameObject scenarioAttacks, scenarioattack1, tutorialUI,tutorialEnemies;
    public GameObject part1, part2, part3, part4, player, shilds;

    // Start is called before the first frame update
    void Start()
    {
        startLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (part1.transform.childCount <= 0 && tutorialEnemies.transform.childCount <= 0)
        {
            tutorialUI.SetActive(false);
            part2.SetActive(true);
            shilds.SetActive(true);
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
