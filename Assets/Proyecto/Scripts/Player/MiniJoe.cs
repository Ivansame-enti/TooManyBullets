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
    //private GameObject healarea;
    public GameObject minijoe;
    private bool flagS = false;
    public Transform padre,padre2;
    public float area,area2;
    public GameObject player;
    public GameObject healarea;
    public GameObject[] healareaP;
    public GameObject torretarea;
    private GameObject enemy;
    public GameObject healwafe;
    private bool enemya=false;
    private bool checkenemyinrange = false;
    public bool displanted = false;
    void Start()
    {
        //fireRate = 1f;
        nextFire = Time.time;
        
}
    
    // Update is called once per frame
    void Update()
    {
        float distancia = Vector2.Distance(minijoe.transform.position, player.transform.position);
      
        // float step = shootspeed * Time.deltaTime;
        //Timer -= Time.deltaTime;
        gos = GameObject.FindGameObjectsWithTag("enemy");
        
        healareaP = GameObject.FindGameObjectsWithTag("healarea");
        if (gos.Length >= 1) { 
            for (int i =0; i<gos.Length; i++)
        {
            if (Vector2.Distance(minijoe.transform.position, gos[i].transform.position) <= area2)
            {
                enemya = true;
                checkenemyinrange = true;
            }
            else
            {
                if (checkenemyinrange == false){ 
                enemya = false;
                }
            }
            
        }
        checkenemyinrange = false;
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
        if (Input.GetKeyDown(KeyCode.O)) {


            minijoe.transform.parent = null;
            flagS = true;
            
        }
       // else
       // {
       //     minijoe.transform.parent = padre.transform.parent;
        //}

       if (flagS == true)
        {
            if (enemya==true)
            {
                if (gos.Length >= 1)//mira si hay enemigos
                {
                    healwafe.SetActive(true);
                    CheckFire();

                }
            }
         
        }

        if (flagS == true)
        {
            if (distancia <= area)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Example(padre);
                    Debug.Log("Hello: ");
                    torretarea.SetActive(false);
                    healwafe.SetActive(false);
                    torretarea.transform.parent = null;
                    healwafe.transform.parent = null;
                    minijoe.transform.localScale = new Vector2(0.7f, 0.7f);
                    torretarea.transform.SetParent(padre2);
                    healwafe.transform.SetParent(padre2);
                    flagS = false;
                    displanted = false;
                }
            }
            else
            {

                torretarea.SetActive(true);
              //  healwafe.SetActive(true);

                torretarea.transform.parent = null;
                healwafe.transform.parent = null;
                minijoe.transform.localScale = new Vector2(0.2f, 0.2f);
                torretarea.transform.SetParent(padre2);
                healwafe.transform.SetParent(padre2);
                displanted = true;
              
                //ESTA PLANTADO Y NO ESTA EN RANGO DE RECOGER PONER LAS COSAS DE ESTAR PLANTADO

            }
        }

    }


    public void Example(Transform padre)
    {
        // Sets "newParent" as the new parent of the child GameObject
        minijoe.transform.SetParent(padre);
      //  Debug.Log("Hello: ");
      
        //  child.transform.SetParent(newParent, false);

        // child.transform.SetParent(null);
    }

    void  CheckFire()
    {
        //if (torretarea.)
        //{
        if (Time.time > nextFire)
        {
            Instantiate(bala, this.transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
       // }
    }
    private void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(transform.position, area2);
        Gizmos.DrawSphere(transform.position, area);
        // Gizmos.DrawWireSphere(transform.position, areadisparo);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        enemya = true;     
    }
}
