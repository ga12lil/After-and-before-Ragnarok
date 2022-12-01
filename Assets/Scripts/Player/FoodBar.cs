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

    void Update()
    {
        SetFood(playerFood.curFood);
    }

    public void SetFood(float food)
    {
        foodBar.value = food;
    }
}