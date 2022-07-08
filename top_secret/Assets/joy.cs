using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,Input.gyro.rotationRateUnbiased.x,0);
    }
}
