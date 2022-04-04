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
    public GameObject player;
    private float area2;
    
    void Start()
    {
        area2 = 6.7f;
        timer = healTimer;
        healedOnce = false;
        //timer2 = healDelay;
        currenntHealsAvailable = healsAvailable;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MiniJoe>().displanted == true && Vector2.Distance(this.transform.position, player.transform.position) > area2)
        {
            if (phc.currentHealth < phc.health && currenntHealsAvailable > 0) //&& !healOnce
            {
                if (timer <= 0)
                {
                    var ps = Instantiate(healParticle, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
                    phc.currentHealth += healAmmount;
                    phc.currentHealth = Mathf.Round(phc.currentHealth * 10.0f) * 0.1f; //Resondear a unn decimal porque a veces no se suma bien
                    if (phc.currentHealth == 3.0f || phc.currentHealth == 2.0f || phc.currentHealth == 1.0f)
                    {
                        FindObjectOfType<AudioManagerController>().AudioPlay("Plim");
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
