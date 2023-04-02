using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject Torch;
    public Inventory inv;
    public GameObject HandSlot;
    private Animator anim;
    void Start()
    {
        anim = HandSlot.GetComponent<Animator>();
    }

    public void UpdateInv()
    {

        for(int i =0; i < 10; i++)
        {
            if (inv.list[i] == null)
                continue;
            inv.list[i].gameObject.transform.SetParent(gameObject.transform.GetChild(i));
            inv.list[i].gameObject.transform.localPosition = new Vector3(0, 0, 0);
            inv.list[i].gameObject.transform.localScale = gameObject.transform.GetChild(i).localScale;
        }
        if(inv.InHand != null)
        {
            inv.InHand.gameObject.transform.SetParent(HandSlot.transform);
            inv.InHand.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            inv.InHand.gameObject.transform.localScale = inv.InHand.transform.localScale;
            anim.SetBool("InHand", true);
            if (inv.InHand.id==7) {Torch.SetActive(true);}
        }
        else
        {
            anim.SetBool("InHand", false);
            Torch.SetActive(false);
            
        }
        
        
    }

    
    
}
