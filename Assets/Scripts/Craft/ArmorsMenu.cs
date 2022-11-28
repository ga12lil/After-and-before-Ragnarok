using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArmorsMenu : MonoBehaviour
{
    public GameObject craftmenu;
    public GameObject Canvas;
    public bool FlagOpenCraftMenu = false;

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
            FlagOpenCraftMenu = false;
        }
    }
}
