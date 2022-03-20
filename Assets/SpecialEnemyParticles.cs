using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyParticles : MonoBehaviour
{
    //public GameObject target;
    public GameObject heatHeal;
    private float speed;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        target = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
        //Debug.Log(Vector3.Distance(this.transform.position, target.transform.position));
        if (Vector3.Distance(this.transform.position, target.transform.position) == 90f)
        {
            
            if(GameObject.Find("MiniJoe")!=null) GameObject.Find("MiniJoe").GetComponent<MiniJoeHealController>().currenntHealsAvailable++;
            Instantiate(heatHeal, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
