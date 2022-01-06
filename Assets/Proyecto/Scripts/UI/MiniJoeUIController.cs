using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniJoeUIController : MonoBehaviour
{
    //public GameObject plant;
    public Image plantImage;
    public Image plantImageGreen;

    public GameObject activeIn;
    public Image activeInImage1;
    public Image activeInImage2;
    public Image activeInImageGreen;

    public GameObject pasive;
    public Image pasiveImage;
    public Image pasiveImageGreen;

    public GameObject activeOut;
    public Image activeOutImage1;
    public Image activeOutImage2;
    public Image activeOutImage3;
    public Image activeOutImageGreen;

    private MiniJoeHealController mhc;
    private antiBulletSystem abs;
    private MiniJoeLaserController mlc;
    private MiniJoe m;
    public GameObject miniJoe;

    private Color firstColorPlant;
    private Color firstColorActive1;
    private Color firstColorActive2;
    private Color firstColorPasive;
    private Color firstColorOutActive1;
    private Color firstColorOutActive2;
    private Color firstColorOutActive3;

    //public bool active;
    //public bool miniJoeIn;

    // Start is called before the first frame update
    void Start()
    {
        mhc = miniJoe.gameObject.GetComponent<MiniJoeHealController>();
        abs = miniJoe.gameObject.GetComponent<antiBulletSystem>();
        mlc = miniJoe.gameObject.GetComponent<MiniJoeLaserController>();
        m = miniJoe.gameObject.GetComponent<MiniJoe>();
        //plant.SetActive(true);
        firstColorPlant = plantImage.color;
        firstColorActive1 = activeInImage1.color;
        firstColorActive2 = activeInImage2.color;
        firstColorPasive = pasiveImage.color;
        firstColorOutActive1 = activeOutImage1.color;
        firstColorOutActive2 = activeOutImage2.color;
        firstColorOutActive3 = activeOutImage3.color;
    }

    // Update is called once per frame
    void Update()
    {
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
                activeIn.SetActive(true);
                pasive.SetActive(true);
                activeOut.SetActive(false);

                if (mhc.currenntHealsAvailable>0) //Curacion
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

                if (abs.timer >= abs.antiBulletdelay) //Escudo
                {
                    activeInImage1.gameObject.GetComponent<Animator>().enabled = true;
                    activeInImage2.gameObject.GetComponent<Animator>().enabled = true;
                }
                else
                {
                    activeInImage1.gameObject.GetComponent<Animator>().enabled = false;
                    activeInImage2.gameObject.GetComponent<Animator>().enabled = false;
                    activeInImage1.color = firstColorActive1;
                    activeInImage2.color = firstColorActive2;
                }

                activeInImageGreen.fillAmount = abs.timer / abs.antiBulletdelay;
            }
            else //Minioe plantado
            {
                activeIn.SetActive(false);
                pasive.SetActive(false);
                activeOut.SetActive(true);

                if (mlc.timerLaser >= mlc.laserCoolDown) //Rayo
                {
                    activeOutImage1.gameObject.GetComponent<Animator>().enabled = true;
                    activeOutImage2.gameObject.GetComponent<Animator>().enabled = true;
                    activeOutImage3.gameObject.GetComponent<Animator>().enabled = true;
                }
                else
                {
                    activeOutImage1.gameObject.GetComponent<Animator>().enabled = false;
                    activeOutImage2.gameObject.GetComponent<Animator>().enabled = false;
                    activeOutImage3.gameObject.GetComponent<Animator>().enabled = false;
                    activeOutImage1.color = firstColorOutActive1;
                    activeOutImage2.color = firstColorOutActive2;
                    activeOutImage3.color = firstColorOutActive3;
                }

                activeOutImageGreen.fillAmount = mlc.timerLaser / mlc.laserCoolDown;
            }
        }
    }
}
