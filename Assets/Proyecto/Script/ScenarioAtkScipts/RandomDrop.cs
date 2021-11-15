using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    public Vector2 positionA,positionB;

    public GameObject WaterDrop;
    Vector2 randomValor;
    


    private float nextActionTime = 0.0f;
    private float period = 1f;
    private GameObject WaterDropClone;
    public float warningDropForce;
    // Start is called before the first frame update

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        period = Random.Range(5, 10);
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            
            randomValor = new Vector2(
                Random.Range(positionA.x, positionB.x),
                Random.Range(positionB.y, positionB.y)
            );

                WaterDropClone = Instantiate(WaterDrop, randomValor, WaterDrop.transform.rotation);
                WaterDropClone.GetComponent<Rigidbody2D>().drag = warningDropForce;
                Destroy(WaterDropClone.gameObject, 10f); 
            //if(exists == true)
            //{
               
            //}
                
        }

    }
}
