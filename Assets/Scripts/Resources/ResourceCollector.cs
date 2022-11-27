using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    public GameObject InvObj;
    public Inventory inv;
    

    private void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            inv.AddInInventory(InvObj);
            Destroy(gameObject);
        }
    }
}
