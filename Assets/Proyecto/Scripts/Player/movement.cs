using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;

    public float rotationSpeed=1000.0f;

    public Vector3 lastMoveDir;

    public bool isMoving;
    public GameObject minijoe;
    private float width;

    public Vector2 movementDirection;
    public Quaternion toRotation;
    public Vector3 scaleChange;

    private void Start()
    {
        width = 0.15f;
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            isMoving = false;
        else isMoving = true;

        movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
        lastMoveDir = movementDirection;
        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero)
        {
            toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //Impide que el jugador salga de los limites de la pantalla
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.01f, 0.99f);
        pos.y = Mathf.Clamp(pos.y, 0.02f, 0.98f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        /*
        if(isMoving == true)
        {
            //this.gameObject.GetComponent<Animator>().enabled = true;
            
            width -= Time.deltaTime;

            if (width >= 0.09f)
            {
                scaleChange = new Vector3(width, 0.15f, 0);
                this.transform.localScale = scaleChange;
            }
               
        }
        else if (isMoving == false)
        {
           // this.gameObject.GetComponent<Animator>().enabled = false;
            width = 0.15f;
            scaleChange = new Vector3(width, 0.15f, 0);
            this.transform.localScale = scaleChange;
        }
            */
        /*
        if (reduceWidth)
        {
            if (width > 0)
            {
                //Debug.Log("Bajaaaaa");
                width -= Time.deltaTime * 2;
                boxColliderX -= Time.deltaTime;
                celestialAtk.gameObject.transform.GetChild(2).GetComponent<BoxCollider2D>().size = new Vector2(boxColliderX, originalBoxColliderSizeY);
                celestialAtk.GetComponent<LineRenderer>().SetWidth(width, width);

                scaleChange = new Vector3(0, -0.02f, 0);
                laserParticles2.transform.localScale += scaleChange;
            }
            if (width <= 0) timerAttack -= Time.deltaTime;
        }
        */
    }
}