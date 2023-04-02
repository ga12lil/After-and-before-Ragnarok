using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactVerstak : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject ButtonAxe;
    public GameObject ButtonPickAxe;
    public GameObject ButtonSpear;
    public GameObject ButtonAxe2;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            ButtonAxe.SetActive(true);
            ButtonPickAxe.SetActive(true);
            ButtonSpear.SetActive(true);
            ButtonAxe2.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            ButtonAxe.SetActive(false);
            ButtonPickAxe.SetActive(false);
            ButtonSpear.SetActive(false);
            ButtonAxe2.SetActive(false);
            
        }
    }
}
