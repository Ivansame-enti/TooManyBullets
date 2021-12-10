using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyController : MonoBehaviour
{
    public float speedRotation;
    private Vector2 laser1Pos1, laser1Pos2, laser2Pos1, laser2Pos2, laser3Pos1, laser3Pos2;
    public LineRenderer m_lineRenderer;
    public GameObject mLaserBeam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speedRotation * Time.deltaTime); //Rotacion

        laser1Pos1 = this.gameObject.transform.GetChild(0).transform.position;
        laser2Pos1 = this.gameObject.transform.GetChild(1).transform.position;
        laser3Pos1 = this.gameObject.transform.GetChild(2).transform.position;

        laser1Pos2 = new Vector2(this.gameObject.transform.GetChild(0).transform.position.x - 100f, this.gameObject.transform.GetChild(0).transform.position.y);
        laser2Pos2 = new Vector2(this.gameObject.transform.GetChild(0).transform.position.x + 100f, this.gameObject.transform.GetChild(0).transform.position.y);
        laser3Pos2 = new Vector2(this.gameObject.transform.GetChild(0).transform.position.x, this.gameObject.transform.GetChild(0).transform.position.y + 100f);

        ShootLaser();

        mLaserBeam.SetActive(true);
        m_lineRenderer.SetColors(Color.cyan, Color.cyan);
        m_lineRenderer.SetWidth(0.30f, 0.30f);

        void ShootLaser()
        {
            //DIBUJA LASER ENTRE DOS POSICIONES
            Draw2DRay(laser1Pos1, laser1Pos2);
            //Draw2DRay(laser2Pos1, laser2Pos2);
            //Draw2DRay(laser3Pos1, laser3Pos2);
        }

        void Draw2DRay(Vector2 startPos, Vector2 endPos)
        {
            m_lineRenderer.SetPosition(0, startPos);
            m_lineRenderer.SetPosition(1, endPos);

            //if (shooting == true)
            // {
            /*
                 if (col != null) Destroy(col.gameObject);

                 col = new GameObject("Collider").AddComponent<BoxCollider2D>();
                 col.tag = "MjLaserCollider";
                 col.gameObject.AddComponent<mJLaserDamage>();
                 col.gameObject.GetComponent<mJLaserDamage>().LaserDamage = laserDamage;
                 col.transform.parent = mLaserBeam.transform; // Collider is added as child object of line
            */
            float lineLength = Vector3.Distance(startPos, endPos); // length of line

            //col.size = new Vector3(lineLength, 0.3f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

            Vector3 midPoint = (startPos + endPos) / 2;

            //col.transform.position = midPoint; // setting position of collider object
            // Following lines calculate the angle between startPos and endPos
            /*
float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
{
angle *= -1;
}
angle = Mathf.Rad2Deg * Mathf.Atan(angle);*/
            //col.transform.Rotate(0, 0, angle);
            //col.isTrigger = true;
        }
    }




}
