using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeHealController : MonoBehaviour
{
    // Start is called before the first frame update
    //public Animation plantUIAnim;
    //public float healDelay;
    public float healTimer;
    public float healAmmount;
    public int healsAvailable;
    public int currenntHealsAvailable;
    public float timer;
    //public float timer2;
    public PlayerHealthController phc;
    private bool healedOnce;
    public GameObject healParticle;
    
    void Start()
    {
        timer = healTimer;
        healedOnce = false;
        //timer2 = healDelay;
        currenntHealsAvailable = healsAvailable;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MiniJoe>().displanted == false)
        {
            if (phc.currentHealth < phc.health && currenntHealsAvailable > 0) //&& !healOnce
            {
                if (timer <= 0)
                {
                    var ps = Instantiate(healParticle, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                    phc.currentHealth += healAmmount;
                    phc.currentHealth = Mathf.Round(phc.currentHealth * 10.0f) * 0.1f; //Resondear a unn decimal porque a veces no se suma bien
                    if (phc.currentHealth == 3.0f || phc.currentHealth == 2.0f || phc.currentHealth == 1.0f)
                    {
                        //timer2 = 0;
                        currenntHealsAvailable--;
                        //healedOnce = true;
                    }
                    timer = healTimer;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
    }
}
