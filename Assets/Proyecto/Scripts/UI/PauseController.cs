using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseController : MonoBehaviour
{
    public GameObject pauseUI,continueUI;
    public bool pauseState;
    public PlayerHealthController isDead;
    public Slider vol;
    public Text sliderText;    
    public AudioMixer am;

    // Start is called before the first frame update
    void Start()
    {
        vol.value = PlayerPrefs.GetFloat("volume", 0.75f);
        sliderText.text = Mathf.RoundToInt(vol.value * 100) + "%";
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
        pauseUI.SetActive(false);
        pauseState = false;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetVolume(float volume)
    {
        am.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volume", volume);


    }
    public void sliderVolumeText(float value)
    {
        sliderText.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
