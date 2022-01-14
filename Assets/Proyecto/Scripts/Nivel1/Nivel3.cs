using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel3 : MonoBehaviour
{
    public bool startLevel;
    public VictoryController victorycontroller;
    public GameObject enemies, scenarioAttacks, scenarioattack1, objects, tutorial;
    public GameObject part1, part2, part3, part4, player;
    // Start is called before the first frame update
    void Start()
    {
        startLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (part1.transform.childCount <= 0)
        {
            part2.SetActive(true);
            objects.SetActive(true);
            tutorial.SetActive(false);
        }

        if (part2.transform.childCount <= 0)
        {
            part3.SetActive(true);
            objects.SetActive(false);
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
