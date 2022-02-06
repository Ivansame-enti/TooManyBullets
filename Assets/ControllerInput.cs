using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    public static bool Xbox_One_Controller = false;
    public static bool PS4_Controller = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 33)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                PS4_Controller = false;
                Xbox_One_Controller = true;
            }

            else if (names[x].Length == 19)
            {
                print("PS4 CONTROLLER IS CONNECTED");
                PS4_Controller = true;
                Xbox_One_Controller = false;
            }
        }
    }
}