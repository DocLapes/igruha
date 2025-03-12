using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialUpgradeList : MonoBehaviour
{
    [SerializeField] Button UpgradeOne;
    [SerializeField] Button UpgradeTwo;
    [SerializeField] Button UpgradeThree;
    [SerializeField] List<upgrade> ListUpg1;
    [SerializeField] List<upgrade> ListUpg2;
    private List<int> Lvls;
    private List<int> ListActiveUpg;
    // Start is called before the first frame update
    void Awake()
    {
        Lvls.Capacity = ListUpg1.Count;

    }

    // Update is called once per frame
    public void RNG_Upgrade()
    {
        if (ListActiveUpg == null)
        {
            int count = ListUpg1.Count;
            int n1 = Random.Range(0, count - 1);
            int n2 = Random.Range(0, count - 1);
            int n3 = Random.Range(0, count - 1);
            upgrade upgr1 = ListUpg1[n1];
            upgrade upgr2 = ListUpg1[n2];
            upgrade upgr3 = ListUpg1[n3];


            if (n1 != n2 && n1 != n2)
            {
                Debug.Log(n1);
                Debug.Log(n2);
                Debug.Log(count);
                UpgradeOne.GetComponent<UpgradeDisplay>().GetUpgrade(upgr1);
                UpgradeTwo.GetComponent<UpgradeDisplay>().GetUpgrade(upgr2);
                UpgradeThree.GetComponent<UpgradeDisplay>().GetUpgrade(upgr3);

            }
            else
            {
                RNG_Upgrade();
            }
        }
        if (ListActiveUpg.Count < ListUpg1.Count /2)
        {
            int count = ListUpg1.Count;
            int count2 = ListActiveUpg.Count;
            int n1 = ListActiveUpg[Random.Range(0, count2 - 1)];
            int n2 = Random.Range(0, count - 1);
            int n3 = Random.Range(0, count - 1);
            upgrade upgr1;
            if (Lvls[n1] % 2 == 0)
            {
                upgr1 = ListUpg2[n1];
            }
            else
            {
                upgr1 = ListUpg1[n1];
            }
            upgrade upgr2 = ListUpg1[n2];
            upgrade upgr3 = ListUpg1[n3];


            if (n1 != n2 && n1 != n2)
            {
                
                UpgradeOne.GetComponent<UpgradeDisplay>().GetUpgrade(upgr1);
                UpgradeTwo.GetComponent<UpgradeDisplay>().GetUpgrade(upgr2);
                UpgradeThree.GetComponent<UpgradeDisplay>().GetUpgrade(upgr3);

            }
            else
            {
                RNG_Upgrade();
            }
        }
        if (ListActiveUpg.Count >= ListUpg1.Count/2)
        {
            int count = ListUpg1.Count;
            int count2 = ListActiveUpg.Count;
            int n1 = ListActiveUpg[Random.Range(0, count2 - 1)];
            int n2 = ListActiveUpg[Random.Range(0, count2 - 1)]; 
            int n3 = Random.Range(0, count - 1);
            upgrade upgr1;
            if (Lvls[n1] % 2 == 0)
            {
                upgr1 = ListUpg2[n1];
            }
            else
            {
                upgr1 = ListUpg1[n1];
            }
            if (Lvls[n2] % 2 == 0)
            {
                upgr1 = ListUpg2[n2];
            }
            else
            {
                upgr1 = ListUpg1[n2];
            }
            upgrade upgr2 = ListUpg1[n2];
            upgrade upgr3 = ListUpg1[n3];


            if (n1 != n2 && n1 != n2)
            {
                UpgradeOne.GetComponent<UpgradeDisplay>().GetUpgrade(upgr1);
                UpgradeTwo.GetComponent<UpgradeDisplay>().GetUpgrade(upgr2);
                UpgradeThree.GetComponent<UpgradeDisplay>().GetUpgrade(upgr3);

            }
            else
            {
                RNG_Upgrade();
            }

        }
        

    }
    public void NewActiveUpgrade(int upgrnumber)
    {
        ListActiveUpg.Add(upgrnumber);
        Lvls[upgrnumber] += 1;
    }
}
