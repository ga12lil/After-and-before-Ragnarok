using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public Light mainLight;
    public Light playerLight;
    public int time = 2000;
    public int dayLong = 12000;
    public int nightLong = 3000;
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        
        if(time >= dayLong+nightLong)
        {
            time = 0;
        }

        if (time < dayLong)
        {
            mainLight.intensity = Mathf.Sin(time * Mathf.PI / dayLong);
            playerLight.intensity = (1 - mainLight.intensity) / 2;
        }
        time++;
    }
}
