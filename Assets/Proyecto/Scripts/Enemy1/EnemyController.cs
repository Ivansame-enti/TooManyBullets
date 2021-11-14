using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int bulletAmount;
    public GameObject bulletPrefab;
    public float bulletFrequency;
    private float timer, timerBullet;
    public float bulletSpeed;
    private float radius = 5f;
    //private int angle;

    // Start is called before the first frame update
    void Start()
    {
        timerBullet = Time.deltaTime + bulletFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer > timerBullet)
        {
            bulletAmount = Random.Range(5, 20);
            float angleStep = 360f / bulletAmount;
            float angle = 0f;
            
            for(int i=0; i < bulletAmount; i++)
            {
                float bulletXPos = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float bulletYPos = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 bulletSpawn = new Vector3(bulletXPos, bulletYPos, 0f);
                Vector2 bulletDirection = (bulletSpawn - transform.position).normalized * bulletSpeed;

                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDirection.x, bulletDirection.y);
                angle += angleStep;
            }

            timerBullet = timer + bulletFrequency;
        }
    }
}