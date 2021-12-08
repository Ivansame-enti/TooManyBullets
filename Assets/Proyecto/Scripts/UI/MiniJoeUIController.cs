using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniJoeUIController : MonoBehaviour
{
    public GameObject plantImage;
    public Image plantImageGreen;
    public Image activeImage1;
    public Image activeImage2;
    public MiniJoeHealController mhc;
    private Color firstColorPlant;
    private Color firstColorActive1;
    private Color firstColorActive2;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        firstColorPlant = plantImage.GetComponent<Image>().color;
        firstColorActive1 = activeImage1.color;
        firstColorActive2 = activeImage2.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (mhc.timer2 >= mhc.healDelay)
        {
            plantImage.gameObject.GetComponent<Animator>().enabled = true;
        } else
        {
            plantImage.gameObject.GetComponent<Animator>().enabled = false;
            plantImage.GetComponent<Image>().color = firstColorPlant;
        }

        plantImageGreen.fillAmount = mhc.timer2/mhc.healDelay;

        if (active)
        {
            activeImage1.gameObject.GetComponent<Animator>().enabled = true;
            activeImage2.gameObject.GetComponent<Animator>().enabled = true;
        } else
        {
            activeImage1.gameObject.GetComponent<Animator>().enabled = false;
            activeImage2.gameObject.GetComponent<Animator>().enabled = false;
            activeImage1.color = firstColorActive1;
            activeImage2.color = firstColorActive2;
        }
    }
}
