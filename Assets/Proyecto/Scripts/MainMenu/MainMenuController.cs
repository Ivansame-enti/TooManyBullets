using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuController : MonoBehaviour
{
    public GameObject menuUI, optionsUI,levelSelectorUI, creditsUI;
    public GameObject playButton, optionButton, exitButton,level1,creditButton, backButton;
    public GameObject pantalla;
    // Start is called before the first frame update
    void Start()
    {
        if (VictoryController.goingLS == true || GameOver.goingLS == true)
        {
            VictoryController.goingLS = false;
            GameOver.goingLS = false;
            menuUI.SetActive(false);
            levelSelectorUI.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(level1);
        }

        if (VictoryBossController.goingCredits == true)
        {
            VictoryBossController.goingCredits = false;
            menuUI.SetActive(false);
            levelSelectorUI.SetActive(false);
            creditsUI.SetActive(true);
            pantalla.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(backButton);
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
        pantalla.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void Options()
    {
        menuUI.SetActive(false);
        optionsUI.SetActive(true);
        pantalla.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionButton);
    }

    public void QuitGame()
    {
        Application.Quit();

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitButton);
    }

    public void Credits()
    {
        menuUI.SetActive(false);
        creditsUI.SetActive(true);
        pantalla.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backButton);
    }

    public void Return()
    {
        menuUI.SetActive(true);
        creditsUI.SetActive(false);
        pantalla.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditButton);
    }


}
