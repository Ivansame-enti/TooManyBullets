using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelEndingController : MonoBehaviour
{
    List<GameObject> enemyList = new List<GameObject>();
    private bool emptyList = true;
    public VictoryController victoryController;

    public GameObject newRecordText;
    public TextMeshProUGUI scoreText;
    private int scoreInt, highScore;
    string highScoreKey = "HighScore5";
    private bool level2;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Nivel2") level2 = false;
        else level2 = true;

        if (level2 == false)
        {
            highScore = PlayerPrefs.GetInt(highScoreKey, 0);
            newRecordText.SetActive(false);
        }

        //enemyList.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count == 0 && !emptyList)
        {
            if(level2 == false)
            {
                scoreInt = (int)ScoreSystem.score;
                scoreText.text = scoreInt.ToString();
                if (scoreInt > highScore)
                {
                    PlayerPrefs.SetInt(highScoreKey, scoreInt);
                    PlayerPrefs.Save();
                    newRecordText.SetActive(true);
                }
            }

            victoryController.victory = true;
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
