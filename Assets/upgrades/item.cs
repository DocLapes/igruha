using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "upgradeData", menuName = "Upgrades/Upgrade1")]
public class upgrade : ScriptableObject
{
    public string Name = "Upgrade1";
    public string Description;
    public int Stat;
    public Sprite Icon;
}
