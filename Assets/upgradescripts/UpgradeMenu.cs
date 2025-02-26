using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenu;
    public static bool isupgrademenu;

    // Start is called before the first frame update
    void Update()
    {
        if (isupgrademenu==true)
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
    public void AddHeath(int hp)
    {

    }

}
