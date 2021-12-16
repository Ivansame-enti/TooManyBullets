using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyController : MonoBehaviour
{
    public float speedRotation;
    public float fireRate;
    public float attackDuration;
    public float warningTime;
    private Vector2 laser1Pos1, laser1Pos2, laser2Pos1, laser2Pos2, laser3Pos1, laser3Pos2;
    private float timer, timer2;
    public GameObject mLaserBeam, mLaserBeam2, mLaserBeam3;
    public GameObject exclamation1, exclamation2, exclamation3;
    private Quaternion originalRotation;
    private BoxCollider2D col, col2, col3;
    private bool warning = false;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = exclamation1.transform.rotation;
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
        exclamation1.transform.rotation = originalRotation;
        exclamation2.transform.rotation = originalRotation;
        exclamation3.transform.rotation = originalRotation;

        laser1Pos1 = this.gameObject.transform.GetChild(0).transform.position;
        laser2Pos1 = this.gameObject.transform.GetChild(1).transform.position;
        laser3Pos1 = this.gameObject.transform.GetChild(2).transform.position;

        laser1Pos2 = new Vector2(this.gameObject.transform.GetChild(3).transform.position.x, this.gameObject.transform.GetChild(3).transform.position.y - 3);
        laser2Pos2 = new Vector2(this.gameObject.transform.GetChild(4).transform.position.x, this.gameObject.transform.GetChild(4).transform.position.y - 3);
        laser3Pos2 = new Vector2(this.gameObject.transform.GetChild(5).transform.position.x, this.gameObject.transform.GetChild(5).transform.position.y - 3);

        if (timer >= fireRate)
        {
            warning = false;
            exclamation1.SetActive(false);
            exclamation2.SetActive(false);
            exclamation3.SetActive(false);

            ShootLaser();

            //mLaserBeam.SetActive(true);
            mLaserBeam.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
            mLaserBeam.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);

            //mLaserBeam2.SetActive(true);
            mLaserBeam2.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
            mLaserBeam2.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);

            //mLaserBeam3.SetActive(true);
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
            if(timer>= fireRate - warningTime)
            {
                warning = true;
                ShootLaser();
                /*exclamation1.SetActive(true);
                exclamation2.SetActive(true);
                exclamation3.SetActive(true);*/
                mLaserBeam.SetActive(true);
                mLaserBeam.GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
                mLaserBeam.GetComponent<LineRenderer>().SetWidth(0.15f, 0.15f);

                mLaserBeam2.SetActive(true);
                mLaserBeam2.GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
                mLaserBeam2.GetComponent<LineRenderer>().SetWidth(0.15f, 0.15f);

                mLaserBeam3.SetActive(true);
                mLaserBeam3.GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
                mLaserBeam3.GetComponent<LineRenderer>().SetWidth(0.15f, 0.15f);
            }
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

            if (col != null) Destroy(col.gameObject);
            if (!warning)
            {
                col = new GameObject("Collider").AddComponent<BoxCollider2D>();
                col.tag = "LaserColliderEnemy";
                col.gameObject.layer = 8;
                col.transform.parent = mLaserBeam.transform; // Collider is added as child object of line

                float lineLength = Vector3.Distance(startPos, endPos); // length of line

                col.size = new Vector3(lineLength, 0.3f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

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
                col.isTrigger = true;
            }
        }

        void Draw2DRay2(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam2.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam2.GetComponent<LineRenderer>().SetPosition(1, endPos);

            if (col2 != null) Destroy(col2.gameObject);
            if (!warning)
            {
                col2 = new GameObject("Collider2").AddComponent<BoxCollider2D>();
                col2.tag = "LaserColliderEnemy";
                col2.gameObject.layer = 8;
                col2.transform.parent = mLaserBeam2.transform; // Collider is added as child object of line

                float lineLength = Vector3.Distance(startPos, endPos); // length of line

                col2.size = new Vector3(lineLength, 0.3f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

                Vector3 midPoint = (startPos + endPos) / 2;

                col2.transform.position = midPoint; // setting position of collider object
                                                    // Following lines calculate the angle between startPos and endPos
                float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
                if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
                {
                    angle *= -1;
                }
                angle = Mathf.Rad2Deg * Mathf.Atan(angle);
                col2.transform.Rotate(0, 0, angle);
                col2.isTrigger = true;
            }
        }

        void Draw2DRay3(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam3.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam3.GetComponent<LineRenderer>().SetPosition(1, endPos);

            if (col3 != null) Destroy(col3.gameObject);
            if (!warning)
            {
                col3 = new GameObject("Collider3").AddComponent<BoxCollider2D>();
                col3.tag = "LaserColliderEnemy";
                col3.gameObject.layer = 8;
                col3.transform.parent = mLaserBeam3.transform; // Collider is added as child object of line

                float lineLength = Vector3.Distance(startPos, endPos); // length of line

                col3.size = new Vector3(lineLength, 0.3f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

                Vector3 midPoint = (startPos + endPos) / 2;

                col3.transform.position = midPoint; // setting position of collider object
                                                    // Following lines calculate the angle between startPos and endPos
                float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
                if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
                {
                    angle *= -1;
                }
                angle = Mathf.Rad2Deg * Mathf.Atan(angle);
                col3.transform.Rotate(0, 0, angle);
                col3.isTrigger = true;
            }
        }
    }
}
