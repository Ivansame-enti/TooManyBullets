using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject player;
    public GameObject leftEye, rightEye;
    public PlayerHealthController playerH;
    public BossLaser bossLaser;
    public GameObject laser,bullets,waterDrop;
    public float speed;
    private int attack;
    private float timer;
    public float bulletsDuration,dropDuration;
    // Start is called before the first frame update
    void Start()
    {
        attack = Random.Range(1, 4);
        bullets.SetActive(false);
        waterDrop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(playerH.dead == false)
        {
            leftEye.transform.position = Vector2.MoveTowards(leftEye.transform.position, player.transform.position, speed * Time.deltaTime);
            rightEye.transform.position = Vector2.MoveTowards(rightEye.transform.position, player.transform.position, speed * Time.deltaTime);
            
            if(attack == 1)
            {
                laser.SetActive(true);
                if(bossLaser.finish == true)
                {
                    Debug.Log(attack);
                    bossLaser.finish = false;
                    laser.SetActive(false);
                    
                    attack = Random.Range(1, 4);
                }
            }
            if(attack == 2)
            {
                bullets.SetActive(true);
                if (timer >= bulletsDuration)
                {
                    bullets.SetActive(false);
                    attack = Random.Range(1, 4);
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }

            if (attack == 3)
            {
                waterDrop.SetActive(true);
                if (timer >= dropDuration)
                {
                    waterDrop.SetActive(false);
                }

                if (timer >= dropDuration + 5)
                {
                    attack = Random.Range(1, 4);
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }

        }

    }
}
