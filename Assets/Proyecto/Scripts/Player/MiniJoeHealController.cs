using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeHealController : MonoBehaviour
{
    // Start is called before the first frame update
    public float healDelay;
    public float healAmmount;
    private float timer;
    public PlayerHealthController phc;
    private bool minijoeIn;
    private bool healedOnce;
    private float life;
    
    void Start()
    {
        minijoeIn = true;
        timer = healDelay;
        healedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(phc.currentHealth<phc.health && minijoeIn && !healedOnce)
        {
            if (timer <= 0)
            {
                //float 
                phc.currentHealth += healAmmount;
                phc.currentHealth = Mathf.Round(phc.currentHealth * 10.0f) * 0.1f; //Resondear a unn decimal porque a veces no se suma bien
                Debug.Log(phc.currentHealth);
                if(phc.currentHealth==3.0f || phc.currentHealth == 2.0f)
                {
                    healedOnce = true;
                }
                timer = healDelay;
            } else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
