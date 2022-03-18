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
    public GameObject laser,bullets,waterDrop,multiLaser;
    public float speed;
    private int attack;
    private bool startPhase2,cooldownOn,bulletAnim;
    private float timer;
    public float bulletsDuration,dropDuration,multiLaserDuration,cooldownAttack;
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        attack = Random.Range(1, 5);
        bullets.SetActive(false);
        waterDrop.SetActive(false);
        anim = gameObject.GetComponent<Animation>();
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
                if(bulletAnim == false)
                {
                    this.GetComponent<Animator>().SetBool("flag", true);
                }

                if(bulletAnim == true)
                {
                    bullets.SetActive(true);
                    if (timer >= bulletsDuration)
                    {
                        bullets.SetActive(false);
                    }
                    if (timer >= bulletsDuration + cooldownAttack)
                    {
                        attack = Random.Range(1, 5);
                        timer = 0;
                        bulletAnim = false;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }

            }

                if (attack == 3)
                {
                    waterDrop.SetActive(true);
                    if (timer >= dropDuration)
                    {
                        waterDrop.SetActive(false);
                    }

                    if (timer >= dropDuration + cooldownAttack + 5)
                    {
                        attack = Random.Range(1, 5);
                        if (attack == 3)
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
            }
            if (bossHealth.health < bossHealth.maxHealth / 2 && startPhase2 == true)
            {
                if (attack == 1)
                {
                    bullets.SetActive(true);
                    laser.SetActive(true);
                if (timer >= bulletsDuration)
                    {
                        bullets.SetActive(false);
                }
                if (bossLaser.finish == true)
                {
                    laser.SetActive(false);
                    
                }
                if (timer >= bulletsDuration + cooldownAttack)
                    {
                        attack = Random.Range(1, 5);
                        timer = 0;
                        bossLaser.finish = false;
                }
                    else
                    {
                        timer += Time.deltaTime;
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
                        timer = 0;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }

            if (attack == 3)
            {
                bullets.SetActive(true);
                waterDrop.SetActive(true);
                if (timer >= bulletsDuration)
                {
                    bullets.SetActive(false);
                    waterDrop.SetActive(false);
                }
                if (timer >= bulletsDuration + cooldownAttack)
                {
                    attack = Random.Range(1,5);
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
                bullets.SetActive(true);
                if (timer >= multiLaserDuration)
                {
                    multiLaser.SetActive(false);
                    bullets.SetActive(false);
                }
                if (timer >= multiLaserDuration + cooldownAttack + 5)
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

    public void AlertObservers(string message)
    {
        if (message.Equals("AttackAnimationEnded"))
        {
            this.GetComponent<Animator>().SetBool("flag", false);
            bulletAnim = true;
        }
    }
}
