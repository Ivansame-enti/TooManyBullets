using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapShield : MonoBehaviour
{
    public Animation shieldAnim;
    // Start is called before the first frame update
    void Start()
    {
        shieldAnim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            shieldAnim.Play("shieldMapAnim");
            //StartCoroutine(ScaleOverTime(1, collision));
            //collision.gameObject.transform.localScale = new

        }
    }
}
