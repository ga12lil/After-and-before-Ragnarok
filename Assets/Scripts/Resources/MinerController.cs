using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerController : MonoBehaviour
{
    public Inventory inv;
    public ItemClass NeedEquip;
    public float NeedDamage;
    public float HP;
    public bool Contact;
    public bool CanMine;
    public List<GameObject> FarmRes;
    

    public void Awake()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Contact = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Contact = false;
        }
    }
    public void OnMouseDrag()
    {
        if (Contact && inv.InHand != null)
        {
            Equipment eq = inv.InHand.gameObject.GetComponent<Equipment>();
            if (NeedEquip == eq.itemClass)
            {
                if(NeedDamage <= eq.Damage)
                {
                    HP-= eq.Damage;
                }
            }
        }
    }
    
    public void FixedUpdate()
    {
        if(HP <= 0)
        {
            System.Random rand = new System.Random();
            foreach (var i in FarmRes)
            {
                int randX = rand.Next(-3, 3);
                int randY = rand.Next(-3, 3);
                Instantiate(i, new Vector3(gameObject.transform.position.x + randX, gameObject.transform.position.y + randY, gameObject.transform.position.z), new Quaternion());
            }
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            Destroy(gameObject);
        }
        
    }


    //########################################
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void OnMouseEnter()
    {
        if (Contact && inv.InHand != null)
        {
            Equipment eq = inv.InHand.gameObject.GetComponent<Equipment>();
            if (NeedEquip == eq.itemClass)
            {
                if (NeedDamage <= eq.Damage)
                {
                    Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                }
            }
        }
        
    }
    private void OnMouseOver()
    {
        OnMouseEnter();
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}

