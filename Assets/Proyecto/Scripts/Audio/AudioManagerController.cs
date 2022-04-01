using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerController : MonoBehaviour
{

    public Sound[] audios;
    public AudioMixerGroup audioMixer;

    void Awake()
    {
        foreach(Sound a in audios)
        {
            
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.outputAudioMixerGroup = audioMixer;

            a.source.clip = a.clip;

            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;

        }
        
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        
        if (sceneName == "MainMenu" || sceneName == "Options" || sceneName == "LevelSelector")
        {
            AudioPlay("MenuTheme");
        }
        else
        {
            AudioPlay("MainTheme");
        }
         //Musica de fondo  
        
    }

    public void AudioPlay(string name)
    {
        Sound a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Audio not found");
            return;
        }
        a.source.Play();
    }

    public void AudioPause(string name)
    {
        Sound a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Audio not found");
            return;
        }
        a.source.Stop();
    }
}
