using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropController : MonoBehaviour
{
    public GameObject WaterDropClone;
    public float DropForce;
    SpriteRenderer rend;
    private Color attackColor = Color.magenta;
    public float scaleTime;
    public GameObject destroyPS;
    private bool level2;
    private bool level8;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (SceneManager.GetActiveScene().name != "Nivel2") level2 = false;
        else level2 = true;
        if (SceneManager.GetActiveScene().name != "BossLevel") level8 = false;
        else level8 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("DropFaster"))
        {
            if(!level2 && !level8) FindObjectOfType<AudioManagerController>().AudioPlay("WaterDrop");
            WaterDropClone.GetComponent<Rigidbody2D>().drag = 0;
            WaterDropClone.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -15,0);
            rend.material.color = attackColor;
        }
        
        if (collision.gameObject.tag.Equals("DestroyBulletCollider"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Shield"))
        {
            //Debug.Log("a");
            //StartCoroutine(ScaleOverTime(scaleTime));
            Instantiate(destroyPS, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
            //Instantiate(destroyPS, this.transform.position, Quaternion.identity);
            //Destroy(gameObject);
            //Debug.Log(collision.transform.localScale);
            //transform.localScale += new Vector3(50f, 50f, 50f);
            //Debug.Log("Nuevo: " + collision.transform.localScale);
            //collision.gameObject.transform.localScale = new
            //Destroy(gameObject);
        }
    }
    
    /*IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3(0.0f, 0.0f, 0.0f);
        Destroy(this.gameObject.GetComponent<CapsuleCollider2D>());
        float currentTime = 0.0f;

        do
        {
            this.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        Instantiate(destroyPS, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }*/
    
}
