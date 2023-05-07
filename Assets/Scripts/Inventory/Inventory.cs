using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public List<Item> list = new List<Item>();
    public Item InHand;
    public Item InArmor;
    public Item InHead;
    public InventoryUI invUI;
    public GameObject torchLight;

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
        if (i1 >= 0)
        {
            if (list[i2] == null)
            {
                list[i2] = list[i1];
                list[i1] = null;
                list[i2].invOrder = i2;
            }
            else
            {
                (list[i1], list[i2]) = (list[i2], list[i1]);
                list[i1].invOrder = i1;
                list[i2].invOrder = i2;

            }
        }
        if(i1 == -1)
        {
            if (list[i2] == null)
            {
                list[i2] = InHand;
                InHand = null;
                list[i2].invOrder = i2;
            }
            else
            {
                Equipment eq;
                if(list[i2].TryGetComponent<Equipment>(out eq))
                {
                    (InHand, list[i2]) = (list[i2], InHand);
                    list[i2].invOrder = i2;
                    InHand.invOrder = -1;
                }
                else
                {
                    
                }
            }
        }
        
        


        invUI.UpdateInv();
    }


    public void DropAwayItem(int ItemOrder)
    {
        if (ItemOrder > 0)
            list[ItemOrder] = null;
        else if (ItemOrder == -1)
            InHand = null;
        invUI.UpdateInv();
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
    
    void FixedUpdate()
    {
        if (InHand != null && InHand.id == 7)
        {
            torchLight.SetActive(true);
            if (InHand.eq.CurrDurability - 0.016f <= 0)
            {
                InHand.eq.CurrDurability -= 0.016f;
                invUI.UpdateInv();
            }
            else InHand.eq.CurrDurability -= 0.016f;
        }
        else
        {
            torchLight.SetActive(false);
        }

    }
}
