using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1 : MonoBehaviour
{
    public bool startLevel, clearPart1;
    public GameObject part1, part2, scenarioAttacks;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        startLevel = false;
        clearPart1 = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (startLevel == true)
        {
            FindObjectOfType<Tutorial>().tutorialImageAttack.SetActive(false);
            part1.SetActive(true);
            scenarioAttacks.SetActive(true);
        }

        if (part1.transform.childCount <= 0)
        {
            part2.SetActive(true);
        }

        if (part2.transform.childCount <= 0 && clearPart1 == false)
        {
            timer = 3f;
            clearPart1 = true;


        }
        if (part2.transform.childCount <= 0 && timer < 0)
        {
            Debug.Log(timer);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
