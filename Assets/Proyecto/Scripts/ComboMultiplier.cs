using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboMultiplier : MonoBehaviour
{
    public float maxTimer;
    private float timer;
    public TextMeshProUGUI multiplier;
    private int mult;
    private float scaleAmmount;
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
        mult = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if(muere enemigo) this.transform.position = new Vector3(enemypos.x, enemypos.y +1.0f, enemypos.z);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            multiplier.text = mult.ToString();
            timer = maxTimer;
        }

        scaleAmmount = map(timer, 0, maxTimer, 0, 2);
        this.transform.localScale = new Vector3(scaleAmmount, scaleAmmount, scaleAmmount);
        if(timer > 0) timer -= Time.deltaTime;
    }
}
