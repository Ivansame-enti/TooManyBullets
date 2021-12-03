using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniJoeUIController : MonoBehaviour
{
    public Image plantImage;
    public Image activeImage;
    public MiniJoeHealController mhc;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plantImage.fillAmount = mhc.timer2/mhc.healDelay;
    }
}
