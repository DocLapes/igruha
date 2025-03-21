using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookModule : UpgradeModule
{
    [SerializeField] GameObject BookRotating;
    
    
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
        BookRotating.GetComponent<BookRotaiting>().enabled = true;
        BookRotating.GetComponent<BookRotaiting>().GetUpgradeType1();

    }
    public override void GetUpgradeType2()
    {
        BookRotating.GetComponent<BookRotaiting>().GetUpgradeType2(lvl);
    }
    
}
