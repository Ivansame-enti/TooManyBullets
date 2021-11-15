using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashDistance;
    public GameObject dashParticles;
    public float dashDelay;
    public float dashTime;
    private float timer;
    private float timer2;
    private float timer3;
    public float particle_delay;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        particle_delay = dashDelay/30;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer2 <= 0) //Tiempo mientras dasheas
        {
            this.GetComponent<PolygonCollider2D>().enabled = true;
            rb.velocity = Vector3.zero;
            timer3 = 0;
        }
        else
        {
            if (timer3 <= 0)
            {
                Instantiate(dashParticles, new Vector2(this.transform.position.x + 0.5f, this.transform.position.y), Quaternion.identity);
                timer3 = particle_delay;
            } else
            {
                timer3 -= Time.deltaTime;
            }
            this.GetComponent<PolygonCollider2D>().enabled = false;
            //Debug.Log("Invulnerable");
            timer2 -= Time.deltaTime;
        }

        if (timer <= 0) //Delay entre dash
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255, 140, 0, this.GetComponent<SpriteRenderer>().color.a);
            if ((Input.GetButtonDown("R2") || Input.GetButtonDown("L2") || Input.GetKeyDown("space")) && this.GetComponent<movement>().isMoving)
            {
                rb.velocity = this.GetComponent<movement>().lastMoveDir * dashDistance;
                timer = dashDelay;
                timer2 = dashTime;
                FindObjectOfType<AudioManagerController>().AudioPlay("PlayerDash");
            }
        } else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, this.GetComponent<SpriteRenderer>().color.a);
            timer -= Time.deltaTime;
        }
    }
}