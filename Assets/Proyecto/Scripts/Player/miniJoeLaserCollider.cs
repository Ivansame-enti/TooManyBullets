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
        /*if (Minijoe.GetComponent<MiniJoeLaserController>().shooting == true)
        {
            
            this.GetComponent<BoxCollider2D>().enabled = true;
            startPos = Minijoe.GetComponent<MiniJoeLaserController>().laserPos1;
            endPos = Minijoe.GetComponent<MiniJoeLaserController>().laserPos2;

            this.GetComponent<BoxCollider2D>().transform.position = startPos + (endPos - startPos) / 2;
            //this.GetComponent<BoxCollider2D>().transform.LookAt(startPos);
            //this.GetComponent<CapsuleCollider>().height = (endPos - startPos).magnitude;
            //this.GetComponent<CapsuleCollider2D>().size = new Vector2(1, 2);
            
            /*BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider>();
            //col.transform.parent = line.transform; // Collider is added as child object of line
            float lineLength = Vector3.Distance(startPos, endPos); // length of line
            col.size = new Vector3(lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
            Vector3 midPoint = (startPos + endPos) / 2;
            col.transform.position = midPoint; // setting position of collider object
                                               // Following lines calculate the angle between startPos and endPos
            float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
            if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
            {
                angle *= -1;
            }
            angle = Mathf.Rad2Deg * Mathf.Atan(angle);
            col.transform.Rotate(0, 0, angle);
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }*/
    }
}
