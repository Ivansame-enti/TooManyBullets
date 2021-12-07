using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{

    public GameObject ataque;
    private float timer;
    private GameObject ataquei2;
    public float JoystickXRange;
    public float JoystickYRange;
    public float attackRange;
    public float attackCD;
    float xPos, yPos;
    float result, result2, result3, result4;
    public ParticleSystem particles;

    private void Damage(float rotx, float roty, float rotx2, float roty2)
    {
        ataquei2 = Instantiate(ataque);
        Instantiate(particles, new Vector2(transform.position.x + xPos * attackRange, transform.position.y + yPos * -attackRange), Quaternion.identity);
        ataquei2.transform.position = new Vector2(transform.position.x + xPos * attackRange, transform.position.y + yPos * -attackRange);
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, roty2 - rotx2));
        ataquei2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, roty - rotx));
        //ataquei2.GetComponent<Animation>().Play();
        //Destroy(this.ataquei2, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        //Destroy(this.ataquei2, 0.50f);
        timer = attackCD;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            xPos = Input.GetAxis("RightJoystickX");
            yPos = Input.GetAxis("RightJoystickY");

            if ((xPos >= JoystickXRange || xPos <= -JoystickXRange) || (yPos >= JoystickYRange || yPos <= -JoystickYRange)) //Control por Joystick
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
            else if(Input.GetKeyDown(KeyCode.LeftArrow)) //Control por teclado
            {
                ataquei2 = Instantiate(ataque);
                Instantiate(particles, new Vector2(transform.position.x + -1 * attackRange, transform.position.y + 0 * -attackRange), Quaternion.identity);
                ataquei2.transform.position = new Vector2(transform.position.x + -1 * attackRange, transform.position.y + 0 * -attackRange);
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 - 0));
                ataquei2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 - 0));

                //Destroy(this.ataquei2, 1);
                timer = attackCD;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ataquei2 = Instantiate(ataque);
                Instantiate(particles, new Vector2(transform.position.x + +1 * attackRange, transform.position.y + 0 * -attackRange), Quaternion.identity);
                ataquei2.transform.position = new Vector2(transform.position.x + +1 * attackRange, transform.position.y + 0 * -attackRange);
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270 - 0));
                ataquei2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0 - 0));

                //Destroy(this.ataquei2, 1);
                timer = attackCD;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ataquei2 = Instantiate(ataque);
                Instantiate(particles, new Vector2(transform.position.x + 0 * attackRange, transform.position.y + -1 * -attackRange), Quaternion.identity);
                ataquei2.transform.position = new Vector2(transform.position.x + 0 * attackRange, transform.position.y + -1 * -attackRange);
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0 - 0));
                ataquei2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0 + 90));

                ///Destroy(this.ataquei2, 1);
                timer = attackCD;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ataquei2 = Instantiate(ataque);
                Instantiate(particles, new Vector2(transform.position.x + 0 * attackRange, transform.position.y + 1 * -attackRange), Quaternion.identity);
                ataquei2.transform.position = new Vector2(transform.position.x + 0 * attackRange, transform.position.y + 1 * -attackRange);
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0 - 180));
                ataquei2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0 - 90));

                //Destroy(this.ataquei2, 1);
                timer = attackCD;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
