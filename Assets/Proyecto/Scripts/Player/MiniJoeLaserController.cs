using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeLaserController : MonoBehaviour
{
    private Vector2 laserPos1, laserPos2;
    public GameObject miniJoePosition, playerPosition;
    public LineRenderer m_lineRenderer;
    public bool shooting;
    public GameObject mLaserBeam;
    public float laserCoolDown;
    public float warningTimer;
    private bool warning;
    private float timer;
    private BoxCollider2D col;
    public float laserDamage;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MiniJoe>().displanted == true && playerPosition != null)
        {
            laserPos1 = miniJoePosition.transform.position;
            laserPos2 = playerPosition.transform.position;
            ShootLaser();
            if (laserCoolDown <= 0)
            {
                //CREACION DEL LASER
                //Comienza con feedback al jugador
                if (Input.GetKeyDown(KeyCode.E))
                {
                    laserCoolDown = 4f;
                    warningTimer = 1f;
                    mLaserBeam.SetActive(true);
                    m_lineRenderer.SetColors(Color.white,Color.white);
                    m_lineRenderer.SetWidth(0.15f,0.15f);
                    warning = true;
                }
            }
            else
            {
                laserCoolDown -= Time.deltaTime;
            }
            //LASER DISPARA
            if(warningTimer <= 0 && warning == true)
            {
                timer = 1f;
                warning = false;
                shooting = true;
                m_lineRenderer.SetColors(Color.cyan,Color.cyan);
                m_lineRenderer.SetWidth(0.30f,0.30f);
                FindObjectOfType<AudioManagerController>().AudioPlay("MiniJoeLaser");
                playerPosition.GetComponent<movement>().speed /= 2;
            }
            else
            {
                warningTimer -= Time.deltaTime;
            }
            
            //LASER SE CIERRA
            if (timer <= 0 && shooting == true)
            {
                shooting = false;
                mLaserBeam.SetActive(false);
                playerPosition.GetComponent<movement>().speed *= 2;
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
        Draw2DRay(laserPos1, laserPos2);
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);

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
