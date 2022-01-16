using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeZona : MonoBehaviour
{

    public GameObject obstaculo,escudos, tutorialEnemies,tutorialObstacle,checkMj;

    // Start is called before the first frame update
    void Start()
    {
        tutorialEnemies.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "zona")
        {
            tutorialEnemies.SetActive(true);
            tutorialObstacle.SetActive(false);
            checkMj.SetActive(false);
        }
        if (collision.tag == "zona2")
        {
            // GameObject.FindGameObjectWithTag("obstaculo").SetActive(false);
            escudos.SetActive(true);
        }

    }
}
