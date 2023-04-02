using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CraftMenu : MonoBehaviour
{
    public bool ContactVerstak = false;
    public GameObject craftmenu;
    public GameObject toolsmenu;
    public GameObject weaponsmenu;
    public GameObject armorsmenu;
    public GameObject buildingsmenu;
    public GameObject othersmenu;
    public bool FlagOpenCraftMenu = false;
    public bool FlagOpenToolsMenu = false;
    public bool FlagOpenWeaponsMenu = false;
    public bool FlagOpenArmorsMenu = false;
    public bool FlagOpenBuildingsMenu = false;
    public bool FlagOpenOthersMenu = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (!FlagOpenCraftMenu)
            {
                OpenCraftMenu();
            }
            else
            {
                CloseCraftMenu();
            }
        }
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

    public void OpenToolsMenu()
    {
        if (!FlagOpenToolsMenu)
        {
            toolsmenu.SetActive(true);
            weaponsmenu.SetActive(false);
            armorsmenu.SetActive(false);
            buildingsmenu.SetActive(false);
            othersmenu.SetActive(false);
            FlagOpenToolsMenu = true;
            FlagOpenWeaponsMenu = false;
            FlagOpenArmorsMenu = false;
            FlagOpenBuildingsMenu = false;
            FlagOpenOthersMenu = false;
        }
        else
        {
            toolsmenu.SetActive(false);
            FlagOpenToolsMenu = false;
            FlagOpenWeaponsMenu = false;
            FlagOpenArmorsMenu = false;
            FlagOpenBuildingsMenu = false;
            FlagOpenOthersMenu = false;
        }
    }

    public void OpenWeaponsMenu()
    {
        if (!FlagOpenWeaponsMenu)
        {
            toolsmenu.SetActive(false);
            weaponsmenu.SetActive(true);
            armorsmenu.SetActive(false);
            buildingsmenu.SetActive(false);
            othersmenu.SetActive(false);
            FlagOpenToolsMenu = false;
            FlagOpenWeaponsMenu = true;
            FlagOpenArmorsMenu = false;
            FlagOpenBuildingsMenu = false;
            FlagOpenOthersMenu = false;
        }
        else
        {
            weaponsmenu.SetActive(false);
            FlagOpenToolsMenu = false;
            FlagOpenWeaponsMenu = false;
            FlagOpenArmorsMenu = false;
            FlagOpenBuildingsMenu = false;
            FlagOpenOthersMenu = false;
        }
    }

    public void OpenArmorsMenu()
    {
        if (!FlagOpenArmorsMenu)
        {
            toolsmenu.SetActive(false);
            weaponsmenu.SetActive(false);
            armorsmenu.SetActive(true);
            buildingsmenu.SetActive(false);
            othersmenu.SetActive(false);
            FlagOpenToolsMenu = false;
            FlagOpenWeaponsMenu = false;
            FlagOpenArmorsMenu = true;
            FlagOpenBuildingsMenu = false;
            FlagOpenOthersMenu = false;
        }
        else
        {
            armorsmenu.SetActive(false);
            FlagOpenToolsMenu = false;
            FlagOpenWeaponsMenu = false;
            FlagOpenArmorsMenu = false;
            FlagOpenBuildingsMenu = false;
            FlagOpenOthersMenu = false;
        }
    }

    public void OpenBuildingsMenu()
    {
        if (!FlagOpenBuildingsMenu)
        {
            toolsmenu.SetActive(false);
            weaponsmenu.SetActive(false);
            armorsmenu.SetActive(false);
            buildingsmenu.SetActive(true);
            othersmenu.SetActive(false);
            FlagOpenToolsMenu = false;
            FlagOpenWeaponsMenu = false;
            FlagOpenArmorsMenu = false;
            FlagOpenBuildingsMenu = true;
            FlagOpenOthersMenu = false;
        }
        else
        {
            buildingsmenu.SetActive(false);
            FlagOpenToolsMenu = false;
            FlagOpenWeaponsMenu = false;
            FlagOpenArmorsMenu = false;
            FlagOpenBuildingsMenu = false;
            FlagOpenOthersMenu = false;
        }
    }

    public void OpenOthersMenu()
    {
        if (!FlagOpenOthersMenu)
        {
            toolsmenu.SetActive(false);
            weaponsmenu.SetActive(false);
            armorsmenu.SetActive(false);
            buildingsmenu.SetActive(false);
            othersmenu.SetActive(true);
            FlagOpenToolsMenu = false;
            FlagOpenWeaponsMenu = false;
            FlagOpenArmorsMenu = false;
            FlagOpenBuildingsMenu = false;
            FlagOpenOthersMenu = true;
        }
        else
        {
            othersmenu.SetActive(false);
            FlagOpenToolsMenu = false;
            FlagOpenWeaponsMenu = false;
            FlagOpenArmorsMenu = false;
            FlagOpenBuildingsMenu = false;
            FlagOpenOthersMenu = false;
        }
    }

    public void CloseCraftMenu()
    {
        craftmenu.SetActive(false);
        toolsmenu.SetActive(false);
        weaponsmenu.SetActive(false);
        armorsmenu.SetActive(false);
        buildingsmenu.SetActive(false);
        othersmenu.SetActive(false);
        FlagOpenCraftMenu = false;
        FlagOpenToolsMenu = false;
        FlagOpenWeaponsMenu = false;
        FlagOpenArmorsMenu = false;
        FlagOpenBuildingsMenu = false;
        FlagOpenOthersMenu = false;
    }

}
