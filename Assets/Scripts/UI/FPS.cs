using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{
    public static float fps;
    public TextMeshProUGUI text;
    float time = 0;
    int frames = 0;

    private void Update()
    {
        frames++;
        time += Time.deltaTime;
        if(time!=0 && time>0.2f)
        {
            text.text = $"FPS: {(int)(frames / time)}";
            frames = 0;
            time = 0;
        }
    }
}
