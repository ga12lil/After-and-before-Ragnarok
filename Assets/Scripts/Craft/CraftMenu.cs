using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CraftMenu : MonoBehaviour
{

    public GameObject craftmenu;
    public bool FlagOpenCraftMenu=false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCraftMenu()
    {
        if (!FlagOpenCraftMenu)
        {
            craftmenu.SetActive(true);
            FlagOpenCraftMenu = true;
        }
        else
        { 
            craftmenu.SetActive(false);
            FlagOpenCraftMenu=false;
        }
    }

}