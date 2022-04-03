using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionMenuController : MonoBehaviour
{
    public GameObject menuUI, optionsUI;
    public GameObject sliderObject, dropdownObject, fullScreenObject,doneObject;
    public AudioMixer am;
    public Slider vol;
    public float vol_aux;
    public GameObject pantalla;
    public Dropdown dropdown;
    Resolution[] available_resolutions;
    private List<string> resolutions = new List<string>();
    private int index;
    public Text sliderText;

    // Start is called before the first frame update
    void Start()
    {
        vol.value = PlayerPrefs.GetFloat("volume", 0.75f);
        sliderText.text = Mathf.RoundToInt(vol.value * 100) + "%";
        available_resolutions = Screen.resolutions;

        dropdown.ClearOptions();

        for (int i = 0; i < available_resolutions.Length; i++)
        {
            string resolucion = available_resolutions[i].width + "x" + available_resolutions[i].height;
            resolutions.Add(resolucion);

            if (available_resolutions[i].width == Screen.currentResolution.width && available_resolutions[i].height == Screen.currentResolution.height)
            {
                index = i;
            }
        }

        dropdown.AddOptions(resolutions);
        dropdown.value = index;
        dropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {

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
    public void FullScreenOption()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(fullScreenObject);
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void Done()
    {
        menuUI.SetActive(true);
        pantalla.SetActive(false);
        optionsUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(doneObject);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Resolutions(int i)
    {
        Resolution r = available_resolutions[i];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }
}
