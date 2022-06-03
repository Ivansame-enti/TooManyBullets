using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public Animator shakeCamera;
    public float inmortalTime;
    public float blinkTime;
    private float timer;
    private float timer2;
    public GameObject deathPS, lowHealthPanel;
    private bool hitInmunity;
    public bool dead;
    public PauseController pause;
    private AudioManagerController audioManager;
    private ScoreSystem puntuation;
    private bool level1;
    private bool level2;
    private bool mainMenu;

    private void dealDamage()
    {
        //if (timer <= 0)
        //{
        //Si se estaba curando

        if (currentHealth > 0 && currentHealth < 1)
        {
            currentHealth = 0;
            GameObject.Find("MiniJoe").GetComponent<MiniJoeHealController>().currenntHealsAvailable = GameObject.Find("MiniJoe").GetComponent<MiniJoeHealController>().lastCurrentHeals;
        }
        if (currentHealth > 1 && currentHealth < 2)
        {
            currentHealth = 1;
            GameObject.Find("MiniJoe").GetComponent<MiniJoeHealController>().currenntHealsAvailable = GameObject.Find("MiniJoe").GetComponent<MiniJoeHealController>().lastCurrentHeals;
        }
        if (currentHealth > 2 && currentHealth < 3)
        {
            currentHealth = 2;
            GameObject.Find("MiniJoe").GetComponent<MiniJoeHealController>().currenntHealsAvailable = GameObject.Find("MiniJoe").GetComponent<MiniJoeHealController>().lastCurrentHeals;
        }

        currentHealth--;
        shakeCamera.SetTrigger("Shake");
        if (mainMenu == false && level1 == false && level2 == false)
        {
            ScoreSystem.score -= ScoreSystem.score * 50 / 100;
            puntuation.TakeDamage();
            //multi = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ComboMultiplier>();
        }
        
        timer = inmortalTime;
        Time.timeScale = 0.2f;
        if (currentHealth > 0) audioManager.AudioPlay("PlayerHit");
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        audioManager = FindObjectOfType<AudioManagerController>();

        if (SceneManager.GetActiveScene().name != "Nivel1") level1 = false;
        else level1 = true;

        if (SceneManager.GetActiveScene().name != "Nivel2") level2 = false;
        else level2 = true;

        if (SceneManager.GetActiveScene().name != "MainMenu") mainMenu = false;
        else mainMenu = true;

        if (mainMenu == false && level1 == false && level2 == false)
        {
            puntuation = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>();
            //multi = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ComboMultiplier>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            currentHealth = health;
        }

        if (timer > 0) //Tiempo donde es imnnune porque le han golpeado
        {
            if (Time.timeScale < 1.0f && currentHealth > 0 && pause.pauseState != true)
            {
                Time.timeScale += Time.deltaTime;
                hitInmunity = true;

            }

            if (timer2 <= 0) // Timer que controla el parpadeo que inndica la inmortalidad
            {
                if (this.GetComponent<SpriteRenderer>().color.a == 0f)
                {
                    this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 1f);
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 0f);
                }
                timer2 = blinkTime;
            }
            else
            {
                timer2 -= Time.deltaTime;
            }

            timer -= Time.deltaTime;
        }
        else //Vuelve a la normalidad
        {
            if (hitInmunity == true)
            {
                Time.timeScale = 1.0f;
                hitInmunity = false;
            }

            this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 1f);
        }

        //Debug.Log("Vida" + currentHealth);
        //Debug.Log(Time.timeScale);

        if (currentHealth <= 0)
        {
            audioManager.AudioPlay("PlayerDeath");
            Time.timeScale = 1.0f;
            Instantiate(deathPS, this.transform.position, Quaternion.identity);
            dead = true;
            Destroy(this.gameObject);

        }
        if (currentHealth < 2)
        {
            lowHealthPanel.SetActive(true);
        }
        else
        {
            lowHealthPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer <= 0)
        {
            if (collision.tag == "EnemyBullet")
            {
                dealDamage();
                Destroy(collision.gameObject);
            }

            if (collision.tag == "LaserColliderEnemy") dealDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (timer <= 0)
        {
            if (col.collider.tag == "LaserCollider") dealDamage();
        }

        if (col.collider.tag == "enemy" && (col.gameObject.name == "Enemy2" || col.gameObject.name == "Enemy22" || col.gameObject.name == "Enemy23"))
        {
            col.gameObject.GetComponent<MeleeEnemyController>().hitPlayer = true;
            if (timer <= 0) dealDamage();
        }
    }
}
