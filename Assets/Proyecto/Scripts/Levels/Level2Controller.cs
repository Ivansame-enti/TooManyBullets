using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Controller : MonoBehaviour
{
    public Image controllerSprite;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    private int phasecounter;
    // Start is called before the first frame update
    void Start()
    {
        phasecounter = 0;
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase3.SetActive(false);
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
                //Destroy(this.GetComponent<SpriteRenderer>());
                //Destroy(this.GetComponent<Rigidbody2D>());
                //Destroy(this.GetComponent<CircleCollider2D>());
                phase1.SetActive(false);
                phase2.SetActive(true);
                this.transform.position = new Vector3(-19.5f, -10f, 1);
                controllerSprite.enabled = false;
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
            }
        }
    }
}
