using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : MonoBehaviour
{
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject scenario;
    public GameObject arrowCanvas;
    private int phasecounter;
    private bool oneTime;
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
        //arrowCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase2.transform.childCount <= 0 && phasecounter == 2)
        {
            phase2.SetActive(false);
            phase3.SetActive(true);
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
            //phasecounter++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerTag"))
        {
            if (phasecounter == 0)
            {
                arrowCanvas.SetActive(false);
                //arrowCanvas.transform.position = new Vector3(-300 ,45, 0);
                //arrowCanvas.GetComponent<RectTransform>().position = new Vector3(-300, 45, 0);
                this.transform.position = new Vector3(-16.2f, this.transform.position.y, 1);
                phasecounter++;
            }
            else if (phasecounter == 1)
            {
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
