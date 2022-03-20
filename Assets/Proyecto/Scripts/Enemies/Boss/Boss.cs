using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject player;
    public GameObject leftEye, rightEye;
    public PlayerHealthController playerH;
    public BossLaser bossLaser;
    public BossHealthController bossHealth;
    public GameObject laser,bullets,waterDrop,multiLaser,irisL,irisR;
    private Color irisColor;
    public float speed;
    private int attack;
    private bool startPhase2,cooldownOn;
    private float timer,timer2;
    public float bulletsDuration,dropDuration,multiLaserDuration,cooldownAttack;
    public bool bulletGoing;
    private GameObject[] water;

    // Start is called before the first frame update
    void Start()
    {
        attack = Random.Range(1,5);
        bullets.SetActive(false);
        waterDrop.SetActive(false);
        irisColor = irisL.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerH.dead == false)
        {
            leftEye.transform.position = Vector2.MoveTowards(leftEye.transform.position, player.transform.position, speed * Time.deltaTime);
            rightEye.transform.position = Vector2.MoveTowards(rightEye.transform.position, player.transform.position, speed * Time.deltaTime);
        }
            if(bossHealth.health >= bossHealth.maxHealth / 2)
            {
                if (attack == 1)
                {
                    laser.SetActive(true);
                    if (bossLaser.finish == true)
                    {
                        laser.SetActive(false);
                        cooldownOn = true;
                    }
                    if (timer >= cooldownAttack && cooldownOn == true)
                    {
                        attack = Random.Range(1, 5);
                        cooldownOn = false;
                        timer = 0;
                        bossLaser.finish = false;
                        if (attack == 1)
                        {
                            attack = Random.Range(1, 5);
                        }
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
                if (attack == 2)
                {
                colorChange();
                if (timer2 >= 2)
                {
                    bullets.SetActive(true);

                    if (timer >= bulletsDuration)
                    {
                        bullets.SetActive(false);
                        originalChange();

                    }
                    if (timer >= bulletsDuration + cooldownAttack)
                    {
                        attack = Random.Range(1, 5);
                        
                        timer = 0;
                        timer2 = 0;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
                else
                {
                    timer2 += Time.deltaTime;
                }
            }

                if (attack == 3)
                {
                    waterDrop.SetActive(true);
                    if (timer >= dropDuration)
                    {
                        waterDrop.SetActive(false);

                }
                    if (timer >= dropDuration + cooldownAttack)
                    {
                        attack = Random.Range(1, 5);
                    water = GameObject.FindGameObjectsWithTag("EnemyBullet");

                    foreach (GameObject bullet in water)
                    {
                        Destroy(bullet);
                    }
                    timer = 0;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }

                if (attack == 4)
                {
                    multiLaser.SetActive(true);
                    if (timer >= multiLaserDuration)
                    {
                        multiLaser.SetActive(false);
                    }
                    if (timer >= multiLaserDuration + cooldownAttack)
                    {
                        attack = Random.Range(1, 5);
                        if (attack == 4)
                        {
                            attack = Random.Range(1, 5);
                        }
                        timer = 0;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
            }
            if (bossHealth.health < bossHealth.maxHealth / 2 && startPhase2 == false)
            {
                startPhase2 = true;
                bullets.SetActive(false);
                laser.SetActive(false);
                multiLaser.SetActive(false);
                attack = Random.Range(1,5);
                bossHealth.originalColor = new Color(255, 0, 0);
            originalChange();
        }
            if (bossHealth.health < bossHealth.maxHealth / 2 && startPhase2 == true)
            {
                if (attack == 1)
                {
                colorChange();
                if (timer2 >= 2)
                {
                    bullets.SetActive(true);
                    laser.SetActive(true);
                    if (timer >= bulletsDuration)
                    {
                        bullets.SetActive(false);
                        originalChange();
                    }
                    if (bossLaser.finish == true)
                    {
                        laser.SetActive(false);

                    }
                    if (timer >= bulletsDuration + cooldownAttack && bossLaser.finish == true)
                    {
                        attack = Random.Range(1, 5);
                        timer = 0;
                        timer2 = 0;
                        bossLaser.finish = false;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
                else
                {
                    timer2 += Time.deltaTime;
                }
            }
                if (attack == 2)
                {
                    multiLaser.SetActive(true);
                    waterDrop.SetActive(true);
                    if (timer >= multiLaserDuration)
                    {
                        multiLaser.SetActive(false);
                        waterDrop.SetActive(false);
                    }
                    if (timer >= multiLaserDuration + cooldownAttack + 5)
                    {
                        attack = Random.Range(1, 5);
                    water = GameObject.FindGameObjectsWithTag("EnemyBullet");

                    foreach (GameObject bullet in water)
                    {
                        Destroy(bullet);
                    }
                    timer = 0;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }

            if (attack == 3)
            {
                colorChange();
                if (timer2 >= 2)
                {
                    bullets.SetActive(true);
                    waterDrop.SetActive(true);
                    if (timer >= bulletsDuration)
                    {
                        bullets.SetActive(false);
                        waterDrop.SetActive(false);
                        originalChange();
                    }
                    if (timer >= bulletsDuration + cooldownAttack)
                    {
                        attack = Random.Range(1, 5);
                        water = GameObject.FindGameObjectsWithTag("EnemyBullet");

                        foreach (GameObject bullet in water)
                        {
                            Destroy(bullet);
                        }
                        timer = 0;
                        timer2 = 0;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
                else
                {
                    timer2 += Time.deltaTime;
                }
            }
            if (attack == 4)
            {
                multiLaser.SetActive(true);
                laser.SetActive(true);
                if (timer >= multiLaserDuration)
                {
                    multiLaser.SetActive(false);
                }
                if (bossLaser.finish == true)
                {
                    laser.SetActive(false);

                }
                if (timer >= multiLaserDuration + cooldownAttack + 5 && bossLaser.finish == true)
                {
                    attack = Random.Range(1, 5);
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }



        }
    public void colorChange()
    {
        bulletGoing = true;
        irisL.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, irisL.GetComponent<SpriteRenderer>().color.a);
        irisR.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, irisR.GetComponent<SpriteRenderer>().color.a);


    }
    public void originalChange()
    {
        bulletGoing = false;
        irisL.GetComponent<SpriteRenderer>().color = irisColor;
        irisR.GetComponent<SpriteRenderer>().color = irisColor;
    }
}
