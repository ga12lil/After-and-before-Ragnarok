using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> list = new List<Item>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
            list.Add(null);
    }
    public void AddItem(Item item)
    {
        foreach(Item i in list)
        {
            if(i!=null && item.id == i.id)
            {
                if (i.Count < i.MaxInStack)
                {
                    i.Count++;
                    Destroy(item.gameObject);
                    return;
                }
            }
        }
        for(int i =0;i<list.Count;i++)
        {
            if(list[i] == null)
            {
                list[i] = item;
                list[i].Count = 1;
                return;
            }
        }
        //inventory full need realize!!!

    }
    

}
