using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MiniJoe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bala;
    public float fireRate;
    public float delay;
    // private float timer=0;
    float nextFire;
    private List<GameObject> gos = new List<GameObject>();
    //private GameObject healarea;
    public GameObject minijoe;
    private bool flagS = false;
    public Transform padre, padre2;
    public float area, area2;
    public GameObject player;
    public GameObject character;
    public GameObject torretarea;
    //public GameObject pickArea;
    private bool enemya = false;
    private bool checkenemyinrange = false;
    public bool displanted = false;
    public GameObject miniJoelaser;
    private List<Vector3> positionList = new List<Vector3>();
    public float timer;
    public float plantCD;
    public float pickUpDistance;
    public PauseController pause;
    private bool nivel3;
    public GameObject searchEnemies;
    private bool nivel6;
    private bool level2;
    private bool minijoePicked;
    private float speed;
    private Vector3 defaultScale;
    
    void Start()
    {
        defaultScale = torretarea.transform.localScale;
        speed = 15f;
        minijoePicked = false;
        //playerSpeed = player.GetComponent<movement>().speed;
        //fireRate = 1f;
        nextFire = Time.time;
        timer = plantCD;
        if (SceneManager.GetActiveScene().name != "Nivel2") level2 = false;
        else level2 = true;
        if (SceneManager.GetActiveScene().name != "Nivel3") nivel3 = false;
        else nivel3 = true;
        if (SceneManager.GetActiveScene().name != "Nivel6") nivel6 = false;
        else nivel6 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distancia = Vector2.Distance(minijoe.transform.position, player.transform.position);

            if (nivel3)
            {
                minijoe.transform.parent = null;
                flagS = true;
                this.transform.position = new Vector2(0, 0);
            }

            if (nivel6)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                minijoe.transform.parent = null;
                flagS = true;
                this.transform.position = new Vector2(20.5f, 0);
                nivel6 = false;
            }

            if (displanted)
            {
                //gos = GameObject.FindGameObjectsWithTag("enemy");

                if (gos.Count >= 1) gos.Clear(); //Limpia la lista
                var children = searchEnemies.GetComponentsInChildren<Transform>(); //Busca en el objeto que contiene el nivel

                foreach (var child in children)
                {
                    if (child.tag == "enemy") //Recoge a los hijos que 
                        gos.Add(child.gameObject);
                    //Debug.Log("Hola");
                }
                /*
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
                */
                if (gos.Count >= 1)
                {
                    for (int i = 0; i < gos.Count; i++)
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
            }


            if (displanted == false && timer >= plantCD && !level2 && !minijoePicked)
            {
                if (ControllerInput.Xbox_One_Controller)
                {
                    if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("LB")) //Plantar a minijoe
                    {
                        this.GetComponent<BoxCollider2D>().enabled = true;
                        timer = 0;
                        minijoe.transform.parent = null;
                        flagS = true;
                    }
                }
                else if (ControllerInput.PS4_Controller)
                {
                    if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("L1")) //Plantar a minijoe
                    {
                        this.GetComponent<BoxCollider2D>().enabled = true;
                        timer = 0;
                        minijoe.transform.parent = null;
                        flagS = true;
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.LeftControl)) //Plantar a minijoe
                    {
                        this.GetComponent<BoxCollider2D>().enabled = true;
                        timer = 0;
                        minijoe.transform.parent = null;
                        flagS = true;
                    }
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
                    /*if (gos.Length >= 1)//mira si hay enemigos
                    {
                        CheckFire();
                    }*/
                    if (gos.Count >= 1)//mira si hay enemigos
                    {
                        CheckFire();
                    }
                }
            }

            if (flagS == true)
            {

                if (displanted == true)
                {
                    //if (distancia < pickUpDistance)
                    //{
                    //pickArea.SetActive(true);
                    if (timer >= plantCD && !minijoePicked)
                    {
                        if (ControllerInput.Xbox_One_Controller)
                        {
                            if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("LB")) && !nivel3) //Recoger a minijoe
                            {
                                this.GetComponent<BoxCollider2D>().enabled = false;
                                timer = 0;
                                //Example(padre);
                                minijoePicked = true;
                                //pickArea.SetActive(false);

                                torretarea.SetActive(false);

                                torretarea.transform.parent = null;

                                //minijoe.transform.localScale = new Vector2(0.7f, 0.7f);
                                torretarea.transform.SetParent(padre2);

                                //player.GetComponent<movement>().speed = playerSpeed;
                                miniJoelaser.SetActive(false);
                                flagS = false;
                                displanted = false;

                            }
                        }
                        else if (ControllerInput.PS4_Controller)
                        {
                            if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("L1")) && !nivel3) //Recoger a minijoe
                            {
                                this.GetComponent<BoxCollider2D>().enabled = false;
                                timer = 0;
                                //Example(padre);
                                minijoePicked = true;
                                //pickArea.SetActive(false);

                                torretarea.SetActive(false);

                                torretarea.transform.parent = null;

                               // minijoe.transform.localScale = new Vector2(0.7f, 0.7f);
                                torretarea.transform.SetParent(padre2);

                                //player.GetComponent<movement>().speed = playerSpeed;
                                miniJoelaser.SetActive(false);
                                flagS = false;
                                displanted = false;

                            }
                        }
                        else
                        {
                            if (Input.GetKeyDown(KeyCode.LeftControl) && !nivel3) //Recoger a minijoe
                            {
                                this.GetComponent<BoxCollider2D>().enabled = false;
                                timer = 0;
                                //Example(padre);
                                minijoePicked = true;
                                //pickArea.SetActive(false);

                                torretarea.SetActive(false);

                                torretarea.transform.parent = null;

                                //minijoe.transform.localScale = new Vector2(0.7f, 0.7f);
                                torretarea.transform.SetParent(padre2);

                                //player.GetComponent<movement>().speed = playerSpeed;
                                miniJoelaser.SetActive(false);
                                flagS = false;
                                displanted = false;

                            }
                        }
                    }
                    else if (timer <= plantCD)
                    {
                        timer += Time.deltaTime;
                    }
                    //}
                    //else pickArea.SetActive(false);

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


        if (minijoePicked)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            
            if (Vector3.Distance(this.transform.position, player.transform.position) <= 1f)
            {
                torretarea.transform.localScale= defaultScale;
                //Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
                Example(padre);
                minijoe.transform.localScale = new Vector2(0.7f, 0.7f);
                minijoePicked = false;
            }
        }

        if (displanted == false && pause.pauseState == false && minijoePicked == false)
        {
            Vector3 posicion = character.transform.position;

            positionList.Add(posicion);

            if (positionList.Count > delay)
            {
                //Debug.Log("Ei");
                positionList.RemoveAt(0);
                //minijoe.transform.position = positionList[0] + new Vector3(0.6f, 0.6f, 0);
                transform.position = Vector2.MoveTowards(transform.position, positionList[0] + new Vector3(0.6f, 0.6f, 0), 2 * Time.deltaTime);
                //minijoe.transform.position = character.transform.position + new Vector3(1, 1, 0);

            }

            //Evitar que salga de la pantalla
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, 0.01f, 0.99f);
            pos.y = Mathf.Clamp(pos.y, 0.02f, 0.98f);
            transform.position = Camera.main.ViewportToWorldPoint(pos);

        }
        else if (displanted == true)
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        enemya = true;
    }
}
