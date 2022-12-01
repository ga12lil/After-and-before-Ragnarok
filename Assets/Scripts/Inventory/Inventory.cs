using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public List<Item> list = new List<Item>();
    public InventoryUI invUI;

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
                list[i].invOrder = i;
                return;
            }
        }
        //inventory full need realize!!!

    }
    public void AddInInventory(GameObject go)
    {
        var obj = Instantiate(go);
        AddItem(obj.GetComponent<Item>());
        invUI.UpdateInv();
    }
    
    public void SwitchItems(int i1, int i2)
    {
        if(list[i2] == null)
        {
            list[i2] = list[i1];
            list[i1] = null;
            list[i2].invOrder = i2;
        }
        else
        {
            Debug.Log(list[i2] == null);
            
            (list[i1], list[i2]) = (list[i2], list[i1]);
            list[i1].invOrder = i1;
            list[i2].invOrder = i2;

        }
        


        invUI.UpdateInv();
    }


    public void DropAwayItem(int ItemOrder)
    {
        list[ItemOrder] = null;
    }



    //####################################################################
    public int SearchItemsInInventory(Item item)
    {
        int count = 0;
        foreach (Item i in list)
        {
            if ((i != null) && (i.id == item.id))
            {
                count += i.Count;
            }
        }
        return count;
    }
    public void RemoveItemFromInventory(Item item, int count)
    {

        int CurCount = 0;
        if (SearchItemsInInventory(item) >= count)
        {
            while (CurCount != count)
            {
                int minI = FindMinimalItem(item);
                if (list[minI].Count + CurCount <= count)
                {
                    CurCount += list[minI].Count;
                    list[minI].GetComponent<Item>().DestroyItem();
                    DropAwayItem(minI);
                    invUI.UpdateInv();
                }
                else
                {
                    list[minI].Count -= (count - CurCount);
                    CurCount = count;
                    
                    invUI.UpdateInv();
                }
            }
        }
        else
        {
            Debug.Log("No much res!");
        }
    }
    private int FindMinimalItem(Item item)
    {
        int minCount = 999;
        int minOrder = -1;
        foreach (Item i in list)
        {
            if ((i != null) && (i.id == item.id))
            {
                if (i.Count < minCount)
                {
                    minCount = i.Count;
                    minOrder = i.invOrder;
                }
            }
        }
        Debug.Log(minOrder);
        return minOrder;
    }
}
