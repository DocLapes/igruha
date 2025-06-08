using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    private List<int> AvalibaleSkillList = new List<int>();
    private List<int> ListActiveUpg= new List<int>();
    // Start is called before the first frame update
    void Awake()
    {
        int n=1;
        for(int i = 0; i < ListUpg1.Count; i++)
        {
            Lvls.Capacity += 1;
            Lvls.Add(0);    
        }

        for (int i = 0; i < ListUpg1.Count; i++)
        {
            AvalibaleSkillList.Capacity += 1;
            AvalibaleSkillList.Add(n);
            n += 1;
        }

    }

    // Update is called once per frame
    public void RNG_Upgrade()
    {
        Debug.Log("активки" + ListActiveUpg.Count);
        Debug.Log("доступно" + AvalibaleSkillList.Count);
        if (ListActiveUpg.Count == 0)
        {
            Debug.Log("lox1");
            int count = AvalibaleSkillList.Count;
            int n1 = AvalibaleSkillList[Random.Range(0, count)];
            int n2 = AvalibaleSkillList[Random.Range(0, count)];
            int n3 = AvalibaleSkillList[Random.Range(0, count)];
            upgrade upgr1 = ListUpg1[n1-1];
            upgrade upgr2 = ListUpg1[n2-1];
            upgrade upgr3 = ListUpg1[n3 - 1];


            if (upgr1.Stat != upgr2.Stat && upgr2.Stat != upgr3.Stat && upgr1.Stat != upgr3.Stat)
            {
                
                UpgradeOne.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr1);
                UpgradeTwo.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr2);
                UpgradeThree.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr3);

            }
            else { RNG_Upgrade(); return; }
            return;
        }
        if (ListActiveUpg.Count >= 1 && ListActiveUpg.Count < AvalibaleSkillList.Count /2)
        {
            Debug.Log("lox2");
            int count = AvalibaleSkillList.Count;
            int count2 = ListActiveUpg.Count;
            int n1 = ListActiveUpg[Random.Range(0, count2)];
            int n2 = AvalibaleSkillList[Random.Range(0, count)];
            int n3 = AvalibaleSkillList[Random.Range(0, count)];
            upgrade upgr1;
            Debug.Log(n1);
            Debug.Log(n2);
            Debug.Log(n3);
            if (Lvls[n1-1] % 2 == 1)
            {
                upgr1 = ListUpg2[n1 - 1];
                
            }
            else
            {
                upgr1 = ListUpg1[n1 - 1];
                
            }
            upgrade upgr2 = ListUpg1[n2 - 1];
            upgrade upgr3 = ListUpg1[n3 - 1];

            foreach(int statnum in ListActiveUpg)
            {
                Debug.Log(statnum);
                Debug.Log("2скилл" + upgr2.Stat) ;
                Debug.Log("3скилл" + upgr3.Stat );
                if (statnum== upgr2.Stat|| statnum == upgr3.Stat)
                {
                    RNG_Upgrade();
                    return;
                }
            }

            if (upgr1.Stat != upgr2.Stat && upgr2.Stat != upgr3.Stat && upgr1.Stat != upgr3.Stat)
            {
                Debug.Log("1скилл‘инал" + upgr1.Stat);
                Debug.Log("2скилл‘инал" + upgr2.Stat);
                Debug.Log("3скилл‘инал" + upgr3.Stat);
                UpgradeOne.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr1);
                UpgradeTwo.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr2);
                UpgradeThree.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr3);
            }
            else { RNG_Upgrade(); return; }
            return;

        }
        if (ListActiveUpg.Count >= AvalibaleSkillList.Count/2)
        {
            Debug.Log("lox3");
            int count = AvalibaleSkillList.Count;
            int count2 = ListActiveUpg.Count;
            int n1 = ListActiveUpg[Random.Range(0, count2)];
            int n2 = ListActiveUpg[Random.Range(0, count2)]; 
            int n3 = AvalibaleSkillList[Random.Range(0, count)];
            upgrade upgr1;
            if (Lvls[n1-1] % 2 == 1)
            {
                upgr1 = ListUpg2[n1 - 1];
            }
            else
            {
                upgr1 = ListUpg1[n1 - 1];
            }
            upgrade upgr2;
            if (Lvls[n2-1] % 2 == 1)
            {
                upgr2 = ListUpg2[n2-1];
            }
            else
            {
                upgr2 = ListUpg1[n2 - 1];
            }
            upgrade upgr3 = ListUpg1[n3-1];

            foreach (int statnum in ListActiveUpg)
            {
                Debug.Log(statnum);
                Debug.Log("3скилл" + upgr3.Stat);
                if (statnum == upgr3.Stat)
                {
                    RNG_Upgrade();
                    return;
                }
            }

            if (upgr1.Stat != upgr2.Stat && upgr2.Stat != upgr3.Stat && upgr1.Stat != upgr3.Stat)
            {
                Debug.Log("3скилл‘инал" + upgr3.Stat);
                UpgradeOne.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr1);
                UpgradeTwo.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr2);
                UpgradeThree.GetComponent<SpecialUpgradeDisplay>().GetUpgrade(upgr3);

            }
            else { RNG_Upgrade(); return; }
            return;
        }
        

    }   
    public void NewActiveUpgrade(int upgrnumber)
    {
        Debug.Log(" олво скилов" + ListActiveUpg.Count);
        int nums=0;
        if (ListActiveUpg.Count == 0)
        {
            ListActiveUpg.Add(upgrnumber );
        }

        if (ListActiveUpg.Count > 0)
        {
            foreach (int upnum in ListActiveUpg)
            {
                if (upnum != upgrnumber)
                {
                    nums += 1;
                    //Debug.Log("Nuyms" + nums);
                }
            }
        }
        
        if (nums != 0 && nums == ListActiveUpg.Count)
        {
            ListActiveUpg.Add(upgrnumber );
            //Debug.Log(" олво скилов" + ListActiveUpg.Count);
        }
        
        Lvls[upgrnumber-1] = Lvls[upgrnumber-1] + 1;
        //Debug.Log("Ћвл" + Lvls[upgrnumber - 1]);
        if(Lvls[upgrnumber - 1] == 4)
        {
           DeleteSkill(upgrnumber);
            
        }
    }
    
    public void DeleteSkill(int upgrnumber)
    {
        AvalibaleSkillList.Remove(upgrnumber);
        ListActiveUpg.Remove(upgrnumber);
        Debug.Log("”далено" + (upgrnumber));
    }
}
