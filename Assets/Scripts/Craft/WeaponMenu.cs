using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponMenu : MonoBehaviour
{
    public GameObject craftmenu;
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
