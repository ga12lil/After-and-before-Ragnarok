using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public Light mainLight;
    public Light playerLight;
    public int time = 0;
    public int dayLong = 12000;
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        if(time == 6000)
        {
            time = 0;
        }

        mainLight.intensity = Mathf.Sin(time * Mathf.PI / dayLong);
        time++;
    }
}
