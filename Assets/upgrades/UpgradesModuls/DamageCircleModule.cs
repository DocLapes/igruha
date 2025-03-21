using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCircleModule : UpgradeModule
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Circle;
    [SerializeField] private GameObject VCircle;
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
        Circle.GetComponent<SaintCircle>().enabled = true;
        VCircle.SetActive(true);
        Circle.GetComponent<SaintCircle>().GetUpgradeType1();

    }
    public override void GetUpgradeType2()
    {
        Circle.GetComponent<SaintCircle>().GetUpgradeType2(lvl);
    }
    
}
