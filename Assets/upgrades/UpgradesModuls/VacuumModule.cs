using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumModule : UpgradeModule
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;


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
        player.GetComponent<playermanager>().Getradius();

    }
    public override void GetUpgradeType2()
    {
        player.GetComponent<playermanager>().Getspeed();
    }
    public void Begining(int ceratelvl)
    {
        lvl = ceratelvl;
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
