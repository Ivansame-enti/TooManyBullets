using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndingController : MonoBehaviour
{
    List<GameObject> enemyList = new List<GameObject>();
    private bool emptyList = true;

    // Start is called before the first frame update
    void Start()
    {
        //enemyList.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count == 0 && !emptyList)
        {
            Debug.Log("Ha terminado la partida");
        }
    }

    public void EnemyDies(GameObject enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
        }
    }

    public void AddEnnemy(GameObject enemy)
    {
        emptyList = false;
        enemyList.Add(enemy);
    }
}
