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

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("DestroyBulletCollider"))
        {
            //StartCoroutine(ScaleOverTime(1, collision));
            //collision.gameObject.transform.localScale = new
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Shield"))
        {
            //Debug.Log("a");
            //StartCoroutine(ScaleOverTime(1, collision));
            collision.gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //collision.gameObject.transform.localScale = new
            //Destroy(gameObject);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        //Destroy(gameObject);
        Debug.Log("colision");
    }

    IEnumerator ScaleOverTime(float time, Collider2D collision)
    {
        Vector3 originalScale = collision.transform.localScale;
        Vector3 destinationScale = new Vector3(0.0f, 0.0f, 0.0f);
        float currentTime = 0.0f;

        do
        {
            //originalScale.x -= Time.deltaTime;
            //originalScale.y -= Time.deltaTime;
            collision.transform.localScale = destinationScale;
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        Destroy(collision.gameObject);
    }
}
