using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject InvObj;
    public Inventory inv;
    public InventoryUI invUI;

    private void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        invUI = GameObject.Find("Inventory").GetComponent<InventoryUI>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triger");
        if(other.name == "player")
        {
            Debug.Log("TrigerPlayer");
            var obj = Instantiate(InvObj);
            inv.AddItem(obj.GetComponent<Item>());
            invUI.UpdateInv();
            Destroy(gameObject);
        }
    }
}
