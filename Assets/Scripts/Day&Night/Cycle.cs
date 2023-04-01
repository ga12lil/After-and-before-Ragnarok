using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public Light mainLight;
    public Light playerLight;
    public GameObject sun;
    public float time = 50;
    public int dayLong = 300;
    public int nightLong = 100;
    void Start()
    {
        
    }


    void Update()
    {
        sun.transform.localPosition = new Vector3((time *900/ dayLong)-450 , sun.transform.localPosition.y, sun.transform.localPosition.z);
        if(time >= dayLong+nightLong)
        {
            time = 0;
        }

        if (time < dayLong)
        {
            mainLight.intensity = Mathf.Sin(time * Mathf.PI / dayLong);
            playerLight.intensity = (1 - mainLight.intensity) / 2;
        }
        time+=Time.deltaTime;
    }
}
