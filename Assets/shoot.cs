using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update

    public float shootspeed = 1.0f;
    public GameObject bala;
    public GameObject enemy;
    public float Timer = 2;
    private bool balat = false;
    void Start()
    {
        //enemy = GameObject.FindGameObjectsWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        // float step = shootspeed * Time.deltaTime;
        Timer -= Time.deltaTime;
       
        if (Timer <= 0f)
        {
            Instantiate(bala);
           
            balat = true;
            Timer = 2;
        }
 
        if (balat==true)
        {
            bala.SetActive(true);
            bala.transform.position = Vector2.MoveTowards(bala.transform.position, enemy.transform.position, shootspeed);
        }
        //  if (bala.transform.position == enemy.transform.position)
        // {

    }
 
     void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
