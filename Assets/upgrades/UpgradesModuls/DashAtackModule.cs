using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAtackModule : UpgradeModule
{
    [SerializeField] private GameObject Dash;
    [SerializeField] private GameObject Hero;
    // Start is called before the first frame update
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
        Hero.GetComponent<move>().AktivSpDash();
        Dash.GetComponent<SpawnObject>().enabled = true;
        Dash.GetComponent<SpawnObject>().GetUpgradeType1();

    }
    public override void GetUpgradeType2()
    {
        Dash.GetComponent<SpawnObject>().GetUpgradeType2(lvl);
    }
    public override void CheckModule()
    {
        if (SuperUpgrade != null)
        {
            if (SecondUpgrade.lvl > 0)
            {
                int lvl2 = SecondUpgrade.lvl;
                if (lvl2 + lvl >= 4)
                {
                    SuperUpgrade.SetActive(true);
                    gameObject.GetComponentInParent<move>().GetSuperUpgr(SuperUpgrade);
                    UpgradeLsit.GetComponent<SpecialUpgradeList>().DeleteSkill(Upgrnum);
                    UpgradeLsit.GetComponent<SpecialUpgradeList>().DeleteSkill(SecondUpgrade.Upgrnum);
                }
            }
        }

    }
}
