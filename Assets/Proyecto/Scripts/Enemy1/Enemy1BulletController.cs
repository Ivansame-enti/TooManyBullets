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

    public float scaleTime;
    public GameObject destroyPS;
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
        //this.transform.localScale += new Vector3(50f, 50f, 50f);
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
            StartCoroutine(ScaleOverTime(scaleTime));
            //Debug.Log(collision.transform.localScale);
            //transform.localScale += new Vector3(50f, 50f, 50f);
            //Debug.Log("Nuevo: " + collision.transform.localScale);
            //collision.gameObject.transform.localScale = new
            //Destroy(gameObject);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        //Destroy(gameObject);
        Debug.Log("colision");
    }

    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3(0.0f, 0.0f, 0.0f);
        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        float currentTime = 0.0f;

        do
        {
            this.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        Instantiate(destroyPS, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
