using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class SelectLevelsButton : MonoBehaviour
{
    public GameObject menuUI, levelSelectorUI;
    public GameObject returnButton,level1, level2, level3, level4, level5, level6, level7, level8;
    public GameObject pantalla;
    public TextMeshProUGUI highScoreText;
    private int highScore3, highScore4, highScore5, highScore6, highScore7, highScore8;
    // Start is called before the first frame update
    void Start()
    {
        highScore3 = PlayerPrefs.GetInt("HighScore3", 0);
        highScore4 = PlayerPrefs.GetInt("HighScore4", 0);
        highScore5 = PlayerPrefs.GetInt("HighScore5", 0);
        highScore6 = PlayerPrefs.GetInt("HighScore6", 0);
        highScore7 = PlayerPrefs.GetInt("HighScore7", 0);
        highScore8 = PlayerPrefs.GetInt("HighScore8", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLevel1Button()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void PlayLevel2Button()
    {
        SceneManager.LoadScene("Nivel2");
    }
    public void PlayLevel3Button()
    {
        SceneManager.LoadScene("Nivel3");
    }

    public void PlayLevel4Button()
    {
        SceneManager.LoadScene("Nivel4");
    }
    public void PlayLevel5Button()
    {
        SceneManager.LoadScene("Nivel5");
    }

    public void PlayLevel6Button()
    {
        SceneManager.LoadScene("Nivel6");
    }

    public void PlayLevel7Button()
    {
        SceneManager.LoadScene("Nivel7");
    }

    public void PlayLevel8Button()
    {
        SceneManager.LoadScene("BossLevel");
    }


    public void ReturnButton()
    {
        menuUI.SetActive(true);
        levelSelectorUI.SetActive(false);
        pantalla.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(returnButton);
    }
    public void HighScoreLevel1()
    {
        highScoreText.text = "-------";
    }
    public void HighScoreLevel2()
    {
        highScoreText.text = "-------";
    }
    public void HighScoreLevel3()
    {
        highScoreText.text = highScore3.ToString("#,##0");
    }
    public void HighScoreLevel4()
    {
        highScoreText.text = highScore4.ToString("#,##0");
    }
    public void HighScoreLevel5()
    {
        highScoreText.text = highScore5.ToString("#,##0");
    }
    public void HighScoreLevel6()
    {
        highScoreText.text = highScore6.ToString("#,##0");
    }
    public void HighScoreLevel7()
    {
        highScoreText.text = highScore7.ToString("#,##0");
    }
    public void HighScoreLevel8()
    {
        highScoreText.text = highScore8.ToString("#,##0");
    }
    public void PointerExit()
    {
        highScoreText.text = "-------";
    }
}
