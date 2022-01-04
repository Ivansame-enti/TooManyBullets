using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public PlayerHealthController isDead;
    public GameObject restartButton, GameOverUI;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead.dead == true && gameOver == false)
        {
            gameOver = true;
            GameOverUI.SetActive(true);
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
}
