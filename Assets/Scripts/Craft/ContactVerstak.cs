using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ContactVerstak : MonoBehaviour
{
    
    [FormerlySerializedAs("ButtonAxe")] public GameObject Buttonaxe;
    [FormerlySerializedAs("ButtonPickAxe")] public GameObject Buttonpickaxe;
    [FormerlySerializedAs("ButtonSpear")] public GameObject Buttonspear;
    [FormerlySerializedAs("ButtonAxe2")] public GameObject Buttonaxe2;

    // Start is called before the first frame update
    private void Start()
    {
        Buttonaxe=GameObject.Find("Canvas").transform.Find("CraftMenu/ToolsMenu/ButtonAxe").gameObject;
        Buttonpickaxe=GameObject.Find("Canvas").transform.Find("CraftMenu/ToolsMenu/ButtonPickAxe").gameObject;
        Buttonspear=GameObject.Find("Canvas").transform.Find("CraftMenu/WeaponsMenu/ButtonSpear").gameObject;
        Buttonaxe2=GameObject.Find("Canvas").transform.Find("CraftMenu/WeaponsMenu/ButtonAxe2").gameObject;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            Buttonaxe.SetActive(true);
            Buttonpickaxe.SetActive(true);
            Buttonspear.SetActive(true);
            Buttonaxe2.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            Buttonaxe.SetActive(false);
            Buttonpickaxe.SetActive(false);
            Buttonspear.SetActive(false);
            Buttonaxe2.SetActive(false);
            
        }
    }
}
