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
    public GameObject laser, bullets, waterDrop, multiLaser, irisL, irisR;
    private Color irisColor;
    public float speed;
    private int attack;
    private bool startPhase2, cooldownOn;
    private float timer, timer2;
    public float bulletsDuration, dropDuration, multiLaserDuration, cooldownAttack;
    public bool bulletGoing;
    private GameObject[] water;
    private AudioManagerController audioSFX;
    private PauseController pc;
    private bool bossStart,multiLaserFinish;
    public CelestialAttack cA;
    public int numLaser,numLaser2Phase;
    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PauseController>();
        audioSFX = FindObjectOfType<AudioManagerController>();
        attack = Random.Range(1, 5);
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
        if (bossHealth.health >= bossHealth.maxHealth / 2 && bossStart == true)
        {
            if (attack == 1)
            {                
                laser.SetActive(true);
                if (!audioSFX.GetAudioPlaying("EnemyLaser") && pc.pauseState == false) audioSFX.AudioPlay("EnemyLaser");
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
            } else if (audioSFX.GetAudioPlaying("EnemyLaser")) audioSFX.AudioStop("EnemyLaser");
            if (attack == 2)
            {
                if (!audioSFX.GetAudioPlaying("MachineGun") && pc.pauseState == false) audioSFX.AudioPlay("MachineGun");
                colorChange();
                if (timer2 >= 2)
                {
                    bullets.SetActive(true);

                    if (timer >= bulletsDuration)
                    {
                        if (audioSFX.GetAudioPlaying("MachineGun")) audioSFX.AudioStop("MachineGun");
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
                    if (!audioSFX.GetAudioPlaying("Bloops") && pc.pauseState == false) audioSFX.AudioPlay("Bloops");
                    waterDrop.SetActive(false);
                    //audio.AudioStop("Bloops");
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
                    if (audioSFX.GetAudioPlaying("Bloops")) audioSFX.AudioStop("Bloops");
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }

            if (attack == 4)
            {
                //audio.AudioPlay("Laser");
                if(multiLaserFinish == false)
                {
                    multiLaser.SetActive(true);
                    timer = 0;
                }
                
                if(cA.laserTimes == numLaser)
                {
                    multiLaser.SetActive(false);
                    multiLaserFinish = true;
                }
                if (timer >= cooldownAttack && multiLaserFinish == true)
                {
                    cA.laserTimes = 0;
                    attack = Random.Range(1, 5);
                    multiLaserFinish = false;
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        if (bossHealth.health < bossHealth.maxHealth / 3 && startPhase2 == false && bossStart == true)
        {
            if (audioSFX.GetAudioPlaying("EnemyLaser")) audioSFX.AudioStop("EnemyLaser");
            if (audioSFX.GetAudioPlaying("Bloops")) audioSFX.AudioStop("Bloops");
            startPhase2 = true;
            bullets.SetActive(false);
            laser.SetActive(false);
            multiLaser.SetActive(false);
            attack = Random.Range(1, 5);
            bossHealth.originalColor = new Color(255, 0, 0);
            originalChange();
        }
        if (bossHealth.health < bossHealth.maxHealth / 2 && startPhase2 == true)
        {
            if (attack == 1)
            {
                if (!audioSFX.GetAudioPlaying("MachineGun") && pc.pauseState == false) audioSFX.AudioPlay("MachineGun");
                colorChange();
                if (timer2 >= 2)
                {
                    if (!audioSFX.GetAudioPlaying("EnemyLaser") && pc.pauseState == false) audioSFX.AudioPlay("EnemyLaser");
                    bullets.SetActive(true);
                    laser.SetActive(true);
                    if (timer >= bulletsDuration)
                    {
                        if (audioSFX.GetAudioPlaying("MachineGun")) audioSFX.AudioStop("MachineGun");
                        bullets.SetActive(false);
                        originalChange();
                    }
                    if (bossLaser.finish == true)
                    {
                        laser.SetActive(false);
                        if (audioSFX.GetAudioPlaying("EnemyLaser")) audioSFX.AudioStop("EnemyLaser");
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
                if (multiLaserFinish == false)
                {
                    if (!audioSFX.GetAudioPlaying("Bloops") && pc.pauseState == false) audioSFX.AudioPlay("Bloops");
                    multiLaser.SetActive(true);
                    waterDrop.SetActive(true);
                    timer = 0;
                }

                if (cA.laserTimes == numLaser2Phase)
                {
                    multiLaser.SetActive(false);
                    waterDrop.SetActive(false);
                    multiLaserFinish = true;
                }
                if (timer >= cooldownAttack && multiLaserFinish == true)
                {
                    cA.laserTimes = 0;
                    attack = Random.Range(1, 5);
                    multiLaserFinish = false;
                    water = GameObject.FindGameObjectsWithTag("EnemyBullet");
                    foreach (GameObject bullet in water)
                    {
                        Destroy(bullet);
                    }
                    if (audioSFX.GetAudioPlaying("Bloops")) audioSFX.AudioStop("Bloops");
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }

            if (attack == 3)
            {
                if (!audioSFX.GetAudioPlaying("MachineGun") && pc.pauseState == false) audioSFX.AudioPlay("MachineGun");
                colorChange();
                if (timer2 >= 2)
                {
                    bullets.SetActive(true);
                    waterDrop.SetActive(true);
                    if (!audioSFX.GetAudioPlaying("Bloops") && pc.pauseState == false) audioSFX.AudioPlay("Bloops");
                    if (timer >= bulletsDuration)
                    {
                        if (audioSFX.GetAudioPlaying("MachineGun")) audioSFX.AudioStop("MachineGun");
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
                        if (audioSFX.GetAudioPlaying("Bloops")) audioSFX.AudioStop("Bloops");
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
                //audio.AudioPlay("Laser");

                if (bossLaser.finish == false)
                {
                    if (!audioSFX.GetAudioPlaying("EnemyLaser") && pc.pauseState == false) audioSFX.AudioPlay("EnemyLaser");
                    laser.SetActive(true);
                    timer = 0;
                }
                if (bossLaser.finish == true)
                {
                    laser.SetActive(false);
                    if (audioSFX.GetAudioPlaying("EnemyLaser")) audioSFX.AudioStop("EnemyLaser");
                }

                if (multiLaserFinish == false)
                {
                    multiLaser.SetActive(true);
                    timer = 0;
                }

                if (cA.laserTimes == numLaser2Phase)
                {
                    multiLaser.SetActive(false);
                    multiLaserFinish = true;
                }
                if (timer >= cooldownAttack && multiLaserFinish == true)
                {
                    cA.laserTimes = 0;
                    attack = Random.Range(1, 5);
                    multiLaserFinish = false;
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

    public void AlertObservers(string message)
    {
        if (message.Equals("bossStart"))
        {
            bossStart = true;
        }
    }

}
