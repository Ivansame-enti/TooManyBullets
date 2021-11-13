using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialAttack : MonoBehaviour
{
    public Animation CelestialAttackAnim;
    public GameObject warning,celestialAttack;
    public Vector2 positionA, positionB;
    private float nextActionTime = 0.0f;
    public float warningTiming = 5f;


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
        
        if (Time.time > nextActionTime)
        {
            
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



            warning = Instantiate(warning, randomValor, warning.transform.rotation);
            ShootLaser();
            //celestialAttack = Instantiate(celestialAttack,randomValor,celestialAttack.transform.rotation);
            Debug.Log(laserPos1);
            Debug.Log(laserPos2);
            Destroy(warning.gameObject, 5f);
            //Destroy(celestialAttack.gameObject, 5f);

            Debug.Log("ola");
 
                //celestialAttack = Instantiate(celestialAttack, randomValor, celestialAttack.transform.rotation);

                //CelestialAttackAnim.Play();
                //if(exists == true)
                //{

            //}
            //Destroy(WaterDropClone.gameObject, 5f);
        }
    }
}
