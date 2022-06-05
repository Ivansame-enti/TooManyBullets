using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyHealthController : MonoBehaviour
{
    public float health;
    private float maxHealth;
    public GameObject hitPS;
    public GameObject deathPS,deathPS2;
    public GameObject swPs,swPs2;
    public HealthBarController healthBar;
    public LevelEndingController ending;
    public bool inmortal = false;
    public int probabilidad;
    private int numAleatorio;
    private bool firstTime;
    public bool specialEnemy=false, comboPlus;
    public bool antiSlash = false;
    public GameObject specialParticles;
    public GameObject specialParticles2;
    private bool level1;
    private bool level2;
    private bool mainMenu;
    private AudioManagerController audioSFX;
    private ScoreSystem puntuation;
    
    //private GameObject a;
    //public GameObject circle;
    // Start is called before the first frame update
    void Start()
    {


        audioSFX = FindObjectOfType<AudioManagerController>();
        if (SceneManager.GetActiveScene().name != "Nivel1") level1 = false;
        else level1 = true;

        if (SceneManager.GetActiveScene().name != "Nivel2") level2 = false;
        else level2 = true;

        if (SceneManager.GetActiveScene().name != "MainMenu") mainMenu = false;
        else mainMenu = true;

        //specialEnemy = false;
        probabilidad = 11;
        firstTime = true;
        //if(GameObject.FindGameObjectWithTag("ending")!=null) ending = GameObject.FindGameObjectWithTag("ending").GetComponent<LevelEndingController>();
        maxHealth = health;
        if (ending != null) ending.AddEnnemy(this.gameObject);

        if (mainMenu == false && level1 == false && level2 == false)
        {
            puntuation = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>();
            //multi = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ComboMultiplier>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (firstTime)
        {
            numAleatorio = Random.Range(1, probabilidad);
            //Debug.Log(numAleatorio);
            if(numAleatorio == 1 && !level1 && !level2 && !mainMenu)
            {
                specialEnemy = true;
                
            }

            if (specialEnemy)
            {
                var particle = Instantiate(specialParticles, this.transform.position, Quaternion.identity);
                particle.transform.parent = this.transform;
            }
            firstTime = false;
        }
        ///Debug.Log(health);
        if (health <= 0)
        {
            if (mainMenu == false && level1 == false && level2 == false)
            {
                //puntuation.enemyTransform = this.transform;   
                puntuation.pentakill++;
                puntuation.enemyKilled = true;
                if (puntuation.pentakill == 1)
                {
                    ScoreSystem.score += 10000;
                }
                else if (puntuation.pentakill > 1)
                {
                    ScoreSystem.score += 10000 * puntuation.pentakill;
                }
                puntuation.enemy(this.transform);
            }

            
            
            
            if (specialEnemy)
            {
                //particle.transform.parent = null;
                //particle.transform.position = Vector3.MoveTowards(particle.transform.position, new Vector3(5f,5f,0f), Time.deltaTime * 5f);
                Instantiate(specialParticles2, this.transform.position, Quaternion.identity);
                //GameObject.Find("MiniJoe").GetComponent<MiniJoeHealController>().currenntHealsAvailable++;
            }
            if(this.name == "Enemy3") if (audioSFX.GetAudioPlaying("EnemyLaser")) audioSFX.AudioStop("EnemyLaser");
            if (ending != null) ending.EnemyDies(this.gameObject);
            if (transform.parent != null && transform.parent.gameObject.tag == "container")
                Destroy(this.transform.parent.gameObject);
            else Destroy(this.gameObject);
            Instantiate(deathPS, this.transform.position, Quaternion.identity);
            //Instantiate(deathPS2, this.transform.position, Quaternion.identity);
            //Instantiate(swPs, this.transform.position, Quaternion.identity);
            //Instantiate(swPs2, this.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Death"); 
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
                healthBar.SetHealthBar(health, maxHealth);
                if (health > 0) FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Hit");
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Shield"))
        {
            if (this.gameObject.name == "Enemy2" || this.gameObject.name == "Enemy22" || this.gameObject.name == "Enemy23")
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
                this.gameObject.GetComponent<MeleeEnemyController>().hitPlayer = true;
                var force = transform.position - collision.transform.position;
                force.Normalize();
                GetComponent<Rigidbody2D>().AddForce(force * 500);
                //col.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * 500);
            }
        }

        if (collision.tag == "slash" && !antiSlash)
        {
            if (!inmortal)
            {
                Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
                health = health - collision.gameObject.GetComponent<MeleeAttackController>().damage;
                healthBar.SetHealthBar(health, maxHealth);
            }
            if (this.gameObject.name == "Enemy2" || this.gameObject.name == "Enemy22" || this.gameObject.name == "Enemy23")
            {
                //GetComponent<Rigidbody2D>().AddForce(new Vector2(0,0));
                this.gameObject.GetComponent<MeleeEnemyController>().hitPlayer = true;
                var force = transform.position - collision.transform.position;
                force.Normalize();
                GetComponent<Rigidbody2D>().AddForce(force * 500);
            }
            if (health > 0) FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Hit");
        }
        if (collision.tag == "MjLaserCollider")
        {
            if (!inmortal)
            {
                Instantiate(hitPS, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
                health = health - collision.gameObject.GetComponent<mJLaserDamage>().LaserDamage;
                healthBar.SetHealthBar(health, maxHealth);
            }
            //if (health > 0) FindObjectOfType<AudioManagerController>().AudioPlay("Enemy1Hit");
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((this.gameObject.name == "Enemy2" || this.gameObject.name == "Enemy22" || this.gameObject.name == "Enemy23") && col.collider.tag == "LaserCollider")
        {
            this.gameObject.GetComponent<MeleeEnemyController>().hitPlayer = true;
            var force = transform.position - col.transform.position;
            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * 500);
            
        }
    }
    /*
    private void OnCollisionExit2D(Collision2D col)
    {
        //if (this.gameObject.name == "Enemy2" && col.collider.tag == "LaserCollider") this.GetComponent<PolygonCollider2D>().enabled = true;
    }*/

}
