using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCraft : MonoBehaviour
{
    public List<Item> resourses;
    public List<int> resoursesCount;
    public GameObject result;
    public int resultCount;
    public Inventory inv;

    public void Craft()
    {
        bool CanCraft = true;
        for(int i = 0; i < resourses.Count; i++)
        {
            if (inv.SearchItemsInInventory(resourses[i]) < resoursesCount[i])
            {
                CanCraft = false;
                break;
            }
        }
        if (CanCraft)
        {
            for (int i = 0; i < resourses.Count; i++)
            {
                inv.RemoveItemFromInventory(resourses[i], resoursesCount[i]);
            }
            for (int i = 0; i < resultCount; i++)
            {
                inv.AddInInventory(result);
            }
        }
        else
        {
            Debug.Log("Cant craft");
        }
        
        
    }
}
