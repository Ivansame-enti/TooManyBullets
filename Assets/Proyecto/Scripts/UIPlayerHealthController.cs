using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealthController : MonoBehaviour
{
    public Image healthBar;
    private PlayerHealthController phc;
    // Start is called before the first frame update
    void Start()
    {
        phc = this.GetComponent<PlayerHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)phc.currentHealth/phc.health;
    }
}
