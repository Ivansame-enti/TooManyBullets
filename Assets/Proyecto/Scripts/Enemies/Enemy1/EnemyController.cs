using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int bulletAmount;
    public GameObject bulletPrefab;
    public float bulletFrequencyMin;
    public float bulletFrequencyMax;
    private float timer, timerBullet;
    public float bulletSpeed;
    private float radius = 5f;
    public GameObject spawnParticles;
    public Animation anim;
    private bool firstTime;

    //private int angle;

    // Start is called before the first frame update
    void Start()
    {
        firstTime = true;
        anim = gameObject.GetComponent<Animation>();

        spawnParticles = Instantiate(spawnParticles, this.transform.position, Quaternion.identity);
        
        timerBullet = Time.deltaTime + Random.Range(bulletFrequencyMin, bulletFrequencyMax);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.name == "EnemyInstant" && firstTime)
        {
            timerBullet = 0;
        }

        if(spawnParticles != null)
        {
            Destroy(spawnParticles.gameObject, 1f);
        }
        
        timer += Time.deltaTime;

        if (timer > timerBullet)
        {
            timerBullet = timer + Random.Range(bulletFrequencyMin, bulletFrequencyMax);
            anim.Play("warningRangedEnemy");
            
        }
        firstTime = false;
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("AttackAnimationEnded"))
        {
            //HACER ATAQUE JUSTO DESPUES DE ANIMACION
            bulletAmount = Random.Range(5, 20);
            float angleStep = 360f / bulletAmount;
            float angle = 0f;

            for (int i = 0; i < bulletAmount; i++)
            {
                float bulletXPos = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float bulletYPos = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 bulletSpawn = new Vector3(bulletXPos, bulletYPos, 0f);
                Vector2 bulletDirection = (bulletSpawn - transform.position).normalized * bulletSpeed;

                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDirection.x, bulletDirection.y);
                angle += angleStep;
                FindObjectOfType<AudioManagerController>().AudioPlay("EnemyAttack");
            }
        }
    }
}