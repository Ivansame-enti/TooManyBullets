using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MiniJoeUIController : MonoBehaviour
{
    //public GameObject plant;
    public Image plantImage;
    public Image plantImageGreen;
    public float fadeOutSpeed;
    public GameObject activeIn;

    public GameObject pasive;
    public Image pasiveImage;
    public Image pasiveImageGreen;

    private MiniJoeHealController mhc;
    private antiBulletSystem abs;
    private MiniJoeLaserController mlc;
    private MiniJoe m;
    public GameObject miniJoe;

    private Color firstColorPlant;
    private Color firstColorPasive;
    private Color originalColor;
    private bool nivel3;
    private bool fadeOut;
    //public bool active;
    //public bool miniJoeIn;

    // Start is called before the first frame update
    void Start()
    {
        fadeOut = true;
        mhc = miniJoe.gameObject.GetComponent<MiniJoeHealController>();
        abs = miniJoe.gameObject.GetComponent<antiBulletSystem>();
        mlc = miniJoe.gameObject.GetComponent<MiniJoeLaserController>();
        m = miniJoe.gameObject.GetComponent<MiniJoe>();
        //plant.SetActive(true);
        firstColorPlant = plantImage.color;
        firstColorPasive = pasiveImage.color;
        if (SceneManager.GetActiveScene().name != "Nivel3") nivel3 = false;
        else nivel3 = true;
        originalColor = activeIn.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (nivel3)
        {
            plantImage.enabled = false;
            plantImageGreen.enabled = false;
            
        }

        if (miniJoe != null)
        {
            if (m.timer >= m.plantCD) //Curacion
            {
                plantImage.gameObject.GetComponent<Animator>().enabled = true;
            }
            else
            {
                plantImage.gameObject.GetComponent<Animator>().enabled = false;
                plantImage.color = firstColorPlant;
            }

            plantImageGreen.fillAmount = m.timer / m.plantCD;
            
            if (miniJoe.GetComponent<MiniJoe>().displanted == false) //Cuando miniJoe va contigo
            {
                pasive.SetActive(false);
                activeIn.SetActive(true);
                /*
                pasive.SetActive(true);

                if (mhc.currenntHealsAvailable>0) //Curacion
                {
                    //plantImage.gameObject.GetComponent<Animator>().enabled = true;
                    pasiveImage.gameObject.GetComponent<Animator>().enabled = true;
                }
                else
                {
                    pasiveImage.gameObject.GetComponent<Animator>().enabled = false;
                    pasiveImage.color = firstColorPasive;
                }*/
                activeIn.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                //pasiveImageGreen.fillAmount = ((float)mhc.currenntHealsAvailable) / ((float)mhc.healsAvailable);

                activeIn.transform.position = new Vector3(miniJoe.transform.position.x+0.25f, miniJoe.transform.position.y - 0.3f, 1);

                activeIn.GetComponent<Image>().fillAmount = abs.timer / abs.antiBulletdelay;

                if (activeIn.GetComponent<Image>().fillAmount == 1)
                {
                    if (fadeOut)
                    {
                        float fadeAmount = activeIn.GetComponent<Image>().color.a - (fadeOutSpeed * Time.deltaTime);
                        activeIn.GetComponent<Image>().color = new Color(activeIn.GetComponent<Image>().color.r, activeIn.GetComponent<Image>().color.g, activeIn.GetComponent<Image>().color.b, fadeAmount);

                        if (activeIn.GetComponent<Image>().color.a <= 0f)
                        {
                            fadeOut = false;
                        }
                    }
                }
                else
                {
                    activeIn.GetComponent<Image>().color = originalColor;
                    fadeOut = true;
                }
            }
            else //Minioe plantado
            {
                //pasive.SetActive(false);
                pasive.SetActive(true);

                if (mhc.currenntHealsAvailable > 0) //Curacion
                {
                    //plantImage.gameObject.GetComponent<Animator>().enabled = true;
                    pasiveImage.gameObject.GetComponent<Animator>().enabled = true;
                }
                else
                {
                    pasiveImage.gameObject.GetComponent<Animator>().enabled = false;
                    pasiveImage.color = firstColorPasive;
                }
                pasiveImageGreen.fillAmount = ((float)mhc.currenntHealsAvailable) / ((float)mhc.healsAvailable);

                //activeOutImageGreen.fillAmount = mlc.timerLaser / mlc.laserCoolDown;
                activeIn.gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                activeIn.transform.position = new Vector3(miniJoe.transform.position.x+0.65f, miniJoe.transform.position.y-0.8f, 1);

                activeIn.GetComponent<Image>().fillAmount = mlc.timerLaser / mlc.laserCoolDown;

                if (activeIn.GetComponent<Image>().fillAmount == 1)
                {
                    if (fadeOut)
                    {
                        float fadeAmount = activeIn.GetComponent<Image>().color.a - (fadeOutSpeed * Time.deltaTime);
                        activeIn.GetComponent<Image>().color = new Color(activeIn.GetComponent<Image>().color.r, activeIn.GetComponent<Image>().color.g, activeIn.GetComponent<Image>().color.b, fadeAmount);

                        if (activeIn.GetComponent<Image>().color.a <= 0f)
                        {
                            fadeOut = false;
                        }
                    }
                }
                else
                {
                    activeIn.GetComponent<Image>().color = originalColor;
                    fadeOut = true;
                }
            }
        }
    }
}
