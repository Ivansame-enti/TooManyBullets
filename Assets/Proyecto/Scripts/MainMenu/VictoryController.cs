using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
    private Vector2 randomValor,randomValor2;
    public Vector2 positionA, positionB,positionC,positionD;
    public GameObject firework;
    private GameObject fireworkClone,fireworkClone2;
    private float leftFirework,rightFirework;
    public float fireworkCooldownLeft, fireworkCooldownRight;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (leftFirework <= 0)
        {
            randomValor = new Vector2(
                Random.Range(positionA.x, positionB.x),
                Random.Range(positionA.y, positionB.y)
        );
            Instantiate(firework, randomValor, Quaternion.identity);
            leftFirework = fireworkCooldownLeft;
        }
        else
        {
            leftFirework -= Time.deltaTime;
        }

        if (rightFirework <= 0)
        {
            randomValor2 = new Vector2(
                Random.Range(positionC.x, positionD.x),
                Random.Range(positionC.y, positionD.y)
             );
            Instantiate(firework, randomValor2, Quaternion.identity);
            rightFirework = fireworkCooldownRight;
        }
        else
        {
            rightFirework -= Time.deltaTime;
        }
    }
}
