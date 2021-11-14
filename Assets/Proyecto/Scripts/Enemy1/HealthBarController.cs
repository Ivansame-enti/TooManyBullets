using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;
    public Vector3 offSet;
    public float showTime;
    private float currentTimer;
    private float maxTimer;
    private bool fadeOut=false;
    public float fadeOutSpeed;

    public void FadeOutHealthBar()
    {
        float  fadeAmount = this.GetComponent<CanvasGroup>().alpha - (fadeOutSpeed * Time.deltaTime);

        this.GetComponent<CanvasGroup>().alpha = fadeAmount;

        if (this.GetComponent<CanvasGroup>().alpha <= 0f)
        {
            fadeOut = false;
        }
    }

    public void SetHealthBar(float currentHealth, float maxHealth)
    { 
        healthBar.maxValue = maxHealth;
        if (currentHealth < maxHealth)
        {
            healthBar.gameObject.SetActive(true);
            this.GetComponent<CanvasGroup>().alpha = 1;
        }
        healthBar.value = currentHealth;
        maxTimer = currentTimer + showTime;
        fadeOut = true;
    }

    private void Start()
    {
        //maxTimer = Time.deltaTime + showTime;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offSet);

        currentTimer += Time.deltaTime;

        if (currentTimer > maxTimer && fadeOut)
        {
            FadeOutHealthBar();
        }
    }
}
