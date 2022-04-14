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
    public GameObject enemy;
    private PauseController pc;
    private bool flagPause;
    private float defaultt;
    //private Vector3 OrgPosition;

    public void Start()
    {
        pc = FindObjectOfType<PauseController>();
        flagPause = false;
        
    }
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

    // Update is called once per frame
    void Update()
    {
        if (pc != null)
        {
            if (pc.pauseState == true && flagPause == false)
            {
                defaultt = this.GetComponent<CanvasGroup>().alpha;
                this.GetComponent<CanvasGroup>().alpha = 0;
                flagPause = true;
            }
            if (flagPause == true && pc.pauseState == false)
            {
                flagPause = false;
                this.GetComponent<CanvasGroup>().alpha = defaultt;

            }
        }

        healthBar.transform.position = Camera.main.WorldToScreenPoint(enemy.transform.position + offSet);

        if (pc!=null)
        {
            if (pc.pauseState == false)
            {
                currentTimer += Time.deltaTime;

                if (currentTimer > maxTimer && fadeOut)
                {
                    FadeOutHealthBar();
                }
            }
        }
        else
        {
           currentTimer += Time.deltaTime;

            if (currentTimer > maxTimer && fadeOut)
            {
                FadeOutHealthBar();
            }
        }
        


 

    }

}
