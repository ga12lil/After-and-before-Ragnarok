using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightClickToUse : MonoBehaviour
{
    public Inventory inv;
    public Food food;
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        food = GameObject.Find("player").GetComponent<Food>();
        health = GameObject.Find("player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            inv.RemoveItemFromInventory(gameObject.GetComponent<Item>(), 1);
            food.Feed(20);
            health.Heal(5);
        }
    }
    
}
