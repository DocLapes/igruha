using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject Hero;
    public static bool isupgrademenu;
    void Update()
    {
        if (isupgrademenu == true)
        {
            upgradeMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void ResumeGame()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isupgrademenu = false;
    }
    public void SwitchUpgrade(int number)
    {
        switch (number)
        {
            case 1:
                Hero.GetComponent<playermanager>().UpgradeDMG();
                break;
            case 2:
                Hero.GetComponent<playermanager>().UpgradeReload();
                break; 
            case 3:
                Hero.GetComponent<playermanager>().UpgradeHealth();
                break;
        }
    }

}
