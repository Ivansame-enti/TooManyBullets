using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Ei");
        if (collision.tag == "enemy" || collision.tag == "EnemyBullet")
            collision.GetComponent<SpriteRenderer>().sortingOrder = 11;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Ei");
        if(collision.tag=="enemy" || collision.tag == "EnemyBullet")
            collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
}
