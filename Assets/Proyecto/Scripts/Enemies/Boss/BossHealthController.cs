using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthController : MonoBehaviour
{
    private bool hit;
    private float timer,hitColor = 0.1f;
    public float health,maxHealth;
    public GameObject hitPS;
    public GameObject deathPS, deathPS2;
    public GameObject swPs, swPs2;
    public bool inmortal = false;
    public GameObject superiorFace, inferiorFace,mouth;
    public Color originalColor;
    public Boss boss;
    public VictoryController victory;
    
    // Start is called before the first frame update
    void Start()
    {
        originalColor = superiorFace.GetComponent<SpriteRenderer>().color;
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(hit == true)
        {
            superiorFace.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, superiorFace.GetComponent<SpriteRenderer>().color.a);
            inferiorFace.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, inferiorFace.GetComponent<SpriteRenderer>().color.a);
            mouth.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, mouth.GetComponent<SpriteRenderer>().color.a);
            if (timer >= hitColor)
            {
                superiorFace.GetComponent<SpriteRenderer>().color = originalColor;
                inferiorFace.GetComponent<SpriteRenderer>().color = originalColor;
                mouth.GetComponent<SpriteRenderer>().color = originalColor;
                hit = false;
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        




        }

        if (health <= 0)
        {
            if (transform.parent != null && transform.parent.gameObject.tag == "container")
                Destroy(this.transform.parent.gameObject);
            else Destroy(this.gameObject);
            Instantiate(deathPS, this.transform.position, Quaternion.identity);
            Instantiate(deathPS2, this.transform.position, Quaternion.identity);
            Instantiate(swPs, this.transform.position, Quaternion.identity);
            Instantiate(swPs2, this.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Death");
            victory.victory = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bala")
        {
            if (!inmortal)
            {
                Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
                health = health - collision.gameObject.GetComponent<bullet>().damage;
                hit = true;
                if (health > 0) FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Hit");
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Shield"))
        {
            if (this.gameObject.name == "Enemy2") this.gameObject.GetComponent<MeleeEnemyController>().hitPlayer = true;
        }

        if (collision.tag == "slash")
        {
            if (!inmortal)
            {
                Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
                health = health - collision.gameObject.GetComponent<MeleeAttackController>().damage;
                hit = true;
            }
            if (this.gameObject.name == "Enemy2") this.gameObject.GetComponent<MeleeEnemyController>().hitPlayer = true;
            if (health > 0) FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Hit");
        }
        if (collision.tag == "MjLaserCollider")
        {
            if (!inmortal)
            {
                Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
                health = health - collision.gameObject.GetComponent<mJLaserDamage>().LaserDamage;
                hit = true;
            }
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
