using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel4 : MonoBehaviour
{
    public bool startLevel;
    public VictoryController victorycontroller;
    public GameObject enemies,scenarioAttacks, enemy1,enemy2,enemy3,enemy4,enemy5,enemy6,enemy7, scenarioattack1, objects,objects2,tutorial, enemy8,enemy9,enemy10;
    public GameObject enemy11, enemy12, enemy13, enemy14, enemy15, enemy16, enemy17, enemy18;
    public GameObject part1, part2, part3, part4, player,shilds,field1,escudos2,obstaculo;
    private bool flag1=false;
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
          //  objects.SetActive(true);
          //  objects2.SetActive(true);
            tutorial.SetActive(false);
            shilds.SetActive(true);
            escudos2.SetActive(false);
            obstaculo.SetActive(false);
            

        }

        if (part2.transform.childCount <= 0)
        {
            part3.SetActive(true);
            shilds.SetActive(false);
            // / objects.SetActive(false);
            // objects2.SetActive(false);
            scenarioattack1.SetActive(false);

     


        }
        if (part3.transform.childCount <= 0)
        {
            part4.SetActive(true);
            scenarioattack1.SetActive(true);
            field1.SetActive(true);




        }

        if (part4.transform.childCount <= 0)
        {
            victorycontroller.victory = true;

        }
    }
}
