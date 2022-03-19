using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreditsMenuController : MonoBehaviour
{
    public GameObject menuUI, creditsUI;
   // public GameObject  doneObject;
 
  

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Done()
    {
        creditsUI.SetActive(false);
        menuUI.SetActive(true);
     
        EventSystem.current.SetSelectedGameObject(null);
       // EventSystem.current.SetSelectedGameObject(doneObject);
    }

}
