using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniJoe : MonoBehaviour
{
    // Start is called before the first frame update

    public float shootspeed = 2.0f;
    public GameObject bala;
    public GameObject enemy;
    private GameObject balai;
    
    public float Timer = 2;
    private bool balat = false;
    float fireRate;
    float nextFire;

    void Start()
    {
        //enemy = GameObject.FindGameObjectsWithTag("enemy");
        fireRate = 1f;
        nextFire = Time.time;
    }
    
    // Update is called once per frame
    void Update()
    {
        // float step = shootspeed * Time.deltaTime;
        //Timer -= Time.deltaTime;
        CheckFire();
       
      
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
            Instantiate(bala,transform.position,Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    
}
