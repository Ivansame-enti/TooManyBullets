using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialAttack : MonoBehaviour
{
    public GameObject warning,celestialAtk;
    private GameObject warningClone;
    public Vector2 positionA, positionB;
    private float nextActionTime = 0.0f;
    private float warningTiming;

    private float timer;
    public float activacionAtk;
    public float activacionAtkGoing;

    private bool atkExist = false,atkGoing = false;

    Vector2 randomValor;
    public float defDistanceRay = 100;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    Vector2 laserPos1,laserPos2;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }
    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, transform.right);
            Draw2DRay(laserPos1, _hit.point);
            Debug.Log("AU");
        }
        else
        {
            Draw2DRay(laserPos1, laserPos2 * defDistanceRay);
        }
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);

    }
    // Update is called once per frame
    void Update() 
    {
        warningTiming = Random.Range(10, 15);
        
        if (Time.time > nextActionTime)
        {
            celestialAtk.SetActive(false);
            nextActionTime += warningTiming;

            randomValor = new Vector2(
                Random.Range(positionA.x, positionB.x),
                Random.Range(positionB.y, positionB.y)
            );
            laserPos1 = new Vector2(
             (randomValor.x),
              (randomValor.y+10)
            );
            laserPos2 = new Vector2(
             (randomValor.x),
              (randomValor.y-100000000)
            );


            
            warningClone = Instantiate(warning, randomValor, warning.transform.rotation);
            atkExist = true;
            timer = 2f;
            //if(timer <= 0)
            //{
                //Destroy(warning.gameObject, 2f);
                //ShootLaser();
                //timer = activacionAtk;
            /*}
            else
            {
                timer -= Time.deltaTime;
                
            }
            */
            //celestialAttack = Instantiate(celestialAttack,randomValor,celestialAttack.transform.rotation);
            Debug.Log(laserPos1);
            Debug.Log(laserPos2);
            
            //Destroy(celestialAttack.gameObject, 5f);

            Debug.Log("ola");
 
                //celestialAttack = Instantiate(celestialAttack, randomValor, celestialAttack.transform.rotation);

                //CelestialAttackAnim.Play();
                //if(exists == true)
                //{

            //}
            //Destroy(WaterDropClone.gameObject, 5f);
        }
            if(timer <= 0 && atkExist == true)
            {
            atkExist = false;
            atkGoing = true;
            Destroy(warningClone.gameObject);
            ShootLaser();
            celestialAtk.SetActive(true);
            Debug.Log("ola");
            timer = activacionAtk;
            }
            else
            {
            timer -= Time.deltaTime;
            }

        if (timer <= 0 && atkGoing == true)
        {
            atkGoing = false;
            celestialAtk.SetActive(false);

            timer = activacionAtkGoing;
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }
}
