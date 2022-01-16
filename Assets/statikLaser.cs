using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statikLaser : MonoBehaviour
{
    //Laser 
    Vector2 laserPos1, laserPos2;
    public LineRenderer m_lineRenderer;
    public GameObject collisionLaser, celestialAtk;
    public float defDistanceRay = 100;
    public GameObject laserParticles;

    // Start is called before the first frame update
    void Start()
    {
        laserPos1 = new Vector2(0, 30);
        laserPos2 = new Vector2(0, -100000000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShootLaser()
    {
        Draw2DRay(laserPos1, laserPos2 * defDistanceRay);
        collisionLaser.transform.position = laserPos1;
        laserParticles.transform.position = laserPos1;
        laserParticles.SetActive(true);
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);

    }
}
