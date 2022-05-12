using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puntuación : MonoBehaviour
{
    // Start is called before the first frame update

    public static int Score = 0;
    public string ScoreString = "SCORE : 00000000";
    private float time;
    private PlayerHealthController health;

    public TextMeshProUGUI TextScore;

    public static Puntuación puntuación;

    void Awake()
    {
        puntuación = this;
        time = Time.deltaTime;
        health = GetComponent<PlayerHealthController>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextScore != null)
        {
          
            TextScore.text = ScoreString + Score;
            Score = Score + 1;

            if (Score > 0 && Score <10)
            {
                ScoreString = "Score : 0000000";
            }
            else if (Score >= 10 && Score <100)
            {
                ScoreString = "Score : 000000";
            }
            else if (Score >= 100 && Score <1000)
            {
                ScoreString = "Score : 00000";
            }
            else if (Score >= 1000 && Score < 10000)
            {
                ScoreString = "Score : 0000";
            }
            else if (Score >= 10000 && Score < 100000)
            {
                ScoreString = "Score : 000";
            }
            else if (Score >= 100000 && Score < 1000000)
            {
                ScoreString = "Score : 00";
            }
            else if (Score >= 1000000 && Score < 10000000)
            {
                ScoreString = "Score : 0";
            }
            else if (Score >= 10000000 && Score < 100000000)
            {
                ScoreString = "Score : ";
            }

          //  if (health.health = 0)
            {

            }

        }

       

        //  TextScore.text = ScoreString + Score;

    }
}
