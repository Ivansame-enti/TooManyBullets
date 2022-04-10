using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level5Controller : MonoBehaviour
{
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject scenario;
    public GameObject arrowCanvas;
    private int phasecounter;
    private bool oneTime;
    private bool textFlag2, textFlag3, textFlag4;
    private AudioManagerController audio;
    public TextMeshProUGUI phaseInfo;
    public Animation textAnim;
    // Start is called before the first frame update
    void Start()
    {
        phasecounter = 0;
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase3.SetActive(false);
        phase4.SetActive(false);
        scenario.SetActive(false);
        oneTime = true;
        audio = FindObjectOfType<AudioManagerController>();
        phaseInfo.text = "Phase 1/4";
        textAnim.Play("phaseInfo");
        textFlag2 = true;
        textFlag3 = true;
        textFlag4 = true;
        //arrowCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase2.transform.childCount <= 0 && phasecounter == 2)
        {
            phase2.SetActive(false);
            phase3.SetActive(true);
            if (textFlag3 == true)
            {
                phaseInfo.text = "Phase 3/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag3 = false;
            }
            phasecounter++;
        }

        if (phase3.transform.childCount <= 0 && phasecounter == 3)
        {
            if (oneTime)
            {
                GameObject[] bullets;

                bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

                foreach (GameObject bullet in bullets)
                {
                    Destroy(bullet);
                }
                oneTime = false;
            }
            scenario.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(true);
            if (textFlag4 == true)
            {
                phaseInfo.text = "Phase 4/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                textFlag4 = false;
            }
            //phasecounter++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerTag"))
        {
            if (phasecounter == 0)
            {
                FindObjectOfType<AudioManagerController>().AudioPlay("Plim");
                arrowCanvas.SetActive(false);
                //arrowCanvas.transform.position = new Vector3(-300 ,45, 0);
                //arrowCanvas.GetComponent<RectTransform>().position = new Vector3(-300, 45, 0);
                this.transform.position = new Vector3(-16.2f, this.transform.position.y, 1);
                phasecounter++;
            }
            else if (phasecounter == 1)
            {
                if (textFlag2 == true)
                {
                    phaseInfo.text = "Phase 2/4";
                    textAnim.Play("phaseInfo");
                    audio.AudioPlay("Plim");
                    textFlag2 = false;
                }
                FindObjectOfType<AudioManagerController>().AudioPlay("Plim");
                //arrowCanvas.SetActive(false);
                phase1.SetActive(false);
                phase2.SetActive(true);

                scenario.SetActive(true);
                GameObject[] bullets;

                bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

                foreach (GameObject bullet in bullets)
                {
                    Destroy(bullet);
                }
                phasecounter++;
                this.transform.position = new Vector3(0f, 50f, 1);
            }
        }
    }
}
