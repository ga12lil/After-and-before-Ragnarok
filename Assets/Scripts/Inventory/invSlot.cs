using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class invSlot : MonoBehaviour, IDropHandler
{
    public int SlotOrder;
    private Inventory inv;

    public void Start()
    {
        inv = gameObject.transform.parent.GetComponent<Inventory>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            int i1 = eventData.pointerDrag.GetComponent<Item>().invOrder;
            inv.SwitchItems(i1, SlotOrder - 1);
        }
    }
}
