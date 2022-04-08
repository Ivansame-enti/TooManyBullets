using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level2Controller : MonoBehaviour
{
    public GameObject controllerSprite;
    public Image arrowImage;
    public GameObject textUI;
    public GameObject counterUI;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject shieldTutorial,shieldXbox, shieldPS4, shieldKeyboard;
    private int phasecounter;
    private int enemiesDestroyed;
    private TextMeshProUGUI textPro;
    public Sprite square;
    private AudioManagerController audio;
    public SnapshotsController sc;
    private PauseController pc;
    public TextMeshProUGUI phaseInfo;
    public Animation textAnim;
    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PauseController>();
        audio = FindObjectOfType<AudioManagerController>();
        phasecounter = 0;
        phase1.SetActive(true);
        phaseInfo.text = "Phase 1/4";
        textAnim.Play("phaseInfo");
        phase2.SetActive(false);
        phase3.SetActive(false);
        phase4.SetActive(false);
        enemiesDestroyed = 0;
        textPro = counterUI.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if(phasecounter == 0)
        {
            if(!audio.GetAudioPlaying("Bloops") && pc.pauseState==false) audio.AudioPlay("Bloops");
        } else audio.AudioStop("Bloops");

        if (ControllerInput.Xbox_One_Controller == true)
        {
            shieldXbox.SetActive(true);
            shieldPS4.SetActive(false);
            shieldKeyboard.SetActive(false);
        }
        else if (ControllerInput.PS4_Controller == true)
        {
            shieldXbox.SetActive(false);
            shieldPS4.SetActive(true);
            shieldKeyboard.SetActive(false);
        }
        else if (ControllerInput.Xbox_One_Controller == false && ControllerInput.PS4_Controller == false)
        {
            shieldXbox.SetActive(false);
            shieldPS4.SetActive(false);
            shieldKeyboard.SetActive(true);
        }
        if (phasecounter == 4)
        {
            phase3.SetActive(false);
            phase4.SetActive(true);
            this.gameObject.SetActive(false);
            phaseInfo.text = "Phase 4/4";
            textAnim.Play("phaseInfo");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerTag"))
        {
            if (phasecounter == 0)
            {
                phaseInfo.text = "Phase 2/4";
                textAnim.Play("phaseInfo");
                audio.AudioPlay("Plim");
                //Destroy(this.GetComponent<SpriteRenderer>());
                //Destroy(this.GetComponent<Rigidbody2D>());
                //Destroy(this.GetComponent<CircleCollider2D>());
                shieldTutorial.SetActive(false);
                phase1.SetActive(false);
                phase2.SetActive(true);
                this.transform.position = new Vector3(-19.5f, -10f, 1);
                controllerSprite.SetActive(false);
                arrowImage.enabled = false;
                phasecounter++;
            } else if (phasecounter == 1)
            {
                phaseInfo.text = "Phase 3/4";
                textAnim.Play("phaseInfo");
                GameObject[] bullets;
                bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

                foreach (GameObject bullet in bullets)
                {
                    Destroy(bullet);
                }
                phase2.SetActive(false);
                phase3.SetActive(true);
                textUI.SetActive(true);
                counterUI.SetActive(true);
                textPro.text = enemiesDestroyed.ToString();
                this.GetComponent<SpriteRenderer>().sprite = square;
                this.transform.localScale = new Vector3(8,7,0);
                this.transform.position = new Vector3(24.5f, -0.3f, 0);
                this.gameObject.AddComponent<BoxCollider2D>();
                phasecounter++;
                audio.AudioPlay("Plim");
            }
        }

        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.transform.parent.gameObject);
            enemiesDestroyed++;
            textPro.text = enemiesDestroyed.ToString();
            FindObjectOfType<AudioManagerController>().AudioPlay("Plim");
            if (enemiesDestroyed == 2)
            {
                //helpText.SetActive(false);
                counterUI.SetActive(false);
                textUI.SetActive(false);
                phasecounter = 4;
            }
        }
    }
}
