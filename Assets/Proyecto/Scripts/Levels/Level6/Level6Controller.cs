using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level6Controller : MonoBehaviour
{
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject lights;
    public GameObject scenario;
    public int phasecounter;
    public VictoryController victorycontroller;
    private AudioManagerController audioSFX;
    public TextMeshProUGUI phaseInfo;
    public Animation textAnim;
    private bool textFlag2, textFlag3, textFlag4;
    private GameObject[] water;
    // Start is called before the first frame update
    void Start()
    {
        audioSFX = FindObjectOfType<AudioManagerController>();
        phaseInfo.text = "Stage 1/4";
        textAnim.Play("phaseInfo");
        textFlag2 = true;
        textFlag3 = true;
        textFlag4 = true;
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase3.SetActive(false);
        phase4.SetActive(false);
        lights.SetActive(false);
        scenario.SetActive(false);
        phasecounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (phase1.transform.childCount <= 0 && phasecounter == 0)
        {
            phase2.SetActive(true);
            if (textFlag2 == true)
            {
                phaseInfo.text = "Stage 2/4";
                textAnim.Play("phaseInfo");
                audioSFX.AudioPlay("Plim");
                textFlag2 = false;
            }
            scenario.SetActive(true);
            phase1.SetActive(false);
            phasecounter++;
        }

        if (phase2.transform.childCount <= 0 && phasecounter == 1)
        {
            phase2.SetActive(false);
            phase3.SetActive(true);
            if (textFlag3 == true)
            {
                phaseInfo.text = "Stage 3/4";
                textAnim.Play("phaseInfo");
                audioSFX.AudioPlay("Plim");
                textFlag3 = false;
            }
            lights.SetActive(true);
            phasecounter++;
        }

        if (phase3.transform.childCount <= 0 && phasecounter == 2)
        {
            phase3.SetActive(false);
            phase4.SetActive(true);
            scenario.SetActive(false);
            if (textFlag4 == true)
            {
                phaseInfo.text = "Stage 4/4";
                textAnim.Play("phaseInfo");
                audioSFX.AudioPlay("Plim");
                textFlag4 = false;
                water = GameObject.FindGameObjectsWithTag("EnemyBullet");

                foreach (GameObject bullet in water)
                {
                    Destroy(bullet);
                }
            }
            //lights.SetActive(true);
            phasecounter++;
        }

        if (phase4.transform.childCount <= 0 && phasecounter == 3)
        {
            victorycontroller.victory = true;
        }
    }
}
