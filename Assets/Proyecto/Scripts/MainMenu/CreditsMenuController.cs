using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreditsMenuController : MonoBehaviour
{
    public GameObject menuUI, creditsUI, pantalla;
   // public GameObject  doneObject;
 
  

    // Start is called before the first frame update
    void Start()
    {
       // pantalla.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Done()
    {
        creditsUI.SetActive(false);
        menuUI.SetActive(true);
        pantalla.SetActive(false);
     
        EventSystem.current.SetSelectedGameObject(null);
       // EventSystem.current.SetSelectedGameObject(doneObject);
    }

}
