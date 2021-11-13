using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public Animator shakeCamera;
    public float inmortalTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        timer = inmortalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0) timer -= Time.deltaTime;

        if(currentHealth <= 0)
        {
            //Cargar escena muerte
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentHealth--;
        shakeCamera.SetTrigger("Shake");
        timer = inmortalTime;

        //shakeCamera.SetTrigger("Shake");
        //Debug.Log("Damage");
    }
}
