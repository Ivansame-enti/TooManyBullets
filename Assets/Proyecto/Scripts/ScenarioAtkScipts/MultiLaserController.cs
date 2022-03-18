using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLaserController : MonoBehaviour
{
    private bool existe = false;
    private bool existe2 = false;
    public GameObject multi2, multi4;
    private GameObject multi2a, multi4a;
    private float time = 0.0f;
    private bool cambio = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            if (!existe)
            {
                multi2a = Instantiate(multi2);
                existe = true;
            }
            if (!existe2)
            {
                multi4a = Instantiate(multi4);
                existe2 = true;
            }


            if (cambio)
            {

                multi2a.SetActive(true);
                time += Time.deltaTime;
                if (time >= 5.0f)
                {
                    Destroy(multi2a);
                    existe = false;
                    cambio = false;
                    time = 0.0f;
                }
            }
            if (!cambio)
            {

                multi4a.SetActive(true);
                //multi4.SetActive(true);
                time += Time.deltaTime;
                if (time >= 5.0f)
                {

                    Destroy(multi4a);
                    existe2 = false;
                    cambio = true;
                    time = 0.0f;
                }
            }



        
    }
}

