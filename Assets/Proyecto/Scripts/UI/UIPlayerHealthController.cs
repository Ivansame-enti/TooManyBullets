using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealthController : MonoBehaviour
{
    public Image healthBar;
    public Image healsHealthBar;
    public PlayerHealthController phc;
    public MiniJoeHealController mhc;

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)phc.currentHealth/phc.health;
        if(mhc!= null) healsHealthBar.fillAmount = mhc.currenntHealsAvailable / phc.health;
    }
}
