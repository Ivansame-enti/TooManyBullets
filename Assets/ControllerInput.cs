using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    private static int Xbox_One_Controller = 0;
    private static int PS4_Controller = 0;

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
            print(names[x].Length);
            /*if (names[x].Length == 19)
            {
                print("PS4 CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
            }
            if (names[x].Length == 33)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;

            }*/
        }
    }
}

