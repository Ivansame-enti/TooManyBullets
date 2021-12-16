using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyController : MonoBehaviour
{
    public float speedRotation;
    public float fireRate;
    public float attackDuration;
    private Vector2 laser1Pos1, laser1Pos2, laser2Pos1, laser2Pos2, laser3Pos1, laser3Pos2;
    private float timer, timer2;
    public GameObject mLaserBeam, mLaserBeam2, mLaserBeam3;
    // Start is called before the first frame update
    void Start()
    {
        /*
        laser1Pos2 = new Vector2(this.gameObject.transform.GetChild(0).transform.position.x - 100f, this.gameObject.transform.GetChild(0).transform.position.y + 100f);
        laser2Pos2 = new Vector2(this.gameObject.transform.GetChild(0).transform.position.x + 100f, this.gameObject.transform.GetChild(0).transform.position.y);
        laser3Pos2 = new Vector2(this.gameObject.transform.GetChild(0).transform.position.x, this.gameObject.transform.GetChild(0).transform.position.y + 100f);
        */
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speedRotation * Time.deltaTime); //Rotacion

        laser1Pos1 = this.gameObject.transform.GetChild(0).transform.position;
        laser2Pos1 = this.gameObject.transform.GetChild(1).transform.position;
        laser3Pos1 = this.gameObject.transform.GetChild(2).transform.position;

        laser1Pos2 = new Vector2(this.gameObject.transform.GetChild(3).transform.position.x, this.gameObject.transform.GetChild(3).transform.position.y - 3);
        laser2Pos2 = new Vector2(this.gameObject.transform.GetChild(4).transform.position.x, this.gameObject.transform.GetChild(4).transform.position.y - 3);
        laser3Pos2 = new Vector2(this.gameObject.transform.GetChild(5).transform.position.x, this.gameObject.transform.GetChild(5).transform.position.y - 3);

        if (timer >= fireRate)
        {
            ShootLaser();

            mLaserBeam.SetActive(true);
            mLaserBeam.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
            mLaserBeam.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);

            mLaserBeam2.SetActive(true);
            mLaserBeam2.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
            mLaserBeam2.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);

            mLaserBeam3.SetActive(true);
            mLaserBeam3.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
            mLaserBeam3.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);

            if(timer2 >= attackDuration)
            {
                timer = 0;
                timer2 = 0;
                mLaserBeam.SetActive(false);
                mLaserBeam2.SetActive(false);
                mLaserBeam3.SetActive(false);
            } else
            {
                timer2 += Time.deltaTime;
            }

        } else
        {
            timer += Time.deltaTime;
        }

        void ShootLaser()
        {
            //DIBUJA LASER ENTRE DOS POSICIONES
            Draw2DRay1(laser1Pos1, laser1Pos2);
            Draw2DRay2(laser2Pos1, laser2Pos2);
            Draw2DRay3(laser3Pos1, laser3Pos2);
        }

        void Draw2DRay1(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam.GetComponent<LineRenderer>().SetPosition(1, endPos);
        }

        void Draw2DRay2(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam2.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam2.GetComponent<LineRenderer>().SetPosition(1, endPos);
        }

        void Draw2DRay3(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam3.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam3.GetComponent<LineRenderer>().SetPosition(1, endPos);
        }
    }
}
