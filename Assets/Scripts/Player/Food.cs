using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int curFood = 0;
    public int maxFood = 100;

    public FoodBar foodBar;

    void Start()
    {
        curFood = maxFood;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FeedPlayer(2);
        }
    }

    public void FeedPlayer(int food)
    {
        curFood -= food;
        foodBar.SetFood(curFood);
    }
}
