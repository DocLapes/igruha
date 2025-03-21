using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialUpgradeList : MonoBehaviour
{
    [SerializeField] private Button UpgradeOne;
    [SerializeField] private Button UpgradeTwo;
    [SerializeField] private Button UpgradeThree;
    [SerializeField] private List<upgrade> ListUpg1;
    [SerializeField] private List<upgrade> ListUpg2;
    private List<int> Lvls = new List<int>();
    private List<int> ListActiveUpg= new List<int>();
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < ListUpg1.Count; i++)
        {
            Lvls.Capacity += 1;
            Lvls.Add(0);    
        }

        Debug.Log(Lvls[0]);

    }

    // Update is called once per frame
    public void RNG_Upgrade()
    {
        Debug.Log(Lvls.Capacity);
        if (ListActiveUpg.Count == 0)   
        {
           
            int count = ListUpg1.Count;
            int n1 = Random.Range(0, count);
            int n2 = Random.Range(0, count);
            int n3 = Random.Range(0, count );
            upgrade upgr1 = ListUpg1[n1];
            upgrade upgr2 = ListUpg1[n2];
            upgrade upgr3 = ListUpg1[n3];


            if (n1 != n2 && n2 != n3 && n1 != n3)
            {
                Debug.Log(n1);
                Debug.Log(n2);
                Debug.Log(count);
                UpgradeOne.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr1);
                UpgradeTwo.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr2);
                UpgradeThree.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr3);

            }
            else
            {
                RNG_Upgrade();
            }
        }
        if (ListActiveUpg.Count >= 1 && ListActiveUpg.Count < ListUpg1.Count /2)
        {
            int count = ListUpg1.Count;
            int count2 = ListActiveUpg.Count;
            int n1 = ListActiveUpg[Random.Range(0, count2 - 1)];
            int n2 = Random.Range(0, count - 1);
            int n3 = Random.Range(0, count - 1);
            upgrade upgr1;
            if (Lvls[n1] % 2 == 1)
            {
                upgr1 = ListUpg2[n1];
                Debug.Log("прикол");
            }
            else
            {
                upgr1 = ListUpg1[n1];
                Debug.Log("неприкол");
            }
            upgrade upgr2 = ListUpg1[n2];
            upgrade upgr3 = ListUpg1[n3];


            if (n1 != n2 && n2 != n3 && n1 != n3)
            {
                
                UpgradeOne.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr1);
                UpgradeTwo.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr2);
                UpgradeThree.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr3);

            }
            else
            {
                RNG_Upgrade();
            }
        }
        if (ListActiveUpg.Count >= ListUpg1.Count/2)
        {
            Debug.Log("lox");
            int count = ListUpg1.Count;
            int count2 = ListActiveUpg.Count;
            int n1 = ListActiveUpg[Random.Range(0, count2 - 1)];
            int n2 = ListActiveUpg[Random.Range(0, count2 - 1)]; 
            int n3 = Random.Range(0, count - 1);
            upgrade upgr1;
            if (Lvls[n1] % 2 == 1)
            {
                upgr1 = ListUpg2[n1];
            }
            else
            {
                upgr1 = ListUpg1[n1];
            }
            if (Lvls[n2] % 2 == 1)
            {
                upgr1 = ListUpg2[n2];
            }
            else
            {
                upgr1 = ListUpg1[n2];
            }
            upgrade upgr2 = ListUpg1[n2];
            upgrade upgr3 = ListUpg1[n3];


            if (n1 != n2 && n2 != n3 && n1 != n3)
            {
                UpgradeOne.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr1);
                UpgradeTwo.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr2);
                UpgradeThree.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr3);

            }
            else
            {
                RNG_Upgrade();
            }

        }
        

    }   
    public void NewActiveUpgrade(int upgrnumber)
    {
        Debug.Log(upgrnumber);
        ListActiveUpg.Add(upgrnumber-1);
        Lvls[upgrnumber-1] = Lvls[upgrnumber-1] + 1;
    }
}
