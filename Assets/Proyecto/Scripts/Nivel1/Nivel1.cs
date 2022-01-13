using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1 : MonoBehaviour
{
    public bool startLevel;
    public GameObject enemies,scenarioAttacks, enemy1,enemy2,enemy3,enemy4,enemy5,enemy6,enemy7, scenarioattack1, objects,objects2,tutorial, enemy8,enemy9,enemy10;
    public GameObject enemy11, enemy12, enemy13, enemy14, enemy15, enemy16, enemy17, enemy18;
    private bool flag1=false;
    // Start is called before the first frame update
    void Start()
    {
        startLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
  

        if (enemy2==false)
        {
           // enemy1.SetActive(true);
           // enemy3.SetActive(true);
           // enemy4.SetActive(true);
            enemy5.SetActive(true);
            enemy6.SetActive(true);
            enemy7.SetActive(true);
            enemy8.SetActive(true);
            enemy9.SetActive(true);
            enemy10.SetActive(true);
            objects.SetActive(true);
            objects2.SetActive(true);
            tutorial.SetActive(false);
            scenarioattack1.SetActive(true);

            if (enemy5==null) // QUE COMPRUEBE QUE ESTEN MUERTOS
            {
                flag1=true;
                Debug.Log("Ei");
            }
        }
        if (flag1)
        {

            enemy11.SetActive(true);
            enemy12.SetActive(true);
            enemy13.SetActive(true);
            enemy14.SetActive(true);
            enemy15.SetActive(true);
            enemy16.SetActive(true);
            enemy17.SetActive(true);
            enemy18.SetActive(true);

        }
    }
}
