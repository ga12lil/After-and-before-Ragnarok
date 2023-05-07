using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rightClickToUse : MonoBehaviour, IPointerClickHandler
{
    public Inventory inv;
    public Food food;
    public Health health;
    public int HealValue;
    public int FeedValue;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        food = GameObject.Find("player").GetComponent<Food>();
        health = GameObject.Find("player").GetComponent<Health>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            inv.RemoveItemFromInventory(gameObject.GetComponent<Item>(), 1);
            food.Feed(FeedValue);
            health.Heal(HealValue);
        }
    }


}
