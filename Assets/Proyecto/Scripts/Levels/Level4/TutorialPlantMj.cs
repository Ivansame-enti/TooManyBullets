using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject minijoe;
    public GameObject objects2;
    void Start()
    {

        minijoe = GameObject.FindGameObjectWithTag("Minijoe");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Minijoe"))
        {
            objects2.SetActive(false);
        }
    }
}
