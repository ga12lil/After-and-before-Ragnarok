using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    public GameObject InvObj;
    public Inventory inv;
    public bool InContact = false;
    

    private void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            InContact = true;
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            InContact = false;
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (InContact)
            {
                inv.AddInInventory(InvObj);
                Destroy(gameObject);
            }
        }
    }
}
