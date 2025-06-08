using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceProjectileModule : UpgradeModule
{
    // Start is called before the first frame update
    [SerializeField] GameObject Proj;

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
        Proj.SetActive(true);
        Proj.GetComponent<CheckEnemy>().GetUpgradeType1();

    }
    public override void GetUpgradeType2()
    {
        Proj.GetComponent<CheckEnemy>().GetUpgradeType2(lvl);
    }
}
