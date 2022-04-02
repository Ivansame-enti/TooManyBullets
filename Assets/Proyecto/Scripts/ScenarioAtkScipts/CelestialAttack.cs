using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialAttack : MonoBehaviour
{
    public GameObject warning, celestialAtk;
    private GameObject warningClone;
    public Vector2 positionA, positionB;
    private float nextActionTime = 0.0f;
    private float warningTiming;

    private float timerWarning;
    private float timerAttack;
    public float activacionAtk;
    public float activacionAtkGoing;
    public GameObject collisionLaser;

    private bool atkExist = false, atkGoing = false;
    Vector2 randomValor;
    public float defDistanceRay = 100;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    Vector2 laserPos1, laserPos2;
    public GameObject laserParticles, laserParticles2;
    public int minFrequencylaser, maxFrequencylaser;
    private float originalWidth;
    private float width;
    private bool reduceWidth;
    private float originalBoxColliderSizeX;
    private float originalBoxColliderSizeY;
    private float boxColliderX;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        width = 2.0f;
        originalWidth = celestialAtk.GetComponent<LineRenderer>().startWidth;
        reduceWidth = false;
        originalBoxColliderSizeX = celestialAtk.gameObject.transform.GetChild(2).GetComponent<BoxCollider2D>().size.x;
        originalBoxColliderSizeY = celestialAtk.gameObject.transform.GetChild(2).GetComponent<BoxCollider2D>().size.y;
    }

    void ShootLaser()
    {
        Draw2DRay(laserPos1, laserPos2 * defDistanceRay);
        collisionLaser.transform.position = laserPos1;
        collisionLaser.gameObject.layer = 11;
        laserParticles.transform.position = laserPos1;
        laserParticles2.transform.position = laserPos1;
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);

    }
    // Update is called once per frame
    void Update()
    {
        if (nextActionTime <= 0) //Hace warning
        {
            warningTiming = Random.Range(minFrequencylaser, maxFrequencylaser);
            reduceWidth = false;
            width = originalWidth;
            boxColliderX = originalBoxColliderSizeX;
            celestialAtk.GetComponent<LineRenderer>().SetWidth(originalWidth, originalWidth);
            celestialAtk.gameObject.transform.GetChild(2).GetComponent<BoxCollider2D>().size = new Vector2(originalBoxColliderSizeX, originalBoxColliderSizeY);
            celestialAtk.SetActive(false);
            nextActionTime = warningTiming;

            randomValor = new Vector2(
                Random.Range(positionA.x, positionB.x),
                Random.Range(positionB.y, positionB.y)
            );

            laserPos1 = new Vector2(
             (randomValor.x),
              (randomValor.y+12)
            );
            laserPos2 = new Vector2(
             (randomValor.x),
              (randomValor.y - 100000000)
            );

            warningClone = Instantiate(warning, randomValor, warning.transform.rotation);
            laserParticles.transform.position = laserPos1;
            laserParticles.SetActive(true);
            //Debug.Log("A");
            //atkGoing = true;
            atkExist = true;
            timerWarning = 2f;
        }
        else
        {
            if (!atkGoing && !atkExist)
                nextActionTime -= Time.deltaTime;
        }

        if (timerWarning <= 0 && atkExist) //Laser
        {
            //FindObjectOfType<AudioManagerController>().AudioPlay("Laser");
            //Debug.Log("funciona");
            FindObjectOfType<AudioManagerController>().AudioPlay("Laser");
            atkExist = false;
            atkGoing = true;
            Destroy(warningClone.gameObject);
            ShootLaser();
            celestialAtk.SetActive(true);
            laserParticles2.transform.position = laserPos1;
            laserParticles2.SetActive(true);
            timerAttack = activacionAtk;

        }
        else
        {
            timerWarning -= Time.deltaTime;
        }

        if (timerAttack <= 0 && atkGoing)
        {
            atkGoing = false;
            celestialAtk.SetActive(false);
            laserParticles.SetActive(false);
            laserParticles2.SetActive(false);
            //timer = activacionAtkGoing;
        }
        else
        {
            if (reduceWidth)
            {
                if (width > 0)
                {
                    FindObjectOfType<AudioManagerController>().AudioStop("Laser");
                    //Debug.Log("Bajaaaaa");
                    width -= Time.deltaTime * 2;
                    boxColliderX -= Time.deltaTime;
                    celestialAtk.gameObject.transform.GetChild(2).GetComponent<BoxCollider2D>().size = new Vector2(boxColliderX, originalBoxColliderSizeY);
                    celestialAtk.GetComponent<LineRenderer>().SetWidth(width, width);
                    laserParticles.SetActive(false);
                    laserParticles2.SetActive(false);
                }
                if (width <= 0) timerAttack -= Time.deltaTime;
            }
            if (timerAttack <= 0.2 && atkGoing) reduceWidth = true;
            else timerAttack -= Time.deltaTime;
        }
    }
}
