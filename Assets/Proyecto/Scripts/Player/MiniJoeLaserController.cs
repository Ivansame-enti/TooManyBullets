using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeLaserController : MonoBehaviour
{
    public Vector2 laserPos1, laserPos2;
    public GameObject miniJoePosition, playerPosition;
    public LineRenderer m_lineRenderer;
    //public GameObject collisionLaser;q
    public bool shooting;
    public GameObject mLaserBeam;
    public float laserCoolDown;
    private float timer;
    public Animation ola;
    CapsuleCollider capsule;
    private BoxCollider2D col;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        /*
        capsule = gameObject.AddComponent(typeof(CapsuleCollider)) as CapsuleCollider;
        capsule.radius = 2 / 2;
        capsule.center = Vector3.zero;
        capsule.direction = 2; // Z-axis for easier "LookAt" orientation
        */
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

        //if (col != null) Destroy(col);
        //if (col != null) Destroy(col);

        if (col != null) Destroy(col.gameObject);

        col = new GameObject("Collider").AddComponent<BoxCollider2D>();

        col.transform.parent = mLaserBeam.transform; // Collider is added as child object of line

            //col = mLaserBeam.gameObject.GetComponent<BoxCollider2D>();
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
