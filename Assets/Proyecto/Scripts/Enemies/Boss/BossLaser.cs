using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public float speedRotation;
    public float fireRate;
    public float attackDuration;
    public float warningTime;
    private Vector2 laser1Pos1, laser1Pos2, laser2Pos1, laser2Pos2, laser3Pos1, laser3Pos2, laser4Pos1, laser4Pos2,laser5Pos1,laser5Pos2,laser6Pos1,laser6Pos2, laser7Pos1, laser7Pos2, laser8Pos1, laser8Pos2, laser1Warning, laser2Warning, laser3Warning, laser4Warning, laser5Warning, laser6Warning, laser7Warning, laser8Warning;
    private float timer, timer2;
    public GameObject mLaserBeam, mLaserBeam2, mLaserBeam3,mLaserBeam4, mLaserBeam5, mLaserBeam6, mLaserBeam7, mLaserBeam8, mLaserBeam9, mLaserBeam10, mLaserBeam11, mLaserBeam12, mLaserBeam13, mLaserBeam14, mLaserBeam15, mLaserBeam16;
    public GameObject exclamation1, exclamation2, exclamation3,exclamation4, exclamation5, exclamation6, exclamation7, exclamation8;
    private Quaternion originalRotation;
    private Gradient originalLaserColor;
    private BoxCollider2D col, col2, col3,col4,col5,col6,col7,col8;
    private bool warning = false;
    public bool finish;
    public GameObject laserParticles;
    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        originalRotation = exclamation1.transform.rotation;
        originalLaserColor = mLaserBeam.GetComponent<LineRenderer>().colorGradient;
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
        exclamation4.transform.rotation = originalRotation;
        exclamation5.transform.rotation = originalRotation;
        exclamation6.transform.rotation = originalRotation;
        exclamation7.transform.rotation = originalRotation;
        exclamation8.transform.rotation = originalRotation;

        laser1Pos1 = this.gameObject.transform.GetChild(0).transform.position;
        laser2Pos1 = this.gameObject.transform.GetChild(1).transform.position;
        laser3Pos1 = this.gameObject.transform.GetChild(2).transform.position;
        laser4Pos1 = this.gameObject.transform.GetChild(3).transform.position;
        laser5Pos1 = this.gameObject.transform.GetChild(4).transform.position;
        laser6Pos1 = this.gameObject.transform.GetChild(5).transform.position;
        laser7Pos1 = this.gameObject.transform.GetChild(6).transform.position;
        laser8Pos1 = this.gameObject.transform.GetChild(7).transform.position;

        laser1Pos2 = new Vector2(this.gameObject.transform.GetChild(8).transform.position.x, this.gameObject.transform.GetChild(8).transform.position.y - 3);
        laser2Pos2 = new Vector2(this.gameObject.transform.GetChild(9).transform.position.x, this.gameObject.transform.GetChild(9).transform.position.y - 3);
        laser3Pos2 = new Vector2(this.gameObject.transform.GetChild(10).transform.position.x, this.gameObject.transform.GetChild(10).transform.position.y - 3);
        laser4Pos2 = new Vector2(this.gameObject.transform.GetChild(11).transform.position.x, this.gameObject.transform.GetChild(11).transform.position.y - 3);
        laser5Pos2 = new Vector2(this.gameObject.transform.GetChild(12).transform.position.x, this.gameObject.transform.GetChild(12).transform.position.y - 3);
        laser6Pos2 = new Vector2(this.gameObject.transform.GetChild(13).transform.position.x, this.gameObject.transform.GetChild(13).transform.position.y - 3);
        laser7Pos2 = new Vector2(this.gameObject.transform.GetChild(14).transform.position.x, this.gameObject.transform.GetChild(14).transform.position.y - 3);
        laser8Pos2 = new Vector2(this.gameObject.transform.GetChild(15).transform.position.x, this.gameObject.transform.GetChild(15).transform.position.y - 3);

        laser1Warning = new Vector2(this.gameObject.transform.GetChild(16).transform.position.x, this.gameObject.transform.GetChild(16).transform.position.y);
        laser2Warning = new Vector2(this.gameObject.transform.GetChild(17).transform.position.x, this.gameObject.transform.GetChild(17).transform.position.y);
        laser3Warning = new Vector2(this.gameObject.transform.GetChild(18).transform.position.x, this.gameObject.transform.GetChild(18).transform.position.y);
        laser4Warning = new Vector2(this.gameObject.transform.GetChild(19).transform.position.x, this.gameObject.transform.GetChild(19).transform.position.y);
        laser5Warning = new Vector2(this.gameObject.transform.GetChild(20).transform.position.x, this.gameObject.transform.GetChild(20).transform.position.y);
        laser6Warning = new Vector2(this.gameObject.transform.GetChild(21).transform.position.x, this.gameObject.transform.GetChild(21).transform.position.y);
        laser7Warning = new Vector2(this.gameObject.transform.GetChild(22).transform.position.x, this.gameObject.transform.GetChild(22).transform.position.y);
        laser8Warning = new Vector2(this.gameObject.transform.GetChild(23).transform.position.x, this.gameObject.transform.GetChild(23).transform.position.y);

        if (timer >= fireRate)
        {
            warning = false;
            exclamation1.SetActive(false);
            exclamation2.SetActive(false);
            exclamation3.SetActive(false);
            exclamation4.SetActive(false);
            exclamation5.SetActive(false);
            exclamation6.SetActive(false);
            exclamation7.SetActive(false);
            exclamation8.SetActive(false);

            ShootLaser();

            mLaserBeam.SetActive(true);
            //mLaserBeam.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
            //mLaserBeam.GetComponent<LineRenderer>().startColor = new Color(255, 255, 0);
            //mLaserBeam.GetComponent<LineRenderer>().endColor = new Color(255, 255, 0);
            //mLaserBeam.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);
            mLaserBeam.GetComponent<LineRenderer>().startWidth = 0.30f;
            mLaserBeam.GetComponent<LineRenderer>().endWidth = 0.30f;

            mLaserBeam2.SetActive(true);
            //mLaserBeam2.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
            //mLaserBeam2.GetComponent<LineRenderer>().startColor = new Color(255, 125, 0);
            //mLaserBeam2.GetComponent<LineRenderer>().endColor = new Color(255, 125, 0);
            //mLaserBeam2.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);
            mLaserBeam2.GetComponent<LineRenderer>().startWidth = 0.30f;
            mLaserBeam2.GetComponent<LineRenderer>().endWidth = 0.30f;

            mLaserBeam3.SetActive(true);
            //mLaserBeam3.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
            //mLaserBeam3.GetComponent<LineRenderer>().startColor = new Color(255, 125, 0);
            //mLaserBeam3.GetComponent<LineRenderer>().endColor = new Color(255, 125, 0);
            //mLaserBeam3.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);
            mLaserBeam3.GetComponent<LineRenderer>().startWidth = 0.30f;
            mLaserBeam3.GetComponent<LineRenderer>().endWidth = 0.30f;

            mLaserBeam4.SetActive(true);
            mLaserBeam4.GetComponent<LineRenderer>().startWidth = 0.30f;
            mLaserBeam4.GetComponent<LineRenderer>().endWidth = 0.30f;

            mLaserBeam5.SetActive(true);
            mLaserBeam5.GetComponent<LineRenderer>().startWidth = 0.30f;
            mLaserBeam5.GetComponent<LineRenderer>().endWidth = 0.30f;

            mLaserBeam6.SetActive(true);
            mLaserBeam6.GetComponent<LineRenderer>().startWidth = 0.30f;
            mLaserBeam6.GetComponent<LineRenderer>().endWidth = 0.30f;

            mLaserBeam7.SetActive(true);
            mLaserBeam7.GetComponent<LineRenderer>().startWidth = 0.30f;
            mLaserBeam7.GetComponent<LineRenderer>().endWidth = 0.30f;

            mLaserBeam8.SetActive(true);
            mLaserBeam8.GetComponent<LineRenderer>().startWidth = 0.30f;
            mLaserBeam8.GetComponent<LineRenderer>().endWidth = 0.30f;

            mLaserBeam9.SetActive(true);
            mLaserBeam9.GetComponent<LineRenderer>().startWidth = 0.15f;
            mLaserBeam9.GetComponent<LineRenderer>().endWidth = 0.15f;

            mLaserBeam10.SetActive(true);
            mLaserBeam10.GetComponent<LineRenderer>().startWidth = 0.15f;
            mLaserBeam10.GetComponent<LineRenderer>().endWidth = 0.15f;

            mLaserBeam11.SetActive(true);
            mLaserBeam11.GetComponent<LineRenderer>().startWidth = 0.15f;
            mLaserBeam11.GetComponent<LineRenderer>().endWidth = 0.15f;

            mLaserBeam12.SetActive(true);
            mLaserBeam12.GetComponent<LineRenderer>().startWidth = 0.15f;
            mLaserBeam12.GetComponent<LineRenderer>().endWidth = 0.15f;

            mLaserBeam13.SetActive(true);
            mLaserBeam13.GetComponent<LineRenderer>().startWidth = 0.15f;
            mLaserBeam13.GetComponent<LineRenderer>().endWidth = 0.15f;

            mLaserBeam14.SetActive(true);
            mLaserBeam14.GetComponent<LineRenderer>().startWidth = 0.15f;
            mLaserBeam14.GetComponent<LineRenderer>().endWidth = 0.15f;

            mLaserBeam15.SetActive(true);
            mLaserBeam15.GetComponent<LineRenderer>().startWidth = 0.15f;
            mLaserBeam15.GetComponent<LineRenderer>().endWidth = 0.15f;

            mLaserBeam16.SetActive(true);
            mLaserBeam16.GetComponent<LineRenderer>().startWidth = 0.15f;
            mLaserBeam16.GetComponent<LineRenderer>().endWidth = 0.15f;

            if (timer2 >= attackDuration)
            {
                timer = 0;
                timer2 = 0;
                mLaserBeam.SetActive(false);
                mLaserBeam2.SetActive(false);
                mLaserBeam3.SetActive(false);
                mLaserBeam4.SetActive(false);
                mLaserBeam5.SetActive(false);
                mLaserBeam6.SetActive(false);
                mLaserBeam7.SetActive(false);
                mLaserBeam8.SetActive(false);
                mLaserBeam9.SetActive(false);
                mLaserBeam10.SetActive(false);
                mLaserBeam11.SetActive(false);
                mLaserBeam12.SetActive(false);
                mLaserBeam13.SetActive(false);
                mLaserBeam14.SetActive(false);
                mLaserBeam15.SetActive(false);
                mLaserBeam16.SetActive(false);
                finish = true;

            }
            else
            {
                timer2 += Time.deltaTime;
            }

        }
        else
        {
            if (timer >= fireRate - warningTime)
            {
                warning = true;
                ShootLaser();

                //laser1Warning.transform.position = new Vector3(laser1Pos2) * Time.deltaTime;
                /*exclamation1.SetActive(true);
                exclamation2.SetActive(true);
                exclamation3.SetActive(true);*/

                mLaserBeam.SetActive(true);
                mLaserBeam.GetComponent<LineRenderer>().colorGradient = originalLaserColor;
                //mLaserBeam.GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
                //mLaserBeam.GetComponent<LineRenderer>().SetWidth(0.15f, 0.15f);
                mLaserBeam.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam.GetComponent<LineRenderer>().endWidth = 0.15f;

                mLaserBeam2.SetActive(true);
                mLaserBeam2.GetComponent<LineRenderer>().colorGradient = originalLaserColor;
                //mLaserBeam2.GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
                //mLaserBeam2.GetComponent<LineRenderer>().SetWidth(0.15f, 0.15f);
                mLaserBeam2.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam2.GetComponent<LineRenderer>().endWidth = 0.15f;

                mLaserBeam3.SetActive(true);
                mLaserBeam3.GetComponent<LineRenderer>().colorGradient = originalLaserColor;

                mLaserBeam4.SetActive(true);
                mLaserBeam4.GetComponent<LineRenderer>().colorGradient = originalLaserColor;
                mLaserBeam5.SetActive(true);
                mLaserBeam5.GetComponent<LineRenderer>().colorGradient = originalLaserColor;
                mLaserBeam6.SetActive(true);
                mLaserBeam6.GetComponent<LineRenderer>().colorGradient = originalLaserColor;
                mLaserBeam7.SetActive(true);
                mLaserBeam7.GetComponent<LineRenderer>().colorGradient = originalLaserColor;
                mLaserBeam8.SetActive(true);
                mLaserBeam8.GetComponent<LineRenderer>().colorGradient = originalLaserColor;
                //mLaserBeam3.GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
                //mLaserBeam3.GetComponent<LineRenderer>().SetWidth(0.15f, 0.15f);

                mLaserBeam3.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam3.GetComponent<LineRenderer>().endWidth = 0.15f;
                mLaserBeam4.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam4.GetComponent<LineRenderer>().endWidth = 0.15f;
                mLaserBeam5.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam5.GetComponent<LineRenderer>().endWidth = 0.15f;
                mLaserBeam6.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam6.GetComponent<LineRenderer>().endWidth = 0.15f;
                mLaserBeam7.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam7.GetComponent<LineRenderer>().endWidth = 0.15f;
                mLaserBeam8.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam8.GetComponent<LineRenderer>().endWidth = 0.15f;
            }
            timer += Time.deltaTime;
        }

        void ShootLaser()
        {
            //DIBUJA LASER ENTRE DOS POSICIONES
            if (warning)
            {
                Draw2DRay1(laser1Pos1, laser1Warning);
                Draw2DRay2(laser2Pos1, laser2Warning);
                Draw2DRay3(laser3Pos1, laser3Warning);
                Draw2DRay4(laser4Pos1, laser4Warning);
                Draw2DRay5(laser5Pos1, laser5Warning);
                Draw2DRay6(laser6Pos1, laser6Warning);
                Draw2DRay7(laser7Pos1, laser7Warning);
                Draw2DRay8(laser8Pos1, laser8Warning);

            }
            else
            {
                Draw2DRay1(laser1Pos1, laser1Pos2);
                Draw2DRay2(laser2Pos1, laser2Pos2);
                Draw2DRay3(laser3Pos1, laser3Pos2);
                Draw2DRay4(laser4Pos1, laser4Pos2);
                Draw2DRay5(laser5Pos1, laser5Pos2);
                Draw2DRay6(laser6Pos1, laser6Pos2);
                Draw2DRay7(laser7Pos1, laser7Pos2);
                Draw2DRay8(laser8Pos1, laser8Pos2);
            }
        }

        void Draw2DRay1(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam.GetComponent<LineRenderer>().SetPosition(1, endPos);
            mLaserBeam9.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam9.GetComponent<LineRenderer>().SetPosition(1, endPos);
            if (col != null) Destroy(col.gameObject);
            if (!warning)
            {
                //for (float i = 0; i < 1; i = i + 0.07f)
                    //Instantiate(laserParticles, Vector3.Lerp(startPos, endPos, i), Quaternion.identity);
                col = new GameObject("Collider").AddComponent<BoxCollider2D>();
                col.tag = "LaserColliderEnemy";
                col.gameObject.layer = 8;
                //col.gameObject.AddComponent<Rigidbody2D>();
                //col.gameObject.AddComponent<LaserCollisionController>();

                col.isTrigger = true;
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
            }
        }

        void Draw2DRay2(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam2.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam2.GetComponent<LineRenderer>().SetPosition(1, endPos);
            mLaserBeam10.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam10.GetComponent<LineRenderer>().SetPosition(1, endPos);
            if (col2 != null) Destroy(col2.gameObject);
            if (!warning)
            {
                //for (float i = 0; i < 1; i = i + 0.07f)
                   // Instantiate(laserParticles, Vector3.Lerp(startPos, endPos, i), Quaternion.identity);
                col2 = new GameObject("Collider2").AddComponent<BoxCollider2D>();
                col2.tag = "LaserColliderEnemy";
                col2.gameObject.layer = 8;
                //col2.gameObject.AddComponent<Rigidbody2D>();
                //col2.gameObject.AddComponent<LaserCollisionController>();
                col2.isTrigger = true;
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
            }
        }

        void Draw2DRay3(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam3.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam3.GetComponent<LineRenderer>().SetPosition(1, endPos);
            mLaserBeam11.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam11.GetComponent<LineRenderer>().SetPosition(1, endPos);
            if (col3 != null) Destroy(col3.gameObject);
            if (!warning)
            {
                //for (float i = 0; i < 1; i = i + 0.07f)
                    //Instantiate(laserParticles, Vector3.Lerp(startPos, endPos, i), Quaternion.identity);
                col3 = new GameObject("Collider3").AddComponent<BoxCollider2D>();
                col3.tag = "LaserColliderEnemy";
                col3.gameObject.layer = 8;
                //col3.gameObject.AddComponent<Rigidbody2D>();
                //col3.gameObject.AddComponent<LaserCollisionController>();
                col3.transform.parent = mLaserBeam3.transform; // Collider is added as child object of line
                col3.isTrigger = true;
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
            }
        }

        void Draw2DRay4(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam4.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam4.GetComponent<LineRenderer>().SetPosition(1, endPos);
            mLaserBeam12.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam12.GetComponent<LineRenderer>().SetPosition(1, endPos);
            if (col4 != null) Destroy(col4.gameObject);
            if (!warning)
            {
                //for (float i = 0; i < 1; i = i + 0.07f)
                    //Instantiate(laserParticles, Vector3.Lerp(startPos, endPos, i), Quaternion.identity);
                col4 = new GameObject("Collider4").AddComponent<BoxCollider2D>();
                col4.tag = "LaserColliderEnemy";
                col4.gameObject.layer = 8;
                //col4.gameObject.AddComponent<Rigidbody2D>();
                //col4.gameObject.AddComponent<LaserCollisionController>();
                col4.transform.parent = mLaserBeam4.transform; // Collider is added as child object of line
                col4.isTrigger = true;
                float lineLength = Vector3.Distance(startPos, endPos); // length of line

                col4.size = new Vector3(lineLength, 0.4f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

                Vector3 midPoint = (startPos + endPos) / 2;

                col4.transform.position = midPoint; // setting position of collider object
                                                    // Following lines calculate the angle between startPos and endPos
                float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
                if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
                {
                    angle *= -1;
                }
                angle = Mathf.Rad2Deg * Mathf.Atan(angle);
                col4.transform.Rotate(0, 0, angle);
            }
        }

        void Draw2DRay5(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam5.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam5.GetComponent<LineRenderer>().SetPosition(1, endPos);
            mLaserBeam13.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam13.GetComponent<LineRenderer>().SetPosition(1, endPos);
            if (col5 != null) Destroy(col5.gameObject);
            if (!warning)
            {
                //for (float i = 0; i < 1; i = i + 0.07f)
                    //Instantiate(laserParticles, Vector3.Lerp(startPos, endPos, i), Quaternion.identity);
                col5 = new GameObject("Collider5").AddComponent<BoxCollider2D>();
                col5.tag = "LaserColliderEnemy";
                col5.gameObject.layer = 8;
                //col5.gameObject.AddComponent<Rigidbody2D>();
                //col5.gameObject.AddComponent<LaserCollisionController>();
                col5.transform.parent = mLaserBeam5.transform; // Collider is added as child object of line
                col5.isTrigger = true;
                float lineLength = Vector3.Distance(startPos, endPos); // length of line

                col5.size = new Vector3(lineLength, 0.5f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

                Vector3 midPoint = (startPos + endPos) / 2;

                col5.transform.position = midPoint; // setting position of collider object
                                                    // Following lines calculate the angle between startPos and endPos
                float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
                if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
                {
                    angle *= -1;
                }
                angle = Mathf.Rad2Deg * Mathf.Atan(angle);
                col5.transform.Rotate(0, 0, angle);
            }
        }

        void Draw2DRay6(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam6.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam6.GetComponent<LineRenderer>().SetPosition(1, endPos);
            mLaserBeam14.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam14.GetComponent<LineRenderer>().SetPosition(1, endPos);
            if (col6 != null) Destroy(col6.gameObject);
            if (!warning)
            {
                //for (float i = 0; i < 1; i = i + 0.07f)
                    //Instantiate(laserParticles, Vector3.Lerp(startPos, endPos, i), Quaternion.identity);
                col6 = new GameObject("Collider6").AddComponent<BoxCollider2D>();
                col6.tag = "LaserColliderEnemy";
                col6.gameObject.layer = 8;
                //col6.gameObject.AddComponent<Rigidbody2D>();
                //col6.gameObject.AddComponent<LaserCollisionController>();
                col6.transform.parent = mLaserBeam6.transform; // Collider is added as child object of line
                col6.isTrigger = true;
                float lineLength = Vector3.Distance(startPos, endPos); // length of line

                col6.size = new Vector3(lineLength, 0.6f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

                Vector3 midPoint = (startPos + endPos) / 2;

                col6.transform.position = midPoint; // setting position of collider object
                                                    // Following lines calculate the angle between startPos and endPos
                float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
                if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
                {
                    angle *= -1;
                }
                angle = Mathf.Rad2Deg * Mathf.Atan(angle);
                col6.transform.Rotate(0, 0, angle);
            }
        }
        void Draw2DRay7(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam7.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam7.GetComponent<LineRenderer>().SetPosition(1, endPos);
            mLaserBeam15.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam15.GetComponent<LineRenderer>().SetPosition(1, endPos);
            if (col7 != null) Destroy(col7.gameObject);
            if (!warning)
            {
                //for (float i = 0; i < 1; i = i + 0.07f)
                    //Instantiate(laserParticles, Vector3.Lerp(startPos, endPos, i), Quaternion.identity);
                col7 = new GameObject("Collider7").AddComponent<BoxCollider2D>();
                col7.tag = "LaserColliderEnemy";
                col7.gameObject.layer = 8;
                //col7.gameObject.AddComponent<Rigidbody2D>();
                //col7.gameObject.AddComponent<LaserCollisionController>();
                col7.transform.parent = mLaserBeam7.transform; // Collider is added as child object of line
                col7.isTrigger = true;
                float lineLength = Vector3.Distance(startPos, endPos); // length of line

                col7.size = new Vector3(lineLength, 0.7f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

                Vector3 midPoint = (startPos + endPos) / 2;

                col7.transform.position = midPoint; // setting position of collider object
                                                    // Following lines calculate the angle between startPos and endPos
                float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
                if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
                {
                    angle *= -1;
                }
                angle = Mathf.Rad2Deg * Mathf.Atan(angle);
                col7.transform.Rotate(0, 0, angle);
            }
        }

        void Draw2DRay8(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam8.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam8.GetComponent<LineRenderer>().SetPosition(1, endPos);
            mLaserBeam16.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam16.GetComponent<LineRenderer>().SetPosition(1, endPos);
            if (col8 != null) Destroy(col8.gameObject);
            if (!warning)
            {
                //for (float i = 0; i < 1; i = i + 0.07f)
                    //Instantiate(laserParticles, Vector3.Lerp(startPos, endPos, i), Quaternion.identity);
                col8 = new GameObject("Collider8").AddComponent<BoxCollider2D>();
                col8.tag = "LaserColliderEnemy";
                col8.gameObject.layer = 8;
                //col8.gameObject.AddComponent<Rigidbody2D>();
                //col8.gameObject.AddComponent<LaserCollisionController>();
                col8.transform.parent = mLaserBeam8.transform; // Collider is added as child object of line
                col8.isTrigger = true;
                float lineLength = Vector3.Distance(startPos, endPos); // length of line

                col8.size = new Vector3(lineLength, 0.8f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

                Vector3 midPoint = (startPos + endPos) / 2;

                col8.transform.position = midPoint; // setting position of collider object
                                                    // Following lines calculate the angle between startPos and endPos
                float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
                if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
                {
                    angle *= -1;
                }
                angle = Mathf.Rad2Deg * Mathf.Atan(angle);
                col8.transform.Rotate(0, 0, angle);
            }
        }
    }
}
