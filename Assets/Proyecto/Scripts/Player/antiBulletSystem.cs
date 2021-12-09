using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiBulletSystem : MonoBehaviour
{
    public GameObject antiBulletPower;
    public GameObject PS;
    public float antiBulletdelay;
    public float timer;
    private GameObject antiBulletPowerClone;
    private GameObject antiBulletPowerClone2;
    public GameObject antiBulletPowerRest;
    //private GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        timer = antiBulletdelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MiniJoe>().displanted == false)
        {
            if ((Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("R1")) && timer >= antiBulletdelay)
            {
                FindObjectOfType<AudioManagerController>().AudioPlay("ShieldEffect");
                //this.transform.Find("Shield").gameObject.SetActive(true);
                antiBulletPower.transform.position = this.transform.position;
                antiBulletPowerClone = Instantiate(antiBulletPower, new Vector2(this.transform.position.x, this.transform.position.y), this.transform.rotation);
                //particles = Instantiate(PS, new Vector2(this.transform.position.x, this.transform.position.y), this.transform.rotation);
                //antiBulletPowerClone.transform.parent = gameObject.transform;
                Destroy(antiBulletPowerClone.gameObject, 2f);
                antiBulletPowerClone2 = Instantiate(antiBulletPowerRest, new Vector2(this.transform.position.x, this.transform.position.y), this.transform.rotation);
                //antiBulletPowerClone.transform.parent = gameObject.transform;
                Destroy(antiBulletPowerClone2.gameObject, 2f);
                timer = 0;
            }
            else if (timer <= antiBulletdelay)
            {
                timer += Time.deltaTime;
            }

            if (antiBulletPowerClone != null && antiBulletPowerClone2 != null)
            {
                antiBulletPowerClone.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                antiBulletPowerClone2.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                //particles.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            }
        }
    }

}
