using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniJoe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bala;    
    public float fireRate;
    float nextFire;
    GameObject[] gos;


    void Start()
    {
        //fireRate = 1f;
        nextFire = Time.time;
    }
    
    // Update is called once per frame
    void Update()
    {
        // float step = shootspeed * Time.deltaTime;
        //Timer -= Time.deltaTime;
        gos = GameObject.FindGameObjectsWithTag("enemy");

        if (gos.Length>=1)//mira si hay enemigos
        {
            CheckFire();

        }


        //  Instantiate(bala);
        //  balai = Instantiate(bala,transform.position,transform.rotation);


        // float step = shootspeed * Time.deltaTime;

        //  balai.transform.position = Vector3.MoveTowards(balai.transform.position, enemy.transform.position, step);
        //    transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        //balat = false;
        //  if (bala.transform.position == enemy.transform.position)
        // {
        //  Destroy(this.balai, 2);
    }


  void  CheckFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bala, this.transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    
}
