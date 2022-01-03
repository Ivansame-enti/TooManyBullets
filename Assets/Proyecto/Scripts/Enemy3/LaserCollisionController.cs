using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Entra");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.collider.tag=="PlayerTag")
            Debug.Log("A");
    }
}
