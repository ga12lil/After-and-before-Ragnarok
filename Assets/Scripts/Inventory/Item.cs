using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IEndDragHandler, IDragHandler , IBeginDragHandler
{
    public int id;
    public int MaxInStack;
    public int Count;
    public int invOrder;
    private Canvas canvas;
    private RectTransform rt;
    private GameObject inv;
    private CanvasGroup cg;
    public GameObject OriginalItem;

    void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rt = gameObject.GetComponent<RectTransform>();
        inv = GameObject.Find("Inventory");
        cg = gameObject.GetComponent<CanvasGroup>();
    }
    

    void Update()
    {
        if (Count > 1)
        {
            var txt = gameObject.transform.GetChild(0).gameObject;
            txt.SetActive(true);
            txt.GetComponent<Text>().text = Count.ToString();
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = true;
        inv.GetComponent<InventoryUI>().UpdateInv();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = false;
        gameObject.transform.SetParent(canvas.transform);
    }
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
