using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearModule : UpgradeModule
{
    // Start is called before the first frame update
    [SerializeField] GameObject Spears;


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
        Spears.GetComponent<SpearList>().GetUpgradeType1();

    }
    public override void GetUpgradeType2()
    {
        Spears.GetComponent<SpearList>().GetUpgradeType2(lvl);
    }
    
}
