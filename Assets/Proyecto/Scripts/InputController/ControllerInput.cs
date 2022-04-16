using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerInput : MonoBehaviour
{
    public static bool Xbox_One_Controller = false;
    public static bool PS4_Controller = false;
    EventSystem eventSystem;
    StandaloneInputModule inputModule;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        inputModule = eventSystem.gameObject.GetComponent<StandaloneInputModule>();
    }

    // Update is called once per frame
    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 33)
            {
                inputModule.horizontalAxis = "HorizontalUIXbox";
                inputModule.verticalAxis = "VerticalUIXbox";
                inputModule.submitButton = "SubmitXbox";
                //print("XBOX ONE CONTROLLER IS CONNECTED");
                //eventSystem.GetComponent<Standalone>
                PS4_Controller = false;
                Xbox_One_Controller = true;
            }
            else if (names[x].Length == 19)
            {
                inputModule.horizontalAxis = "HorizontalUI";
                inputModule.verticalAxis = "VerticalUI";
                inputModule.submitButton = "Submit";
                //print("PS4 CONTROLLER IS CONNECTED");
                PS4_Controller = true;
                Xbox_One_Controller = false;
            } else
            {
                inputModule.horizontalAxis = "HorizontalUI";
                inputModule.verticalAxis = "VerticalUI";
                inputModule.submitButton = "Submit";
            }
        }
    }
}