using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialNPC1, celestialAtk;
    Transform m_transform;
    Vector2 laserPos1, laserPos2;
    public LineRenderer m_lineRenderer;
    public GameObject collisionLaser;
    public float defDistanceRay = 100;
    public GameObject laserParticles;

    //private new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();

        laserPos1 = new Vector2(0,30);
        laserPos2 = new Vector2(0,-100000000);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void tutorial()
    {
        this.transform.position = new Vector2(-12, 0);
        celestialAtk.SetActive(true);
        Debug.Log("ola");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerTag"))
        {
            tutorial();
        }
    }
    void ShootLaser()
    {

        Draw2DRay(laserPos1, laserPos2 * defDistanceRay);
        collisionLaser.transform.position = laserPos1;
        laserParticles.transform.position = laserPos1;
        //laserParticles.SetActive(true);


        //}
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);

    }
}
