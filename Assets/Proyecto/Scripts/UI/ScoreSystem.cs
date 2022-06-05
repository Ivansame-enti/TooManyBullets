using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public static float score = 0;
    private int scoreInt;
    public int pentakill;
    public Transform enemyTransform;
    public string ScoreString = "score : 00000000";
    //private float time;
    //private PlayerHealthController health;
    private float timer;
    private float timer2;
    public float pentaTimer;
    public TextMeshProUGUI TextScore;
    private bool combo;
    public bool enemyKilled;
    public VictoryController victorycontroller;
    public VictoryBossController victoryBossController;
    private bool bossLevel;
    private ComboMultiplier multi;

    //private EnemyHealthController enemyH;
    //public static ScoreSystem puntuación;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name != "BossLevel") bossLevel = false;
        else bossLevel = true;
        if(!bossLevel) victorycontroller = GameObject.Find("VictoryController").GetComponent<VictoryController>();
        else victoryBossController = GameObject.Find("VictoryController").GetComponent<VictoryBossController>();
        enemyKilled = false;
        //puntuación = this;
        //time = Time.deltaTime;
        //health = GetComponent<PlayerHealthController>();
        score = 0;
        timer2 = 0;
        multi = GameObject.FindGameObjectWithTag("Multiplier").GetComponent<ComboMultiplier>();
        multi.maxTimer = pentaTimer;
        //enemyH = FindObjectOfType<EnemyHealthController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreInt = (int)score;

        if (!bossLevel)
        {
            if (score > 0 && victorycontroller.victory != true)
            {
                score -= Time.deltaTime * 102;
            }
        } else
        {
            if (score > 0 && victoryBossController.victory != true)
            {
                score -= Time.deltaTime * 102;
            }
        }
        
        /*if (enemyKilled)
        {
            multi.mult = pentakill;
            Debug.Log(enemyTransform.position);
            multi.enemyKilled(enemyTransform);
            combo = true;
            timer2 = pentaTimer;
            enemyKilled = false;
        }*/

        if(timer2 <= 0 && combo == true)
        {
            combo = false;
            pentakill = 0;
        }
        //Debug.Log(pentaTimer);
        if (combo)
        {
            timer2 -= Time.deltaTime;
            multi.timer = timer2;
        }

        TextScore.text = scoreInt.ToString();
        /*
        if (TextScore != null)
        {
          
            

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
        }
        */
    }

    public void enemy(Transform a)
    {
        multi.mult = pentakill;
        //Debug.Log(enemyTransform.position);
        multi.enemyKilled(a);
        combo = true;
        timer2 = pentaTimer;
    }

    public void TakeDamage()
    {
        pentakill = 0;
        multi.mult = 0;
        //Debug.Log(enemyTransform.position);
        //multi.enemyKilled(a);
        combo = false;
        timer2 = 0;
        multi.TakeDamage();
    }
}
