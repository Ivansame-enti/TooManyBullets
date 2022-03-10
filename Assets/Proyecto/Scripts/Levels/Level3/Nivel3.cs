using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel3 : MonoBehaviour
{
    public bool startLevel;
    public VictoryController victorycontroller;
    public GameObject enemies, scenarioAttacks, scenarioattack1, objects, tutorial;
    public GameObject part1, part2, part3, part4, player;
    public PlayerHealthController playerIsDead;
    public GameObject laserXbox, laserPS4, laserKeyboard;
    public PlayerHealthController phc;
    // Start is called before the first frame update
    void Start()
    {
        phc.currentHealth--;
        startLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerInput.Xbox_One_Controller == true)
        {
            laserXbox.SetActive(true);
            laserPS4.SetActive(false);
            laserKeyboard.SetActive(false);
        }
        else if (ControllerInput.PS4_Controller == true)
        {
            laserXbox.SetActive(false);
            laserPS4.SetActive(true);
            laserKeyboard.SetActive(false);
        }
        else if (ControllerInput.Xbox_One_Controller == false && ControllerInput.PS4_Controller == false)
        {
            laserXbox.SetActive(false);
            laserPS4.SetActive(false);
            laserKeyboard.SetActive(true);
        }
        if (part1.transform.childCount <= 0 && playerIsDead.dead == false && phc.currentHealth==phc.health)
        {
            part2.SetActive(true);
            objects.SetActive(true);

        }

        if (part2.transform.childCount <= 0)
        {
            part3.SetActive(true);
            objects.SetActive(false);
            tutorial.SetActive(false);
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
