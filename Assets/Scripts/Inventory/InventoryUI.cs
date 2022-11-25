using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inv;
    
    public void UpdateInv()
    {
        
        for(int i =0; i < 10; i++)
        {
            if (inv.list[i] == null)
                continue;
            inv.list[i].gameObject.transform.SetParent(gameObject.transform.GetChild(i));
            inv.list[i].gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    
    
}
