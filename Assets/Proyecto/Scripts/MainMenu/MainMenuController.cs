using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuController : MonoBehaviour
{
    public GameObject menuUI, optionsUI,levelSelectorUI;
    public GameObject playButton, optionButton, exitButton,level1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (VictoryController.goingLS == true || GameOver.goingLS == true)
        {
            VictoryController.goingLS = false;
            GameOver.goingLS = false;
            menuUI.SetActive(false);
            levelSelectorUI.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(level1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        menuUI.SetActive(false);
        levelSelectorUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void Options()
    {
        menuUI.SetActive(false);
        optionsUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionButton);
    }

    public void QuitGame()
    {
        Application.Quit();

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitButton);
    }


}
