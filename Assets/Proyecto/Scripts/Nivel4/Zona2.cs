using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona2 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject minijoe;
    public GameObject escudos;
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
        Debug.Log("entra");
        if (collision.gameObject.tag.Equals("Minijoe"))
        {
            escudos.SetActive(true);
        }
    }
}
