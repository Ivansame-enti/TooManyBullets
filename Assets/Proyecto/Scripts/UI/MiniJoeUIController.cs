using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniJoeUIController : MonoBehaviour
{
    public GameObject plantUI;
    public Image plantImage;
    public Image activeImage;
    public MiniJoeHealController mhc;
    private Color firstColor;

    // Start is called before the first frame update
    void Start()
    {
        firstColor = plantUI.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (mhc.timer2 >= mhc.healDelay)
        {
            plantUI.gameObject.GetComponent<Animator>().enabled = true;
        } else
        {
            plantUI.gameObject.GetComponent<Animator>().enabled = false;
            plantUI.GetComponent<Image>().color = firstColor;
        }

        plantImage.fillAmount = mhc.timer2/mhc.healDelay;
    }
}
