using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public GameObject hitPS;
    public GameObject deathPS;
    public HealthBarController healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;    
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy(this.gameObject);
            Instantiate(deathPS, this.transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown("space"))
        {
            Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
            health--;
            healthBar.SetHealthBar(health, maxHealth);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
        //health = 0;
    }
}
