using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level2Controller : MonoBehaviour
{
    public GameObject controllerSprite;
    public Image arrowImage;
    public Image imagePhase3;
    public GameObject textUI;
    public GameObject counterUI;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject shieldTutorial,shieldXbox, shieldPS4, shieldKeyboard;
    private int phasecounter;
    private int enemiesDestroyed;
    private TextMeshProUGUI textPro;
    // Start is called before the first frame update
    void Start()
    {
        phasecounter = 0;
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase3.SetActive(false);
        phase4.SetActive(false);
        enemiesDestroyed = 0;
        textPro = counterUI.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerInput.Xbox_One_Controller == true)
        {
            shieldXbox.SetActive(true);
            shieldPS4.SetActive(false);
            shieldKeyboard.SetActive(false);
        }
        else if (ControllerInput.PS4_Controller == true)
        {
            shieldXbox.SetActive(false);
            shieldPS4.SetActive(true);
            shieldKeyboard.SetActive(false);
        }
        else if (ControllerInput.Xbox_One_Controller == false && ControllerInput.PS4_Controller == false)
        {
            shieldXbox.SetActive(false);
            shieldPS4.SetActive(false);
            shieldKeyboard.SetActive(true);
        }
        if (phasecounter == 4)
        {
            phase3.SetActive(false);
            phase4.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerTag"))
        {
            if (phasecounter == 0)
            {
                //Destroy(this.GetComponent<SpriteRenderer>());
                //Destroy(this.GetComponent<Rigidbody2D>());
                //Destroy(this.GetComponent<CircleCollider2D>());
                shieldTutorial.SetActive(false);
                phase1.SetActive(false);
                phase2.SetActive(true);
                this.transform.position = new Vector3(-19.5f, -10f, 1);
                controllerSprite.SetActive(false);
                arrowImage.enabled = false;
                phasecounter++;
            } else if (phasecounter == 1)
            {
                GameObject[] bullets;

                bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

                foreach (GameObject bullet in bullets)
                {
                    Destroy(bullet);
                }
                phase2.SetActive(false);
                phase3.SetActive(true);
                imagePhase3.gameObject.SetActive(true);
                textUI.SetActive(true);
                counterUI.SetActive(true);
                textPro.text = enemiesDestroyed.ToString();
                this.transform.localScale = new Vector3(30,30,0);
                this.transform.position = new Vector3(22f, -0.3f, 0);
                phasecounter++;
            }
        }

        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.transform.parent.gameObject);
            enemiesDestroyed++;
            textPro.text = enemiesDestroyed.ToString();
            if (enemiesDestroyed == 2)
            {
                counterUI.SetActive(false);
                imagePhase3.gameObject.SetActive(false);
                textUI.SetActive(false);
                phasecounter = 4;
            }
        }
    }
}
