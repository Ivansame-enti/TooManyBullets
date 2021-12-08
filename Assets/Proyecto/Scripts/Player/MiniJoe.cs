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

    public GameObject torretarea;
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
        if(player != null) { 
        float distancia = Vector2.Distance(minijoe.transform.position, player.transform.position);
        gos = GameObject.FindGameObjectsWithTag("enemy");
        
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

        if (displanted == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {


                minijoe.transform.parent = null;
                flagS = true;

            }
        }

       if (flagS == true)
        {
            if (enemya==true)
            {
                if (gos.Length >= 1)//mira si hay enemigos
                {
                    CheckFire();
                }
            }
         
        }

        if (flagS == true)
        {

                if (displanted == true)
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Example(padre);

                        torretarea.SetActive(false);

                        torretarea.transform.parent = null;

                        minijoe.transform.localScale = new Vector2(0.7f, 0.7f);
                        torretarea.transform.SetParent(padre2);

                        flagS = false;
                        displanted = false;
                    }
                }
            
            else
            {

                torretarea.SetActive(true);
              //  healwafe.SetActive(true);

                torretarea.transform.parent = null;

                minijoe.transform.localScale = new Vector2(0.2f, 0.2f);
                torretarea.transform.SetParent(padre2);

                displanted = true;
              
                //ESTA PLANTADO Y NO ESTA EN RANGO DE RECOGER PONER LAS COSAS DE ESTAR PLANTADO

            }
        }
        }

    }


    public void Example(Transform padre)
    {
        // Sets "newParent" as the new parent of the child GameObject
        minijoe.transform.SetParent(padre);
    }

    void  CheckFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bala, this.transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    private void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, area);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        enemya = true;     
    }
}
