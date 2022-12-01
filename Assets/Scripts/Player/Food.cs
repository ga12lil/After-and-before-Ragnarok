using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float curFood = 0;
    public float maxFood = 100;

    private float secondsToEmptyFood = 10f;

    void Start()
    {
        curFood = maxFood;
    }

    void Update()
    {
        if (curFood > 0)
        {
            Hunger(maxFood / secondsToEmptyFood * Time.deltaTime);
            Debug.Log("Food");
        }
    }

    public void Feed(float food)
    {
        curFood += food;
        if (curFood > maxFood)
            curFood = maxFood;
    }

    public void Hunger(float food)
    {
        if (curFood < 0)
            curFood = 0;
        curFood -= food;
    }
}
