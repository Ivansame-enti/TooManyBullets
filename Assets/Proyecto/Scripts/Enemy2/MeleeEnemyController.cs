using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public float speedRotation;
    private Transform playerPos;
    private GameObject canvas;
    private Quaternion canvasRotation;
    // Start is called before the first frame update
    void Start()
    {
        canvas = this.transform.GetChild(0).gameObject;
        canvasRotation = canvas.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("PlayerTag").transform;
        //canvas.transform.parent = null;
        transform.Rotate(0, 0, speedRotation * Time.deltaTime);
        //canvas.transform.Rotate(800, 0, 800);
        //canvas.transform.parent = this.transform;
    }
}
