using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public Animator shakeCamera;
    public float inmortalTime;
    public float blinkTime;
    private float timer;
    private float timer2;
    public GameObject deathPS;

    private void dealDamage()
    {
        if (timer <= 0)
        {
            currentHealth--;
            shakeCamera.SetTrigger("Shake");
            timer = inmortalTime;
            Time.timeScale = 0.2f;
            if (currentHealth > 0) FindObjectOfType<AudioManagerController>().AudioPlay("PlayerHit");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > 0) //Tiempo donde es imnnune porque le han golpeado
        {
            if(Time.timeScale < 1.0f && currentHealth > 0)
            {
                Time.timeScale += Time.deltaTime;
            }
            
            if(timer2 <= 0) // Timer que controla el parpadeo que inndica la inmortalidad
            {
                if (this.GetComponent<SpriteRenderer>().color.a == 0f)
                {
                    this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 1f);
                } else
                {
                    this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 0f);
                }
                timer2 = blinkTime;
            } else
            {
                timer2 -= Time.deltaTime;
            }

            timer -= Time.deltaTime;
        } else //Vuelve a la normalidad
        {
            Time.timeScale = 1.0f;
            this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 1f);
        }

        //Debug.Log("Vida" + currentHealth);
        //Debug.Log(Time.timeScale);

        if(currentHealth <= 0)
        {
            FindObjectOfType<AudioManagerController>().AudioPlay("PlayerDeath");
            Time.timeScale = 1.0f;
            Instantiate(deathPS, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet") dealDamage();
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "LaserCollider") dealDamage();
    }
}
