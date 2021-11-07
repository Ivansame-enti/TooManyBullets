using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialAttack : MonoBehaviour
{
    public Animation warningAnim;
    public GameObject warning;
    public Vector2 positionA, positionB;
    private float nextActionTime = 0.0f;
    public float period = 1f;
    Vector2 randomValor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            randomValor = new Vector2(
                Random.Range(positionA.x, positionB.x),
                Random.Range(positionB.y, positionB.y)
            );
            warning = Instantiate(warning, randomValor, warning.transform.rotation);
            Destroy(warning.gameObject, 5f);
            //if(exists == true)
            //{

            //}
            //Destroy(WaterDropClone.gameObject, 5f);
        }
    }
}
