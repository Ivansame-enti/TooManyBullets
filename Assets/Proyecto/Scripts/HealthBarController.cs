using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;
    public Vector3 offSet;
    public float showTime;

    public void SetHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.maxValue = maxHealth;
        if (currentHealth < maxHealth)
        {
            healthBar.gameObject.SetActive(true);
        }
        else
        {
            healthBar.gameObject.SetActive(false);
        }
        healthBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offSet);
    }
}
