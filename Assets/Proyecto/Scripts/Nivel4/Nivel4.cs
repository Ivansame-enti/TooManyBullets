using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel4 : MonoBehaviour
{
    public bool startLevel;
    public GameObject enemies, scenarioAttacks, enemy1, enemy2, enemy3, enemy4, scenarioattack1;

    private bool flag1 = false;
    // Start is called before the first frame update
    void Start()
    {
        startLevel = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (startLevel)
        {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(true);
            enemy4.SetActive(true);
        }
    
    }
}
