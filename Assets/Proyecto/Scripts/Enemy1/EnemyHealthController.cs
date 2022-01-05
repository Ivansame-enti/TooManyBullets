using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public GameObject hitPS;
    public GameObject deathPS;
    public GameObject swPs;
    public HealthBarController healthBar;
    public LevelEndingController ending; 

    // Start is called before the first frame update
    void Start()
    {
        //if(GameObject.FindGameObjectWithTag("ending")!=null) ending = GameObject.FindGameObjectWithTag("ending").GetComponent<LevelEndingController>();
        maxHealth = health;
        if (ending != null) ending.AddEnnemy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ///Debug.Log(health);

        if (health <= 0) {
            if(ending!=null) ending.EnemyDies(this.gameObject);
            if (transform.parent != null && transform.parent.gameObject.tag == "container")
                Destroy(this.transform.parent.gameObject);     
            else Destroy(this.gameObject);
            Instantiate(deathPS, this.transform.position, Quaternion.identity);
            Instantiate(swPs, this.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Death");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bala")
        {
            Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
            health = health - collision.gameObject.GetComponent<bullet>().damage;
            healthBar.SetHealthBar(health, maxHealth);
            if (health > 0) FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Hit");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Shield"))
        {
            if (this.gameObject.name == "Enemy2") this.gameObject.GetComponent<MeleeEnemyController>().hitPlayer = true;
        }

        if (collision.tag == "slash")
        {
            Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
            health = health - collision.gameObject.GetComponent<MeleeAttackController>().damage;
            healthBar.SetHealthBar(health, maxHealth);
            if(this.gameObject.name == "Enemy2") this.gameObject.GetComponent<MeleeEnemyController>().hitPlayer = true;
            if (health > 0) FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Hit");
        }
        if (collision.tag == "MjLaserCollider")
        {
            Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
            health = health - collision.gameObject.GetComponent<mJLaserDamage>().LaserDamage;
            healthBar.SetHealthBar(health, maxHealth);
            //if (health > 0) FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Hit");
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (this.gameObject.name == "Enemy2" && col.collider.tag == "LaserCollider")
        {
            if (this.gameObject.name == "Enemy2") this.gameObject.GetComponent<MeleeEnemyController>().hitPlayer = true;
        }
    }
    /*
    private void OnCollisionExit2D(Collision2D col)
    {
        //if (this.gameObject.name == "Enemy2" && col.collider.tag == "LaserCollider") this.GetComponent<PolygonCollider2D>().enabled = true;
    }*/

}
