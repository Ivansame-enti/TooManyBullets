using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public GameObject WaterDropClone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("DropFaster"))
        {
            Debug.Log("funciona");
            WaterDropClone.GetComponent<Rigidbody2D>().drag = 0;
        }
    }
}
