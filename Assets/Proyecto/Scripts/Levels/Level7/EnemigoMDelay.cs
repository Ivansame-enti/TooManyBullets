using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMDelay : MonoBehaviour
{
    // Start is called before the first frame update
   
    private float time = 0.0f;
    private bool flag = false;
    void Start()
    {
        GameObject enemigo1 = GameObject.Find("Enemy2");
        GameObject enemigo2 = GameObject.Find("Enemy22");
        GameObject enemigo3 = GameObject.Find("Enemy23");
        MeleeEnemyController enemy = enemigo1.GetComponent<MeleeEnemyController>();
        MeleeEnemyController enemy2 = enemigo2.GetComponent<MeleeEnemyController>();
        MeleeEnemyController enemy3 = enemigo3.GetComponent<MeleeEnemyController>();
        enemy.movementSpeed = 0.0f;
        enemy2.movementSpeed = 0.0f;
        enemy3.movementSpeed = 0.0f;
   
    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemigo1 = GameObject.Find("Enemy2");
        GameObject enemigo2 = GameObject.Find("Enemy22");
        GameObject enemigo3 = GameObject.Find("Enemy23");


        if (!flag)
        {
            PolygonCollider2D enemyC = enemigo1.GetComponent<PolygonCollider2D>();
            PolygonCollider2D enemyC2 = enemigo2.GetComponent<PolygonCollider2D>();
            PolygonCollider2D enemyC3 = enemigo3.GetComponent<PolygonCollider2D>();
            enemyC.enabled = false;
            enemyC2.enabled = false;
            enemyC3.enabled = false;
        }


        if (!flag) { 
        time += Time.deltaTime;
        if (time >= 2.0f)
        {
           // GameObject enemigo1 = GameObject.Find("Enemy2");
           // GameObject enemigo2 = GameObject.Find("Enemy22");
           // GameObject enemigo3 = GameObject.Find("Enemy23");
            MeleeEnemyController enemy = enemigo1.GetComponent<MeleeEnemyController>();
            MeleeEnemyController enemy2 = enemigo2.GetComponent<MeleeEnemyController>();
            MeleeEnemyController enemy3 = enemigo3.GetComponent<MeleeEnemyController>();
            enemy.movementSpeed = 400.0f;
            enemy2.movementSpeed = 400.0f;
            enemy3.movementSpeed = 400.0f;


                PolygonCollider2D enemyC = enemigo1.GetComponent<PolygonCollider2D>();
                PolygonCollider2D enemyC2 = enemigo2.GetComponent<PolygonCollider2D>();
                PolygonCollider2D enemyC3 = enemigo3.GetComponent<PolygonCollider2D>();

                enemyC.enabled = true;
                enemyC2.enabled =true;
                enemyC3.enabled =true;

                flag = true;
            }
        }
    }




}
