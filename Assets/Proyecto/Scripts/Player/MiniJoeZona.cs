using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeZona : MonoBehaviour
{

    public GameObject obstaculo,escudos;
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
        if (collision.tag == "zona")
        {

            // GameObject.FindGameObjectWithTag("obstaculo").SetActive(false);
            obstaculo.SetActive(false);
        }
        if (collision.tag == "zona2")
        {
            Debug.Log("algo");
            // GameObject.FindGameObjectWithTag("obstaculo").SetActive(false);
            escudos.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "zona")
        {
           // GameObject.FindGameObjectWithTag("obstaculo").SetActive(true);
            obstaculo.SetActive(true);
        }
        if (collision.tag == "zona2")
        {
            // GameObject.FindGameObjectWithTag("obstaculo").SetActive(true);
            escudos.SetActive(false);
        }

    }
}
