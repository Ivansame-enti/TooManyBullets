using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public GameObject WaterDropClone;
    public float DropForce;
    SpriteRenderer rend;
    private Color attackColor = Color.magenta;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("DropFaster"))
        {
            WaterDropClone.GetComponent<Rigidbody2D>().drag = 0;
            WaterDropClone.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -15,0);
            rend.material.color = attackColor;


        }
        
        if (collision.gameObject.tag.Equals("DestroyBulletCollider"))
        {
            Destroy(gameObject);
        }
    }

}
