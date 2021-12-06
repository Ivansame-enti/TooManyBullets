using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniJoeLaserCollider : MonoBehaviour
{
    CapsuleCollider capsule;
    public GameObject Minijoe;
    Vector2 startPos, endPos;

    // Start is called before the first frame update
    void Start()
    {
        //capsule = gameObject.AddComponent(typeof(CapsuleCollider)) as CapsuleCollider;
        //this.GetComponent<CapsuleCollider>().radius = 0.15f;
        //this.GetComponent<CapsuleCollider>().center = Vector3.zero;
        //this.GetComponent<CapsuleCollider>().direction = 2;
        //this.GetComponent<CapsuleCollider>().enabled = false;
        //capsule.radius = 0.15f;
        //capsule.center = Vector3.zero;
        //capsule.direction = 2; // Z-axis for easier "LookAt" orientation

    }

    // Update is called once per frame
    void Update()
    {
        if (Minijoe.GetComponent<MiniJoeLaserController>().shooting == true)
        {
            this.GetComponent<CapsuleCollider>().enabled = true;
            startPos = Minijoe.GetComponent<MiniJoeLaserController>().laserPos1;
            endPos = Minijoe.GetComponent<MiniJoeLaserController>().laserPos2;

            this.GetComponent<CapsuleCollider2D>().transform.position = startPos + (endPos - startPos) / 2;
            this.GetComponent<CapsuleCollider2D>().transform.LookAt(startPos);
            //this.GetComponent<CapsuleCollider>().height = (endPos - startPos).magnitude;
            this.GetComponent<CapsuleCollider2D>().size = new Vector2(0, (endPos - startPos).magnitude);
        }
        else
        {
            this.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
