using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController2 : MonoBehaviour
{
    public int bulletAmount;
    public GameObject bulletPrefab;
    public float bulletFrequencyMin;
    public float bulletFrequencyMax;
    private float timer, timerBullet;
    public float bulletSpeed;
    private float radius = 5f;
    public GameObject spawnParticles;
    //private int angle;
    private AudioManagerController audioSFX;
    private PauseController pause;


    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<PauseController>();
        audioSFX = FindObjectOfType<AudioManagerController>();
        spawnParticles = Instantiate(spawnParticles, this.transform.position, Quaternion.identity);

        timerBullet = Time.deltaTime + Random.Range(bulletFrequencyMin, bulletFrequencyMax);

        if (SceneManager.GetActiveScene().name == "Nivel6")
        {
            bulletSpeed = 15f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Nivel6" && bulletSpeed>3)
        {
            bulletSpeed -=Time.deltaTime*3;
            //Debug.Log(bulletSpeed);
        }

        if (spawnParticles != null)
        {
            Destroy(spawnParticles.gameObject, 1f);
        }

        timer += Time.deltaTime;

        if (!audioSFX.GetAudioPlaying("MachineGun") && !pause.pauseState) audioSFX.AudioPlay("MachineGun");

        if (timer > timerBullet)
        {
            //bulletAmount = Random.Range(5, 20);
            float angleStep = 360f / bulletAmount;
            float angle = Random.Range(0f, 360f);

            for (int i = 0; i < bulletAmount; i++)
            {
                float bulletXPos = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float bulletYPos = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 bulletSpawn = new Vector3(bulletXPos, bulletYPos, 0f);
                Vector2 bulletDirection = (bulletSpawn - transform.position).normalized * bulletSpeed;

                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletDirection.x, bulletDirection.y);
                angle += angleStep;
            }

            timerBullet = timer + Random.Range(bulletFrequencyMin, bulletFrequencyMax);
        }
    }
}
