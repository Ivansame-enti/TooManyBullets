using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectLevelsButton : MonoBehaviour
{
    public GameObject menuUI, levelSelectorUI;
    public GameObject returnButton,level1, level2, level3, level4, level5;
    // Start is called before the first frame update
    void Start()
    {
        
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

    }
    public void PlayLevel5Button()
    {
        SceneManager.LoadScene("Nivel5");
    }


    public void ReturnButton()
    {
        menuUI.SetActive(true);
        levelSelectorUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(returnButton);
    }
}
