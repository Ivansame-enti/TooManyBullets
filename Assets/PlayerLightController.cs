using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
    public Level6Controller lvl6;
    public float blinkTimer;
    private float timer;
    private bool animFinished;
    private bool off;
    // Start is called before the first frame update
    void Start()
    {
        off = false;
        timer = blinkTimer;
        animFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "Light")
        {
            if (this.GetComponent<SpriteRenderer>().color.a == 0f)
            {
                //this.GetComponent<Circ>()
                off = true;
            }
            else off = false;

            if (lvl6.phasecounter == 3)
            {
                if (timer <= 0)
                {
                    this.GetComponent<Animator>().SetBool("Blink", true);
                    animFinished = false;
                    timer = blinkTimer;
                }
                else if(animFinished)
                {
                    timer -= Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!off)
        {
            if (collision.tag == "enemy" || collision.tag == "EnemyBullet")
                collision.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!off)
        {
            if (collision.tag == "enemy" || collision.tag == "EnemyBullet")
                collision.GetComponent<SpriteRenderer>().sortingOrder = 11;
        } else
        {
            if (collision.tag == "enemy" || collision.tag == "EnemyBullet")
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.tag == "enemy" || collision.tag == "EnemyBullet")
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }

    private void Blink(string mensaje)
    {
        if (mensaje.Equals("Blink"))
        {
            this.GetComponent<Animator>().SetBool("Blink", false);
            animFinished = true;
        }
    }
}
