using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class invSlot : MonoBehaviour, IDropHandler
{
    public int SlotOrder;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            int i1 = eventData.pointerDrag.GetComponent<Item>().invOrder;
            gameObject.transform.parent.GetComponent<Inventory>().SwitchItems(i1, SlotOrder - 1);

        }
    }
}
