using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class UpgradeModule: MonoBehaviour
{
    public int lvl;
    [SerializeField] public UpgradeModule SecondUpgrade;
    [SerializeField] public GameObject SuperUpgrade;
    [SerializeField] public int Upgrnum;
    [SerializeField] public GameObject UpgradeLsit;
    public virtual void NewUpgradelvl()
    {
        CheckModule();
        if (lvl % 2 == 1)
        {
            GetUpgradeType1();
        }
        if (lvl % 2 == 0)
        {
            GetUpgradeType2();
        }

    }
    public virtual void GetUpgradeType1() { }
    public virtual void GetUpgradeType2() { }

    public virtual void CheckModule()
    {
        if (SuperUpgrade != null)
        {
            if (SecondUpgrade.lvl>0)
            {
                int lvl2 = SecondUpgrade.lvl;
                if (lvl2 + lvl >= 4)
                {
                    SuperUpgrade.SetActive(true);
                    UpgradeLsit.GetComponent<SpecialUpgradeList>().DeleteSkill(Upgrnum);
                    UpgradeLsit.GetComponent<SpecialUpgradeList>().DeleteSkill(SecondUpgrade.Upgrnum);
                    SecondUpgrade.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                }
            }
        }
    }


}
