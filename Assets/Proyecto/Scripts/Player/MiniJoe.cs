using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniJoe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bala;
    public GameObject minijoe;
    public GameObject character;
    public float fireRate;
    public float delay;
    private float timer=0;
    float nextFire;
    GameObject[] gos;
    private List<Vector3> positionList = new List<Vector3>();
    private int distance=20;
   


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


        //nijoe.transform.position = character.transform.position + new Vector3(1,1,0); //ESTO MUEVE A MINIJOE BIEN PERO SIN DELAY

        //  Instantiate(bala);
        //  balai = Instantiate(bala,transform.position,transform.rotation);


        // float step = shootspeed * Time.deltaTime;

        //  balai.transform.position = Vector3.MoveTowards(balai.transform.position, enemy.transform.position, step);
        //    transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        //balat = false;
        //  if (bala.transform.position == enemy.transform.position)
        // {
        //  Destroy(this.balai, 2);

        //Debug.Log(character.transform.position);

        Vector3 posicion = character.transform.position;

        positionList.Add(posicion);
        
        if(positionList.Count > delay)
        {
            positionList.RemoveAt(0);
            minijoe.transform.position = positionList[0] + new Vector3(0.7f,0.7f,0);
            //minijoe.transform.position = character.transform.position + new Vector3(1, 1, 0);

        }
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.01f, 0.99f);
        pos.y = Mathf.Clamp(pos.y, 0.02f, 0.98f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

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
