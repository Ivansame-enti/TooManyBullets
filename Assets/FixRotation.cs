using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
