using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryController : MonoBehaviour
{
    private Vector2 randomValor, randomValor2;
    public Vector2 positionA, positionB, positionC, positionD;
    public GameObject firework, player,victoryPanel;
    private float leftFirework, rightFirework;
    public float fireworkCooldownLeft, fireworkCooldownRight;
    public bool victory;
    public static bool goingLS;

    // Start is called before the first frame update
    void Start()
    {
        victory = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (victory == true)
        {
            player.SetActive(false);
            victoryPanel.SetActive(true);
            if (leftFirework <= 0)
            {
                randomValor = new Vector2(
                    Random.Range(positionA.x, positionB.x),
                    Random.Range(positionA.y, positionB.y)
            );
                Instantiate(firework, randomValor, Quaternion.identity);
                leftFirework = fireworkCooldownLeft;
            }
            else
            {
                leftFirework -= Time.deltaTime;
            }

            if (rightFirework <= 0)
            {
                randomValor2 = new Vector2(
                    Random.Range(positionC.x, positionD.x),
                    Random.Range(positionC.y, positionD.y)
                 );
                Instantiate(firework, randomValor2, Quaternion.identity);
                rightFirework = fireworkCooldownRight;
            }
            else
            {
                rightFirework -= Time.deltaTime;
            }
        }
    }
    public void LevelSelector()
    {
        goingLS = true;
        SceneManager.LoadScene("MainMenu");
    }
}
