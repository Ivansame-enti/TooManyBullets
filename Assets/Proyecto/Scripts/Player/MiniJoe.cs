using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniJoe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bala;
    public float fireRate;
    public float delay;
    // private float timer=0;
    float nextFire;
    GameObject[] gos;
    //private GameObject healarea;
    public GameObject minijoe;
    private bool flagS = false;
    public Transform padre, padre2;
    public float area, area2;
    public GameObject player;
    public GameObject character;
    public GameObject torretarea;
    private bool enemya = false;
    private bool checkenemyinrange = false;
    public bool displanted = false;
    public GameObject miniJoelaser;
    private List<Vector3> positionList = new List<Vector3>();
    public float timer;
    public float plantCD;
    public float pickUpDistance;
    public PauseController pause;

    void Start()
    {
        //fireRate = 1f;
        nextFire = Time.time;
        timer = plantCD;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distancia = Vector2.Distance(minijoe.transform.position, player.transform.position);
            gos = GameObject.FindGameObjectsWithTag("enemy");

            if (gos.Length >= 1)
            {
                for (int i = 0; i < gos.Length; i++)
                {
                    if (Vector2.Distance(minijoe.transform.position, gos[i].transform.position) <= area2)
                    {
                        enemya = true;
                        checkenemyinrange = true;
                    }
                    else
                    {
                        if (checkenemyinrange == false)
                        {
                            enemya = false;
                        }
                    }

                }
                checkenemyinrange = false;
            }

            if (displanted == false && timer >= plantCD)
            {
                if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("L1"))
                {
                    timer = 0;
                    minijoe.transform.parent = null;
                    flagS = true;

                }
            }
            else if (timer <= plantCD)
            {
                timer += Time.deltaTime;
            }

            if (flagS == true)
            {
                if (enemya == true)
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
                    if (distancia < pickUpDistance)
                    {
                        if (timer >= plantCD)
                        {
                            if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("L1"))
                            {
                                timer = 0;
                                Example(padre);

                                torretarea.SetActive(false);

                                torretarea.transform.parent = null;

                                minijoe.transform.localScale = new Vector2(0.7f, 0.7f);
                                torretarea.transform.SetParent(padre2);

                                miniJoelaser.SetActive(false);
                                flagS = false;
                                displanted = false;

                            }
                        }
                        else if (timer <= plantCD)
                        {
                            timer += Time.deltaTime;
                        }
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
        if (displanted==false && pause.pauseState == false)
        {
            Vector3 posicion = character.transform.position;

            positionList.Add(posicion);

            if (positionList.Count > delay)
            {
                //Debug.Log("Ei");
                positionList.RemoveAt(0);
                minijoe.transform.position = positionList[0] + new Vector3(0.6f, 0.6f, 0);
                //minijoe.transform.position = character.transform.position + new Vector3(1, 1, 0);

            }

            //Evitar que salga de la pantalla
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, 0.01f, 0.99f);
            pos.y = Mathf.Clamp(pos.y, 0.02f, 0.98f);
            transform.position = Camera.main.ViewportToWorldPoint(pos);

        }else if (displanted == true)
        {
            positionList.Clear();
        }

    }



    public void Example(Transform padre)
    {
        // Sets "newParent" as the new parent of the child GameObject
        minijoe.transform.SetParent(padre);
    }

    void CheckFire()
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
