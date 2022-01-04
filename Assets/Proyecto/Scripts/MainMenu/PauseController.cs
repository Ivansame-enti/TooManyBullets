using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseController : MonoBehaviour
{
    public GameObject pauseUI,continueUI;
    public bool pauseState;
    public PlayerHealthController isDead;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        pauseState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start")) && pauseState == false && isDead.dead == false)
        {
            pauseState = true;
            pauseUI.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(continueUI);
            Time.timeScale = 0f;
        }

        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start")) && pauseState == true)
        {
            pauseState = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void continueButton()
    {
        pauseState = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
