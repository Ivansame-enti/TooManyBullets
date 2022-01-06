using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : MonoBehaviour
{
    public GameObject phase1;
    public GameObject phase2;
    private int phasecounter;
    // Start is called before the first frame update
    void Start()
    {
        phasecounter = 0;
        phase1.SetActive(true);
        phase2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerTag"))
        {
            if (phasecounter == 0)
            {
                this.transform.position = new Vector3(-16.2f, this.transform.position.y, 1);
                phasecounter++;
            }
            else if (phasecounter == 1)
            {
                phase1.SetActive(false);
                phase2.SetActive(true);
                GameObject[] bullets;

                bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

                foreach (GameObject bullet in bullets)
                {
                    Destroy(bullet);
                }
                phasecounter++;
            }
        }
    }
}
