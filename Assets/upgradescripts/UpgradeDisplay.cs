using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplay : MonoBehaviour
{
    [SerializeField] GameObject GameMan;
    private upgrade Upgrade;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image Image;
    private int number;
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
        GameMan.GetComponent<UpgradeMenu>().SwitchUpgrade(number);
    }
}
