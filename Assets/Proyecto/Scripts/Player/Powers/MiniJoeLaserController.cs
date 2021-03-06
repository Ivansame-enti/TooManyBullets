using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeLaserController : MonoBehaviour
{
    private Vector2 laserPos1, laserPos2, laserPosWarning;
    public GameObject miniJoePosition, playerPosition;
    public LineRenderer m_lineRenderer, m_lineRenderer1;
    public bool shooting;
    public GameObject mLaserBeam, mLaserBeam1;
    private Gradient originalLaserColor;
    public float laserCoolDown;
    public bool warningTimer;
    private bool warning;
    private float timer;
    private BoxCollider2D col;
    public float laserDamage;
    public float timerLaser;
    public float laserSpeed;
    public GameObject laserParticles;
    private bool boolParticles;

    private void Start()
    {
        timerLaser = laserCoolDown;
        originalLaserColor = m_lineRenderer.colorGradient;
        boolParticles = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MiniJoe>().displanted == true && playerPosition != null && playerPosition != null)
        {
            laserPos1 = miniJoePosition.transform.position;
            if (warning == false) laserPosWarning = laserPos1;
            laserPos2 = playerPosition.transform.position;

            ShootLaser();
            if (timerLaser >= laserCoolDown)
            {
                //CREACION DEL LASER
                //Comienza con feedback al jugador

                if (ControllerInput.Xbox_One_Controller)
                {
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("RB"))
                    {
                        timerLaser = 0;
                        warningTimer = true;
                        mLaserBeam.SetActive(true);
                        mLaserBeam1.SetActive(true);
                        //m_lineRenderer.SetColors(Color.white,Color.white);
                        m_lineRenderer.colorGradient = originalLaserColor;
                        //m_lineRenderer.endColor = Color.white;
                        //m_lineRenderer.SetWidth(0.15f,0.15f);
                        m_lineRenderer.startWidth = 0.20f;
                        m_lineRenderer.endWidth = 0.10f;

                        m_lineRenderer1.startWidth = 0.10f;
                        m_lineRenderer1.endWidth = 0.05f;
                        warning = true;
                    }
                }
                else if (ControllerInput.PS4_Controller)
                {
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("R1"))
                    {
                        timerLaser = 0;
                        warningTimer = true;
                        mLaserBeam.SetActive(true);
                        mLaserBeam1.SetActive(true);
                        //m_lineRenderer.SetColors(Color.white,Color.white);
                        m_lineRenderer.colorGradient = originalLaserColor;
                        //m_lineRenderer.endColor = Color.white;
                        //m_lineRenderer.SetWidth(0.15f,0.15f);
                        m_lineRenderer.startWidth = 0.20f;
                        m_lineRenderer.endWidth = 0.10f;
                        m_lineRenderer1.startWidth = 0.10f;
                        m_lineRenderer1.endWidth = 0.05f;
                        warning = true;
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        timerLaser = 0;
                        warningTimer = true;
                        mLaserBeam.SetActive(true);
                        mLaserBeam1.SetActive(true);
                        //m_lineRenderer.SetColors(Color.white,Color.white);
                        m_lineRenderer.colorGradient = originalLaserColor;
                        //m_lineRenderer.endColor = Color.white;
                        //m_lineRenderer.SetWidth(0.15f,0.15f);
                        m_lineRenderer.startWidth = 0.20f;
                        m_lineRenderer.endWidth = 0.10f;
                        m_lineRenderer1.startWidth = 0.10f;
                        m_lineRenderer1.endWidth = 0.05f;
                        warning = true;
                    }
                }                
            }
            else if(timerLaser <= laserCoolDown)
            {
                timerLaser += Time.deltaTime;
            }
            //LASER DISPARA
            if(warningTimer==false && warning == true)
            {
                //laserPosWarning = laserPos1;
                timer = 1f;
                warning = false;
                shooting = true;
                //m_lineRenderer.SetColors(Color.cyan,Color.cyan);
                m_lineRenderer.startColor = Color.cyan;
                m_lineRenderer.endColor = Color.cyan;
                //m_lineRenderer.SetWidth(0.30f,0.30f);
                m_lineRenderer.startWidth = 0.20f;
                m_lineRenderer.endWidth = 0.10f;
                m_lineRenderer1.startWidth = 0.10f;
                m_lineRenderer1.endWidth = 0.05f;
                FindObjectOfType<AudioManagerController>().AudioPlay("MiniJoeLaser");
                //playerPosition.GetComponent<movement>().speed /= 2;
            }
            
            //LASER SE CIERRA
            if (timer <= 0 && shooting == true)
            {
                shooting = false;
                boolParticles = false;
                mLaserBeam.SetActive(false);
                mLaserBeam1.SetActive(false);
                //playerPosition.GetComponent<movement>().speed *= 2;
                if (col != null) Destroy(col.gameObject);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

    }

    void ShootLaser()
    {
        //DIBUJA LASER ENTRE DOS POSICIONES
        if (warning)
        {
            laserPosWarning = Vector2.MoveTowards(laserPosWarning, laserPos2, laserSpeed * Time.deltaTime);
            Draw2DRay(laserPos1, laserPosWarning);
            if (Vector2.Distance(laserPosWarning, laserPos2) == 0)
            {
                warningTimer = false;
                laserPosWarning = laserPos1;
            }
        }
        else
        {
            Draw2DRay(laserPos1, laserPos2);
            //Vector3 interpolatedPosition = Vector3.Lerp(laserPos1, laserPos2, 0.1f);
            if (!boolParticles && shooting && mLaserBeam.active == true)
            {
                for(float i=0; i<1; i=i+0.02f)
                    Instantiate(laserParticles, Vector3.Lerp(laserPos1, laserPos2, i), Quaternion.identity);
                /*Instantiate(laserParticles, Vector3.Lerp(laserPos1, laserPos2, 0.2f), Quaternion.identity);
                Instantiate(laserParticles, Vector3.Lerp(laserPos1, laserPos2, 0.3f), Quaternion.identity);
                Instantiate(laserParticles, Vector3.Lerp(laserPos1, laserPos2, 0.4f), Quaternion.identity);
                Instantiate(laserParticles, Vector3.Lerp(laserPos1, laserPos2, 0.5f), Quaternion.identity);
                Instantiate(laserParticles, Vector3.Lerp(laserPos1, laserPos2, 0.6f), Quaternion.identity);
                Instantiate(laserParticles, Vector3.Lerp(laserPos1, laserPos2, 0.7f), Quaternion.identity);
                Instantiate(laserParticles, Vector3.Lerp(laserPos1, laserPos2, 0.8f), Quaternion.identity);
                Instantiate(laserParticles, Vector3.Lerp(laserPos1, laserPos2, 0.9f), Quaternion.identity);*/

                //boolParticles = true;
            }
        }
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);

        m_lineRenderer1.SetPosition(0, startPos);
        m_lineRenderer1.SetPosition(1, endPos);

        if (shooting == true)
        {
            if (col != null) Destroy(col.gameObject);

            col = new GameObject("Collider").AddComponent<BoxCollider2D>();
            col.tag = "MjLaserCollider";
            col.gameObject.AddComponent<mJLaserDamage>();
            col.gameObject.GetComponent<mJLaserDamage>().LaserDamage = laserDamage;
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
}
