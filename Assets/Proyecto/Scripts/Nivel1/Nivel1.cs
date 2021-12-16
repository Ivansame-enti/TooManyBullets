using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1 : MonoBehaviour
{
    public bool startLevel, clearPart1;
    public GameObject part1, part2,part3, scenarioAttacks,multiLaser,uniLaser;
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
            timer = 8f;
            clearPart1 = true;
            multiLaser.SetActive(true);
            uniLaser.SetActive(false);


        }
        if (part2.transform.childCount <= 0 && timer < 0)
        {
            part3.SetActive(true);
            multiLaser.SetActive(false);
            uniLaser.SetActive(true);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if(part3.transform.childCount <= 0)
        {
            Debug.Log("win");
        }
    }
}
