using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{

    public GameObject ataque;
    public GameObject player;
    private bool ataquet = false;
    public float Timer = 0;
    private GameObject ataquei;
    private GameObject ataquei2;
    private GameObject ataquei3;
    private GameObject ataquei4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Timer += Time.deltaTime;
            print("w was pressed");
           // Instantiate(ataque);
            ataquei = Instantiate(ataque);
            ataquet = true;
            if (ataquet == true)
            {
                ataquei.SetActive(true);
                ataquei.transform.position = new Vector2(this.GetComponent<movement>().lastMoveDir.x + transform.position.x, this.GetComponent<movement>().lastMoveDir.y + 2 + transform.position.y);
                ataquei.transform.rotation = Quaternion.Slerp(ataquei.transform.rotation, Quaternion.LookRotation(this.GetComponent<movement>().lastMoveDir), Time.deltaTime * 40f);
            }
          
                Destroy(this.ataquei,1);
        }
        if (Input.GetKeyDown("a"))
        {
            print("a was pressed");
          //  Instantiate(ataque);
            ataquei2 = Instantiate(ataque);
            ataquet = true;
            if (ataquet == true)
            {
                ataquei2.SetActive(true);
                ataquei2.transform.position = new Vector2(this.GetComponent<movement>().lastMoveDir.x - 2 + transform.position.x, this.GetComponent<movement>().lastMoveDir.y + 0 + transform.position.y);
                ataquei2.transform.rotation = Quaternion.Slerp(ataquei.transform.rotation, Quaternion.LookRotation(this.GetComponent<movement>().lastMoveDir), Time.deltaTime * 40f);
            }
            Destroy(this.ataquei2, 1);
        }
        if (Input.GetKeyDown("d"))
        {
            print("d was pressed");
          //  Instantiate(ataque);
            ataquei3 = Instantiate(ataque);
            ataquet = true;
            if (ataquet == true)
            {
                ataquei3.SetActive(true);
                ataquei3.transform.position = new Vector2(this.GetComponent<movement>().lastMoveDir.x + 2 + transform.position.x, this.GetComponent<movement>().lastMoveDir.y +0+ transform.position.y);
                ataquei3.transform.rotation = Quaternion.Slerp(ataquei.transform.rotation, Quaternion.LookRotation(this.GetComponent<movement>().lastMoveDir), Time.deltaTime * 40f);
            }
            Destroy(this.ataquei3, 1);
        }
        if (Input.GetKeyDown("s"))
        {
            print("s was pressed");
         //   Instantiate(ataque);
            ataquei4 = Instantiate(ataque);
            ataquet = true;
            if (ataquet == true)
            {
                ataquei4.SetActive(true);
                ataquei4.transform.position = new Vector2(this.GetComponent<movement>().lastMoveDir.x + 0 + transform.position.x, this.GetComponent<movement>().lastMoveDir.y - 2 + transform.position.y);
                ataquei4.transform.rotation = Quaternion.Slerp(ataquei.transform.rotation, Quaternion.LookRotation(this.GetComponent<movement>().lastMoveDir), Time.deltaTime * 40f);
            }
            Destroy(this.ataquei4, 1);
        }
    }
}
