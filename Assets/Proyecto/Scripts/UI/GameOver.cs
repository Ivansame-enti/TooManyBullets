using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public PlayerHealthController isDead;
    public GameObject restartButton, GameOverUI,gameOverPanel;
    private bool gameOver,firstTime;
    public static bool goingLS;

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
                if (GameObject.Find("MiniJoe")) GameObject.Find("MiniJoe").SetActive(false);
                firstTime = false;
            }
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
