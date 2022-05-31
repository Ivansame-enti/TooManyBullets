using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Nivel3 : MonoBehaviour
{
    public bool startLevel;
    public VictoryController victorycontroller;
    public GameObject enemies, scenarioAttacks, scenarioattack1, objects, tutorial;
    public GameObject laserText, healText;
    public GameObject part1, part2, part3, part4, player;
    public PlayerHealthController playerIsDead;
    public GameObject laserXbox, laserPS4, laserKeyboard;
    public PlayerHealthController phc;
    private AudioManagerController audioSFX;
    public TextMeshProUGUI phaseInfo;
    public Animation textAnim;
    private bool textFlag2, textFlag3, textFlag4;

    public GameObject newRecordText;
    public TextMeshProUGUI scoreText;
    private int scoreInt, highScore;
    string highScoreKey = "HighScore3";
    // Start is called before the first frame update
    void Start()
    {
        audioSFX = FindObjectOfType<AudioManagerController>();
        phc.currentHealth--;
        startLevel = false;
        laserText.SetActive(false);
        healText.SetActive(true);
        phaseInfo.text = "Stage 1/4";
        textAnim.Play("phaseInfo");
        textFlag2 = true;
        textFlag3 = true;
        textFlag4 = true;

        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        newRecordText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerInput.Xbox_One_Controller == true)
        {
            laserXbox.SetActive(true);
            laserPS4.SetActive(false);
            laserKeyboard.SetActive(false);
        }
        else if (ControllerInput.PS4_Controller == true)
        {
            laserXbox.SetActive(false);
            laserPS4.SetActive(true);
            laserKeyboard.SetActive(false);
        }
        else if (ControllerInput.Xbox_One_Controller == false && ControllerInput.PS4_Controller == false)
        {
            laserXbox.SetActive(false);
            laserPS4.SetActive(false);
            laserKeyboard.SetActive(true);
        }
        if (part1.transform.childCount <= 0 && playerIsDead.dead == false && phc.currentHealth==phc.health)
        {
            part2.SetActive(true);

            if(textFlag2 == true)
            {
                phaseInfo.text = "Stage 2/4";
                textAnim.Play("phaseInfo");
                audioSFX.AudioPlay("Plim");
                textFlag2 = false;
            }

            laserText.SetActive(true);
            healText.SetActive(false);
            objects.SetActive(true);
        }


        if (part2.transform.childCount <= 0)
        {
            part3.SetActive(true);
            if (textFlag3 == true)
            {
                phaseInfo.text = "Stage 3/4";
                textAnim.Play("phaseInfo");
                audioSFX.AudioPlay("Plim");
                textFlag3 = false;
            }

            objects.SetActive(false);
            tutorial.SetActive(false);
        }
        if (part3.transform.childCount <= 0)
        {
            part4.SetActive(true);
            if (textFlag4 == true)
            {
                phaseInfo.text = "Stage 4/4";
                textAnim.Play("phaseInfo");
                audioSFX.AudioPlay("Plim");
                textFlag4 = false;
            }
            scenarioattack1.SetActive(true);
        }

        if (part4.transform.childCount <= 0)
        {
            scoreInt = (int)ScoreSystem.score;
            scoreText.text = scoreInt.ToString();
            if (scoreInt > highScore)
            {
                PlayerPrefs.SetInt(highScoreKey, scoreInt);
                PlayerPrefs.Save();
                newRecordText.SetActive(true);
            }
            victorycontroller.victory = true;

        }
    }
}
