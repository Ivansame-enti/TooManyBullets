using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1 : MonoBehaviour
{
    public bool startLevel;
    public GameObject enemies,scenarioAttacks;
    // Start is called before the first frame update
    void Start()
    {
        startLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startLevel == true)
        {
            FindObjectOfType<Tutorial>().tutorialImageAttack.SetActive(false);
            enemies.SetActive(true);
            scenarioAttacks.SetActive(true);
        }
    }
}
