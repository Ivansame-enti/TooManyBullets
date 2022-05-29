using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyController : MonoBehaviour
{
    public float speedRotation;
    public float fireRate;
    public float attackDuration;
    public float warningTime;
    private Vector2 laser1Pos1, laser1Pos2, laser2Pos1, laser2Pos2, laser3Pos1, laser3Pos2, laser1Warning, laser2Warning, laser3Warning;
    private float timer, timer2;
    public GameObject mLaserBeam, mLaserBeam2, mLaserBeam3, mLaserBeam4, mLaserBeam5, mLaserBeam6;
    public GameObject exclamation1, exclamation2, exclamation3;
    private Quaternion originalRotation;
    private Gradient originalLaserColor;
    private BoxCollider2D col, col2, col3;
    private bool warning = false;
    private bool animFinished;
    private bool activeAnimation;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    private AudioManagerController audioSFX;
    private PauseController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PauseController>();
        audioSFX = FindObjectOfType<AudioManagerController>();
        gradient = new Gradient();
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.magenta;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.blue;
        colorKey[1].time = 0.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        activeAnimation = true;
        animFinished = true;
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

        laser1Pos1 = this.gameObject.transform.GetChild(0).transform.position;
        laser2Pos1 = this.gameObject.transform.GetChild(1).transform.position;
        laser3Pos1 = this.gameObject.transform.GetChild(2).transform.position;

        laser1Pos2 = new Vector2(this.gameObject.transform.GetChild(3).transform.position.x, this.gameObject.transform.GetChild(3).transform.position.y - 3);
        laser2Pos2 = new Vector2(this.gameObject.transform.GetChild(4).transform.position.x, this.gameObject.transform.GetChild(4).transform.position.y - 3);
        laser3Pos2 = new Vector2(this.gameObject.transform.GetChild(5).transform.position.x, this.gameObject.transform.GetChild(5).transform.position.y - 3);

        laser1Warning = new Vector2(this.gameObject.transform.GetChild(6).transform.position.x, this.gameObject.transform.GetChild(6).transform.position.y);
        laser2Warning = new Vector2(this.gameObject.transform.GetChild(7).transform.position.x, this.gameObject.transform.GetChild(7).transform.position.y);
        laser3Warning = new Vector2(this.gameObject.transform.GetChild(8).transform.position.x, this.gameObject.transform.GetChild(8).transform.position.y);

        if (timer >= fireRate)
        {
            if (activeAnimation)
            {
                this.GetComponent<Animator>().SetBool("Attack", true);
                animFinished = false;
                activeAnimation = false;
            }
            if (animFinished)
            {
                warning = false;
                exclamation1.SetActive(false);
                exclamation2.SetActive(false);
                exclamation3.SetActive(false);

                ShootLaser();

                mLaserBeam.SetActive(true);
                //mLaserBeam.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
                //mLaserBeam.GetComponent<LineRenderer>().startColor = new Color(255, 255, 0);
                //mLaserBeam.GetComponent<LineRenderer>().endColor = new Color(255, 255, 0);
                //mLaserBeam.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);
                mLaserBeam.GetComponent<LineRenderer>().colorGradient = gradient;
                mLaserBeam.GetComponent<LineRenderer>().startWidth = 0.30f;
                mLaserBeam.GetComponent<LineRenderer>().endWidth = 0.30f;

                mLaserBeam4.SetActive(true);
                //mLaserBeam.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
                //mLaserBeam.GetComponent<LineRenderer>().startColor = new Color(255, 255, 0);
                //mLaserBeam.GetComponent<LineRenderer>().endColor = new Color(255, 255, 0);
                //mLaserBeam.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);
                mLaserBeam4.GetComponent<LineRenderer>().startWidth = 0.15f;
                mLaserBeam4.GetComponent<LineRenderer>().endWidth = 0.15f;

                mLaserBeam5.SetActive(true);
                //mLaserBeam.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
                //mLaserBeam.GetComponent<LineRenderer>().startColor = new Color(255, 255, 0);
                //mLaserBeam.GetComponent<LineRenderer>().endColor = new Color(255, 255, 0);
                //mLaserBeam.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);
                mLaserBeam5.GetComponent<LineRenderer>().startWidth = 0.15f;
                mLaserBeam5.GetComponent<LineRenderer>().endWidth = 0.15f;

                mLaserBeam6.SetActive(true);
                //mLaserBeam.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
                //mLaserBeam.GetComponent<LineRenderer>().startColor = new Color(255, 255, 0);
                //mLaserBeam.GetComponent<LineRenderer>().endColor = new Color(255, 255, 0);
                //mLaserBeam.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);
                mLaserBeam6.GetComponent<LineRenderer>().startWidth = 0.15f;
                mLaserBeam6.GetComponent<LineRenderer>().endWidth = 0.15f;

                mLaserBeam2.SetActive(true);
                //mLaserBeam2.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
                //mLaserBeam2.GetComponent<LineRenderer>().startColor = new Color(255, 125, 0);
                //mLaserBeam2.GetComponent<LineRenderer>().endColor = new Color(255, 125, 0);
                //mLaserBeam2.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);
                mLaserBeam2.GetComponent<LineRenderer>().colorGradient = gradient;
                mLaserBeam2.GetComponent<LineRenderer>().startWidth = 0.30f;
                mLaserBeam2.GetComponent<LineRenderer>().endWidth = 0.30f;

                mLaserBeam3.SetActive(true);
                //mLaserBeam3.GetComponent<LineRenderer>().SetColors(new Color(255, 0, 146), new Color(255, 0, 146));
                //mLaserBeam3.GetComponent<LineRenderer>().startColor = new Color(255, 125, 0);
                //mLaserBeam3.GetComponent<LineRenderer>().endColor = new Color(255, 125, 0);
                //mLaserBeam3.GetComponent<LineRenderer>().SetWidth(0.30f, 0.30f);
                mLaserBeam3.GetComponent<LineRenderer>().colorGradient = gradient;
                mLaserBeam3.GetComponent<LineRenderer>().startWidth = 0.30f;
                mLaserBeam3.GetComponent<LineRenderer>().endWidth = 0.30f;

                if (timer2 >= attackDuration)
                {
                    if (audioSFX.GetAudioPlaying("EnemyLaser")) audioSFX.AudioStop("EnemyLaser");
                    timer = 0;
                    timer2 = 0;
                    mLaserBeam.SetActive(false);
                    mLaserBeam2.SetActive(false);
                    mLaserBeam3.SetActive(false);
                    mLaserBeam4.SetActive(false);
                    mLaserBeam5.SetActive(false);
                    mLaserBeam6.SetActive(false);
                }
                else
                {
                    timer2 += Time.deltaTime;
                }
            } else
            {
                //activeAnimation = true;
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
                //mLaserBeam3.GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
                //mLaserBeam3.GetComponent<LineRenderer>().SetWidth(0.15f, 0.15f);
                mLaserBeam3.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam3.GetComponent<LineRenderer>().endWidth = 0.15f;
            }

        }
        else
        {
            if (timer >= fireRate - warningTime)
            {
                activeAnimation = true;
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
                //mLaserBeam3.GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
                //mLaserBeam3.GetComponent<LineRenderer>().SetWidth(0.15f, 0.15f);
                mLaserBeam3.GetComponent<LineRenderer>().startWidth = 0.25f;
                mLaserBeam3.GetComponent<LineRenderer>().endWidth = 0.15f;
            }
            timer += Time.deltaTime;
        }

        void ShootLaser()
        {
            //DIBUJA LASER ENTRE DOS POSICIONES
            if (warning)
            {
                if (!audioSFX.GetAudioPlaying("EnemyLaser") && pc.pauseState==false) audioSFX.AudioPlay("EnemyLaser");
                //audio.AudioPlay("EnemyLaser");
                Draw2DRay1(laser1Pos1, laser1Warning);
                Draw2DRay2(laser2Pos1, laser2Warning);
                Draw2DRay3(laser3Pos1, laser3Warning);

            }
            else
            {
                Draw2DRay1(laser1Pos1, laser1Pos2);
                Draw2DRay2(laser2Pos1, laser2Pos2);
                Draw2DRay3(laser3Pos1, laser3Pos2);
            }
        }

        void Draw2DRay1(Vector2 startPos, Vector2 endPos)
        {
            mLaserBeam.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam.GetComponent<LineRenderer>().SetPosition(1, endPos);
            mLaserBeam4.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam4.GetComponent<LineRenderer>().SetPosition(1, endPos);

            if (col != null) Destroy(col.gameObject);
            if (!warning)
            {
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
            mLaserBeam5.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam5.GetComponent<LineRenderer>().SetPosition(1, endPos);

            if (col2 != null) Destroy(col2.gameObject);
            if (!warning)
            {
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
            mLaserBeam6.GetComponent<LineRenderer>().SetPosition(0, startPos);
            mLaserBeam6.GetComponent<LineRenderer>().SetPosition(1, endPos);

            if (col3 != null) Destroy(col3.gameObject);
            if (!warning)
            {

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
    }

    public void Attack(string message)
    {
        if (message.Equals("Attack"))
        {
            this.GetComponent<Animator>().SetBool("Attack", false);
            animFinished = true;
        }
    }
}
