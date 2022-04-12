using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public PlayerHealthController isDead;
    public GameObject restartButton, GameOverUI,gameOverPanel,gameObstacles;
    private bool gameOver,firstTime;
    public static bool goingLS;
    //private GameObject[] water;
    public GameObject UI, canvasTutorial;

    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
        firstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead.dead == true && gameOver == false)
        {
            if (firstTime)
            {
                /*water = GameObject.FindGameObjectsWithTag("EnemyBullet");

                foreach (GameObject bullet in water)
                {
                    Destroy(bullet);
                }*/

                AudioManagerController audio = FindObjectOfType<AudioManagerController>();

                /*if (audio.GetAudioPlaying("MainTheme"))
                {
                    audio.AudioStop("MainTheme");
                }*/

                if (audio.GetAudioPlaying("EnemyLaser"))
                {
                    audio.AudioStop("EnemyLaser");
                }
                if (audio.GetAudioPlaying("Laser"))
                {
                    audio.AudioStop("Laser");
                }

                if (GameObject.Find("MiniJoe")) GameObject.Find("MiniJoe").SetActive(false);
                if (gameObstacles != null)
                {
                    gameObstacles.SetActive(false);
                }
                firstTime = false;
            }
            if(canvasTutorial != null) canvasTutorial.SetActive(false);
            UI.SetActive(false);
            gameOver = true;
            GameOverUI.SetActive(true);
            gameOverPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(restartButton);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelector()
    {
        goingLS = true;
        SceneManager.LoadScene("MainMenu");
    }
}
