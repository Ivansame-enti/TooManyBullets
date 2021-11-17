using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 10f;
    Rigidbody2D rb;
    GameObject[] gos;


    Vector2 moveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gos = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        moveDirection = (closest.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 7f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D (Collider2D col) {

        if (col.gameObject.name.Equals("enemy"))// Si colisiona contra enemigo se destruye
        {
            Destroy(gameObject);
        }

     }
}
