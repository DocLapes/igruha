using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpecialUpgradeDisplay : MonoBehaviour
{
    [SerializeField] GameObject GameMan;

    private upgrade Upgrade;

    public TextMeshProUGUI nameText;

    public TextMeshProUGUI descriptionText;

    public Image Image;

    private int number;

    private void Start()
    {

        
    }
    public void GetUpgrade(upgrade upgrade)
    {

        Upgrade = upgrade;
        number = Upgrade.Stat;
        nameText.text = Upgrade.Name;
        descriptionText.text = Upgrade.Description;
        Image.sprite = Upgrade.Icon;

    }
    public void TransferUpddate()
    {
        GameMan.GetComponent<SpecialUpgradeMenu>().SwitchUpgrade(number);
        GameMan.GetComponent<SpecialUpgradeList>().NewActiveUpgrade(number);
    }

}
