using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    public GameObject InvObj;
    public Inventory inv;
    public bool InContact = false;
    public GameObject EkeyPrefab;
    public GameObject Ekey;
    public float Durability;
    

    private void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            InContact = true;
            Ekey = Instantiate(EkeyPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Quaternion());
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            InContact = false;
            Destroy(Ekey);
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
