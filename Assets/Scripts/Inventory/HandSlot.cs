using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandSlot : MonoBehaviour, IDropHandler
{
    public Inventory inv;
    public InventoryUI invUI;
    public void OnDrop(PointerEventData eventData)
    {
        Equipment eq;
        if(eventData.pointerDrag.TryGetComponent<Equipment>(out eq))
        {
            ItemClass ic = eq.itemClass;
            Item item = eventData.pointerDrag.GetComponent<Item>();
            if (inv.InHand == null)
            {
                inv.list[item.invOrder] = null;
                inv.InHand = item;
                item.invOrder = -1;
                invUI.UpdateInv();
            }
            else
            {
                inv.list[item.invOrder] = inv.InHand;
                inv.InHand.invOrder = item.invOrder;
                inv.InHand = item;
                item.invOrder = -1;
                invUI.UpdateInv();
            }
        }
        
    }
}
