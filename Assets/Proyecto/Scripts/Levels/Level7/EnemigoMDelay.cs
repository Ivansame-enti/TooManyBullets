using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMDelay : MonoBehaviour
{
    // Start is called before the first frame update
   
    private float time = 0.0f;
    void Start()
    {
        GameObject thePlayer = GameObject.Find("Enemy2");
        GameObject thePlayer2 = GameObject.Find("Enemy22");
        GameObject thePlayer3 = GameObject.Find("Enemy23");
        MeleeEnemyController enemy = thePlayer.GetComponent<MeleeEnemyController>();
        MeleeEnemyController enemy2 = thePlayer2.GetComponent<MeleeEnemyController>();
        MeleeEnemyController enemy3 = thePlayer3.GetComponent<MeleeEnemyController>();
        enemy.movementSpeed = 0.0f;
        enemy2.movementSpeed = 0.0f;
        enemy3.movementSpeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {



        time += Time.deltaTime;
        if (time >= 2.0f)
        {
            GameObject thePlayer = GameObject.Find("Enemy2");
            GameObject thePlayer2 = GameObject.Find("Enemy22");
            GameObject thePlayer3 = GameObject.Find("Enemy23");
            MeleeEnemyController enemy = thePlayer.GetComponent<MeleeEnemyController>();
            MeleeEnemyController enemy2 = thePlayer2.GetComponent<MeleeEnemyController>();
            MeleeEnemyController enemy3 = thePlayer3.GetComponent<MeleeEnemyController>();
            enemy.movementSpeed = 400.0f;
            enemy2.movementSpeed = 400.0f;
            enemy3.movementSpeed = 400.0f;
        }
    }




}
