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
    public bool hitPlayer = false;
    private float timer;
    public float knockbackDuration;
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
        playerPos = GameObject.FindGameObjectWithTag("PlayerTag").transform;
        Vector3 direction = playerPos.position - this.transform.position;
        Vector3 aux = direction;
        direction.Normalize();
        movement = direction;
        if (!hitPlayer) transform.Rotate(0, 0, speedRotation * Time.deltaTime);

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
                Debug.Log(aux);
                rb.AddForce(-movement * 50 * Time.deltaTime, ForceMode2D.Impulse);
                transform.Rotate(0, 0, -speedRotation * Time.deltaTime);
            }

        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.01f, 0.99f);
        pos.y = Mathf.Clamp(pos.y, 0.02f, 0.98f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void FixedUpdate()
    {
        if (!hitPlayer) rb.MovePosition((Vector2)transform.position + (movement * movementSpeed * Time.deltaTime));
    }
}
