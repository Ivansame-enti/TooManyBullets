using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeLaserController : MonoBehaviour
{
    private Vector2 laserPos1, laserPos2;
    public GameObject miniJoePosition, playerPosition;
    public LineRenderer m_lineRenderer;
    //public GameObject collisionLaser;q
    private bool shooting;
    public GameObject mLaserBeam;
    public float laserCoolDown;
    private float timer;
    public Animation ola;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(shooting);
        Debug.Log(timer);
        if (GetComponent<MiniJoe>().displanted == true)
        {
            laserPos1 = miniJoePosition.transform.position;
            laserPos2 = playerPosition.transform.position;

            ShootLaser();
            if (laserCoolDown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    laserCoolDown = 4f;
                    //timeRemaining -= Time.deltaTime;
                    shooting = true;
                    timer = 1f;
                    mLaserBeam.SetActive(true);
                    GetComponent<movement>().speed /= 2;
                    ola.Play();

                }
            }
            else
            {
                laserCoolDown -= Time.deltaTime;
            }
            
            if(timer <= 0 && shooting == true)
            {
                shooting = false;
                mLaserBeam.SetActive(false);
                timer = 1f;
                GetComponent<movement>().speed *= 2;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

    }

    void ShootLaser()
    {
        Draw2DRay(laserPos1, laserPos2);
        //collisionLaser.transform.position = laserPos1;

    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);

    }
}
