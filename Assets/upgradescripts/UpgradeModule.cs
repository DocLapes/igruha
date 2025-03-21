using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class UpgradeModule: MonoBehaviour
{
    public int lvl;
    public virtual void NewUpgradelvl()
    {
        if (lvl ==0)
        {
            GetUpgradeType1();
        }
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
    

}
