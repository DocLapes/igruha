using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplay : MonoBehaviour
{
    private upgrade Upgrade;

    public TextMeshProUGUI nameText;

    public TextMeshProUGUI descriptionText;

    public Image Image;

    private void Start()
    {

        
    }
    public void GetUpgrade(upgrade upgrade)
    {

        Upgrade = upgrade;
        nameText.text = Upgrade.Name;
        descriptionText.text = Upgrade.Description;
        Image.sprite = Upgrade.Icon;
    }
}
