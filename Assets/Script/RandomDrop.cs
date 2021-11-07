using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    public Vector2 positionA,positionB;

    private bool exists = false;
    public GameObject WaterDrop;
    Vector2 randomValor;


    private float nextActionTime = 0.0f;
    public float period = 1f;
    private GameObject WaterDropClone;
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

                WaterDropClone = Instantiate(WaterDrop, randomValor, WaterDrop.transform.rotation);
                WaterDropClone.GetComponent<Rigidbody2D>().drag = 35;
                Destroy(WaterDropClone.gameObject, 6f); 
            //if(exists == true)
            //{
               
            //}
                
        }

    }
}
