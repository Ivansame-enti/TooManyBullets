using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashDistance;
    public GameObject dashParticles;
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

        if (Input.GetButtonDown("R2") || Input.GetButtonDown("L2"))
        {
            //isDashing = true;
            //Debug.Log("a");
            this.transform.position += this.GetComponent<movement>().lastMoveDir * dashDistance;
            //Instantiate();
            //rb.velocity += this.GetComponent<movement>().lastMoveDir * 5f;
        }
    }
}