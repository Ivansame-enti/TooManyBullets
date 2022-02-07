using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialNPC1, celestialAtk;
    private int flag = 0;
    //Laser 
    Transform m_transform;
    Vector2 laserPos1, laserPos2;
    public LineRenderer m_lineRenderer;
    public GameObject collisionLaser;
    public float defDistanceRay = 100;
    public GameObject laserParticles;
    //Enemigo prueba
    public GameObject tutorialEnemy;
    public GameObject tutorialImageControls,tutorialImageDash,tutorialImageAttack;
    public GameObject ps4Moviment, keyboardMovement;


    //private new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        tutorialImageControls.SetActive(true);
        tutorialImageDash.SetActive(false);
        tutorialImageAttack.SetActive(false);
        m_transform = GetComponent<Transform>();
        laserPos1 = new Vector2(0,30);
        laserPos2 = new Vector2(0,-100000000);
        tutorialEnemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerInput.PS4_Controller == true && flag == 0)
        {
            ps4Moviment.SetActive(true);
            keyboardMovement.SetActive(false);
        }
        else
        {
            ps4Moviment.SetActive(false);
            keyboardMovement.SetActive(true);
        }
    }

    private void tutorial()
    {
        if(flag == 0)
        {
            tutorialImageControls.SetActive(false);
            tutorialImageDash.SetActive(true);
            this.transform.position = new Vector2(-12, 0);
            celestialAtk.SetActive(true);


        }
        if(flag == 1)
        {
           tutorialImageDash.SetActive(false);
           tutorialImageAttack.SetActive(true);
           celestialAtk.SetActive(false);
           tutorialEnemy.SetActive(true);
           this.transform.position = new Vector2(-30, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerTag"))
        {
            tutorial();
            flag++;
        }
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
