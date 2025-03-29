using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderModule : UpgradeModule
{
    // Start is called before the first frame update
    [SerializeField] GameObject Thunder;


    void Awake()
    {

    }
    public override void NewUpgradelvl()
    {
        lvl++;
        base.NewUpgradelvl();
    }
    public override void GetUpgradeType1()
    {
        Thunder.SetActive(true);
        Thunder.GetComponent<CheckEnemyThunder>().GetUpgradeType1();

    }
    public override void GetUpgradeType2()
    {
        Thunder.GetComponent<CheckEnemyThunder>().GetUpgradeType2(lvl);
    }
}
