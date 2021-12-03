using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeLaserController : MonoBehaviour
{
    public Vector2 laserPos1, laserPos2;
    public GameObject miniJoePosition, playerPosition;
    public LineRenderer m_lineRenderer;
    //public GameObject collisionLaser;
    private bool shooting;
    public GameObject mLaserBeam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<MiniJoe>().displanted == true)
        {

            ShootLaser();
            if (Input.GetKeyDown(KeyCode.E))
            {
                laserPos1 = miniJoePosition.transform.position;
                laserPos2 = playerPosition.transform.position;
                mLaserBeam.SetActive(true);
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
