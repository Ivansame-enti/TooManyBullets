using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public float speedRotation;
    public float movementSpeed;
    private Transform playerPos;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 aux;
    public bool hitPlayer = false;
    private float timer;
    public float knockbackDuration;
    public float knockbackDistance;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        timer = knockbackDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("PlayerTag") != null)
        {
            playerPos = GameObject.FindGameObjectWithTag("PlayerTag").transform;
            Vector3 direction = playerPos.position - this.transform.position;
            aux = direction;
            direction.Normalize();
            movement = direction;
            if (!hitPlayer) transform.Rotate(0, 0, speedRotation * Time.deltaTime);

            //Debug.Log(movement);

            if (hitPlayer)
            {
                if (timer <= 0)
                {
                    hitPlayer = false;
                    timer = knockbackDuration;
                    flag = false;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = 0f;
                }
                else
                {
                    timer -= Time.deltaTime;
                    rb.AddForce(-movement * knockbackDistance * Time.deltaTime, ForceMode2D.Impulse);
                    /*var force = transform.position - playerPos.position;
                    force.Normalize();
                    GetComponent<Rigidbody2D>().AddForce(force * knockbackDistance);
                    transform.Rotate(0, 0, -speedRotation * Time.deltaTime);*/
                }

            }

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, 0.01f, 0.99f);
            pos.y = Mathf.Clamp(pos.y, 0.02f, 0.98f);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }

    private void FixedUpdate()
    {
        if (!hitPlayer) rb.AddForce(aux * movementSpeed * Time.deltaTime); //rb.MovePosition((Vector2)transform.position + (movement * movementSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Enemy2")
        {
            var force = transform.position - col.transform.position;
            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * 500);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * 500);
        }
    }
}
