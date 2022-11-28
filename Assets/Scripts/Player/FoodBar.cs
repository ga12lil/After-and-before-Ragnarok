using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    public Slider foodBar;
    public Food playerFood;

    private void Start()
    {
        playerFood = GameObject.FindGameObjectWithTag("Player").GetComponent<Food>();
        foodBar = GetComponent<Slider>();
        foodBar.maxValue = playerFood.maxFood;
        foodBar.value = playerFood.maxFood;
    }

    public void SetFood(int food)
    {
        foodBar.value = food;
    }
}