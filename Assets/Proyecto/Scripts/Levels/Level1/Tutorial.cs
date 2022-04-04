using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialNPC1, celestialAtk;
    private int flag = 0;
    private float defaultPlayerVel;
    //Laser 
    Transform m_transform;
    Vector2 laserPos1, laserPos2;
    public LineRenderer m_lineRenderer;
    public GameObject collisionLaser;
    public float defDistanceRay = 100;
    public GameObject laserParticles;
    //Enemigo prueba
    public GameObject tutorialEnemy;
    public GameObject tutorialImageControls, tutorialImageDash, tutorialImageAttack;
    public GameObject ps4Moviment, keyboardMovement, xboxAttack, PS4Attack, PS4Dash, xboxDash, keyboarDash, keyboardAttack;
    public movement movementToZero;
    public Nivel1 lvl1;
    public GameObject tutorialEnemies, player;
    public DashController dc;


    //private new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        defaultPlayerVel = movementToZero.speed;
        tutorialImageControls.SetActive(true);
        tutorialImageDash.SetActive(false);
        tutorialImageAttack.SetActive(false);
        m_transform = GetComponent<Transform>();
        laserPos1 = new Vector2(0, 30);
        laserPos2 = new Vector2(0, -100000000);
        tutorialEnemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialEnemies.transform.childCount <= 0 && lvl1.startLevel == false)
        {
            lvl1.startLevel = true;
            movementToZero.speed += defaultPlayerVel;
        }

        if (ControllerInput.PS4_Controller == true || ControllerInput.Xbox_One_Controller == true && flag == 0)
        {
            ps4Moviment.SetActive(true);
            keyboardMovement.SetActive(false);
        }
        else
        {
            ps4Moviment.SetActive(false);
            keyboardMovement.SetActive(true);
        }
        if (ControllerInput.Xbox_One_Controller == true)
        {
            xboxDash.SetActive(true);
            PS4Dash.SetActive(false);
            keyboarDash.SetActive(false);
        }
        else if (ControllerInput.PS4_Controller == true)
        {
            xboxDash.SetActive(false);
            PS4Dash.SetActive(true);
            keyboarDash.SetActive(false);
        }
        else if (ControllerInput.Xbox_One_Controller == false && ControllerInput.PS4_Controller == false)
        {
            xboxDash.SetActive(false);
            PS4Dash.SetActive(false);
            keyboarDash.SetActive(true);
        }

        if (ControllerInput.Xbox_One_Controller == true)
        {
            //Debug.Log("entra aqui");
            xboxAttack.SetActive(true);
            PS4Attack.SetActive(false);
            keyboardAttack.SetActive(false);
        }
        else if (ControllerInput.PS4_Controller == true)
        {
            xboxAttack.SetActive(false);
            PS4Attack.SetActive(true);
            keyboardAttack.SetActive(false);
        }
        else if (ControllerInput.Xbox_One_Controller == false)
        {
            xboxAttack.SetActive(false);
            PS4Attack.SetActive(false);
            keyboardAttack.SetActive(true);
        }


    }

    private void tutorial()
    {
        if (flag == 0)
        {
            tutorialImageControls.SetActive(false);
            tutorialImageDash.SetActive(true);
            this.transform.position = new Vector2(-12, 0);
            celestialAtk.SetActive(true);


        }
        if (flag == 1)
        {

            tutorialImageDash.SetActive(false);
            tutorialImageAttack.SetActive(true);
            celestialAtk.SetActive(false);
            tutorialEnemy.SetActive(true);
            player.transform.position = new Vector2(-11, 0);
            this.transform.position = new Vector2(-30, 0);
            movementToZero.speed -= defaultPlayerVel;
            dc.canDash = false;
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
