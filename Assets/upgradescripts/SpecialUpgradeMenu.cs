using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialUpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject Circle;
    [SerializeField] private GameObject RotaitingBooks;
    [SerializeField] private GameObject SupProj;
    [SerializeField] private GameObject AtackAfterDash;
    [SerializeField] private GameObject TrackProj;
    [SerializeField] private GameObject Spear;
    [SerializeField] private GameObject SpearProj;
    [SerializeField] private GameObject Thunder;
    public static bool isspecialupgrademenu;

    // Start is called before the first frame update
    private void Start()
    {
       
    }
    void Update()
    {
        if (isspecialupgrademenu == true)
        {
            upgradeMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }


    public void ResumeGame()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isspecialupgrademenu = false;
    }
    public void SwitchUpgrade(int number)
    {
        Debug.Log(number);
        switch (number)
        {
            case 1:
                Circle.GetComponent<UpgradeModule>().NewUpgradelvl();
                break;
            case 2:
                RotaitingBooks.GetComponent<UpgradeModule>().NewUpgradelvl();
                break; 
            case 3:
                SupProj.GetComponent<UpgradeModule>().NewUpgradelvl();
                break;
            case 4:
                AtackAfterDash.GetComponent<UpgradeModule>().NewUpgradelvl();
                break;
            case 5:
                TrackProj.GetComponent<UpgradeModule>().NewUpgradelvl();
                break;
            case 6:
                Spear.GetComponent<UpgradeModule>().NewUpgradelvl();
                break;
            case 7:
                SpearProj.GetComponent<UpgradeModule>().NewUpgradelvl();
                break;
            case 8:
                Thunder.GetComponent<UpgradeModule>().NewUpgradelvl();
                break;

        }
    }


}
