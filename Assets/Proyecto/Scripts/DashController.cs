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
    /*public float dashSpeed;
    private float timer;
    public float dashDistance;
    private bool isDashing=false;
    public GameObject targetDash;*/


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //timer = dashDistance;
        timer = dashDelay;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!isDashing) {
            if (Input.GetButtonDown("R2") || Input.GetButtonDown("L2"))
            {
                isDashing = true;
            }
        }
        else
        {
            if (timer <= 0)
            {
                isDashing=false;
                timer = dashDistance;
                rb.velocity = Vector2.zero;
            } else
            {
                timer -= Time.deltaTime;
                rb.velocity = targetDash.transform.position * dashSpeed;
            }
        }*/

        if (timer2 <= 0)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            timer2 -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            if ((Input.GetButtonDown("R2") || Input.GetButtonDown("L2")) && this.GetComponent<movement>().isMoving)
            {
                //isDashing = true;
                //Debug.Log("a");
                rb.velocity = this.GetComponent<movement>().lastMoveDir * dashDistance;
                //this.transform.position += this.GetComponent<movement>().lastMoveDir * dashDistance;
                Instantiate(dashParticles, new Vector2(this.transform.position.x + 0.5f, this.transform.position.y), Quaternion.identity);
                //particles.transform.parent = gameObject.transform;
                //rb.velocity += this.GetComponent<movement>().lastMoveDir * 5f;
                timer = dashDelay;
                timer2 = dashTime;
            }
        } else
        {
            timer -= Time.deltaTime;
        }
    }
}