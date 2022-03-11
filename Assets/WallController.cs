using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slash")
        {
            //Destroy(collision.gameObject);
            //collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
