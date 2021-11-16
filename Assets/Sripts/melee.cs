using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{

    public GameObject ataque;
    public GameObject player;
    private bool ataquet = false;
    public float timer = 1f;
    private GameObject ataquei;
    private GameObject ataquei2;
    private GameObject ataquei3;
    private GameObject ataquei4;
    public float JoystickXRange;
    public float JoystickYRange;
    float xPos, yPos;
    float result, result2, result3, result4;
    private float sensivity = 0.3f;

    private void Damage(float rotx, float roty, float rotx2, float roty2)
    {
        ataquei2 = Instantiate(ataque);
        //ataquei2.SetActive(true);
        ataquei2.transform.position = new Vector2(transform.position.x + xPos * 2, transform.position.y + yPos * -2);
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, roty2 - rotx2));
        ataquei2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, roty - rotx));

        Destroy(this.ataquei2, 1);
        timer = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            xPos = Input.GetAxis("RightJoystickX");
            yPos = Input.GetAxis("RightJoystickY");

            if ((xPos >= JoystickXRange || xPos <= -JoystickXRange) || (yPos >= JoystickYRange || yPos <= -JoystickYRange))
            {
                if ((xPos >= JoystickXRange || xPos <= -JoystickXRange)) result = Mathf.Lerp(0, 180, Mathf.InverseLerp(1, -1, xPos));
                else result = 0;
                if ((yPos >= JoystickYRange || yPos <= -JoystickYRange)) result2 = Mathf.Lerp(90, 270, Mathf.InverseLerp(-1, 1, yPos));
                else result2 = 0;

                if ((xPos >= JoystickXRange || xPos <= -JoystickXRange)) result3 = Mathf.Lerp(90, 270, Mathf.InverseLerp(1, -1, xPos));
                else result3 = 0;
                if ((yPos >= JoystickYRange || yPos <= -JoystickYRange)) result4 = Mathf.Lerp(0, 180, Mathf.InverseLerp(-1, 1, yPos));
                else result4 = 0;

                Damage(result, result2, result3, result4);
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
