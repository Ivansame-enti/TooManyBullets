using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public static float score = 0;
    private int scoreInt;
    public int pentakill;
    public string ScoreString = "score : 00000000";
    //private float time;
    //private PlayerHealthController health;
    private float timer;
    private float timer2;
    public float pentaTimer;
    public TextMeshProUGUI TextScore;
    private bool combo;
    public bool enemyKilled;

    //private EnemyHealthController enemyH;
    //public static ScoreSystem puntuación;

    void Awake()
    {
        enemyKilled = false;
        //puntuación = this;
        //time = Time.deltaTime;
        //health = GetComponent<PlayerHealthController>();
        score = 0;
        timer2 = 0;
        //enemyH = FindObjectOfType<EnemyHealthController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreInt = (int)score;

        if(score > 0)
        {
            score -= Time.deltaTime * 102;
        }
        
        if (enemyKilled)
        {
            combo = true;
            timer2 = 0;
            enemyKilled = false;
        }

        if(timer2 >= pentaTimer && combo == true)
        {
            combo = false;
            pentakill = 0;
        }
        //Debug.Log(pentaTimer);
        timer2 += Time.deltaTime;

        

        if (TextScore != null)
        {
          
            TextScore.text = ScoreString + scoreInt;
            //score = score + 1;

            if (score >= 0 && score <10)
            {
                ScoreString = "score : 0000000";
            }
            else if (score >= 10 && score <100)
            {
                ScoreString = "score : 000000";
            }
            else if (score >= 100 && score <1000)
            {
                ScoreString = "score : 00000";
            }
            else if (score >= 1000 && score < 10000)
            {
                ScoreString = "score : 0000";
            }
            else if (score >= 10000 && score < 100000)
            {
                ScoreString = "score : 000";
            }
            else if (score >= 100000 && score < 1000000)
            {
                ScoreString = "score : 00";
            }
            else if (score >= 1000000 && score < 10000000)
            {
                ScoreString = "score : 0";
            }
            else if (score >= 10000000 && score < 100000000)
            {
                ScoreString = "score : ";
            }

          //  if (health.health = 0)
            {

            }

        }

       

        //  TextScore.text = ScoreString + score;

    }
}
