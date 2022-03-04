using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject player;
    public GameObject leftEye, rightEye;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftEye.transform.position = Vector2.MoveTowards(leftEye.transform.position, player.transform.position, speed * Time.deltaTime);
        rightEye.transform.position = Vector2.MoveTowards(rightEye.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
