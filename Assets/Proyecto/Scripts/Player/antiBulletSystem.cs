using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiBulletSystem : MonoBehaviour
{
    public GameObject antiBulletPower;
    private GameObject antiBulletPowerClone;
    public GameObject antiBulletPowerRest;
    private GameObject antiBulletPowerRestClone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //antiBulletPower.transform.position = this.transform.position;
            antiBulletPowerClone = Instantiate(antiBulletPower, new Vector2(this.transform.position.x, this.transform.position.y), this.transform.rotation);
            antiBulletPowerClone.transform.parent = gameObject.transform;
            Destroy(antiBulletPowerClone.gameObject, 2f);
            antiBulletPowerClone = Instantiate(antiBulletPowerRest, new Vector2(this.transform.position.x, this.transform.position.y), this.transform.rotation);
            antiBulletPowerClone.transform.parent = gameObject.transform;
            Destroy(antiBulletPowerClone.gameObject, 2f);
        }
        
    }

}
