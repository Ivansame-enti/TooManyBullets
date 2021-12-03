using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeHealController : MonoBehaviour
{
    // Start is called before the first frame update
    public float healDelay;
    public float healTimer;
    public float healAmmount;
    private float timer;
    public float timer2;
    public PlayerHealthController phc;
    private bool minijoeIn;
    private bool healedOnce;
    public GameObject healParticle;
    
    void Start()
    {
        minijoeIn = true;
        timer = healTimer;
        healedOnce = false;
        timer2 = healDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(phc.currentHealth<phc.health && minijoeIn && timer2>=healDelay) //&& !healOnce
        {
            if (timer <= 0)
            {
                //float 
                var ps = Instantiate(healParticle, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                //ps.transform.localScale;
                //Debug.Log(ps.transform.localScale);
                //ps.transform.parent = this.transform;
                //ps.transform.localScale = new Vector3(1f,1f,1f);
                phc.currentHealth += healAmmount;
                phc.currentHealth = Mathf.Round(phc.currentHealth * 10.0f) * 0.1f; //Resondear a unn decimal porque a veces no se suma bien
                if(phc.currentHealth==3.0f || phc.currentHealth == 2.0f)
                {
                    timer2 = 0;
                    //healedOnce = true;
                }
                timer = healTimer;
            } else
            {
                timer -= Time.deltaTime;
            }
        } else
        {
            timer2 += Time.deltaTime;
        }
    }
}
