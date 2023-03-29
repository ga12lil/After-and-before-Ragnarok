using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    public Inventory inv;
    public GameObject player;
    public void OnDrop(PointerEventData eventData)
    {
        inv.DropAwayItem(eventData.pointerDrag.GetComponent<Item>().invOrder);
        eventData.pointerDrag.GetComponent<Item>().DestroyItem();
        for(int i = 0; i< eventData.pointerDrag.GetComponent<Item>().Count; i++)
        {
            Instantiate(eventData.pointerDrag.GetComponent<Item>().OriginalItem, player.transform.position+(Camera.main.ScreenToWorldPoint(Input.mousePosition)-player.transform.position).normalized*5f , new Quaternion());
        }

        
        //Instantiate(eventData.pointerDrag.GetComponent<Item>().OriginalItem, new Vector3(playerSpawner.transform.position.x, playerSpawner.transform.position.y,0), new Quaternion());
    }
}
