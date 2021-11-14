using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1BulletController : MonoBehaviour
{
    /*
    public float bulletSpeed;
    Vector2 direction;
    private Rigidbody2D rb;
    private float target;*/

    public float lifeSpan;
    /*public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeSpan);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }
}
