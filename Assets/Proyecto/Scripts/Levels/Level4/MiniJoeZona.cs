using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeZona : MonoBehaviour
{

    public GameObject obstaculo,escudos, tutorial, tutorialEnemies,checkMj;
    public GameObject scoreTextActive, scoreActive;

    // Start is called before the first frame update
    void Start()
    {
        tutorialEnemies.SetActive(false);
        scoreTextActive.SetActive(false);
        scoreActive.SetActive(false);
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
            checkMj.SetActive(false);
            tutorial.SetActive(false);
            scoreTextActive.SetActive(true);
            scoreActive.SetActive(true);
        }
        if (collision.tag == "zona2")
        {
            // GameObject.FindGameObjectWithTag("obstaculo").SetActive(false);
            escudos.SetActive(true);
        }

    }
}
