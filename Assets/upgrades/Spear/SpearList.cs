using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearList : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Spear1;
    [SerializeField] private GameObject Spear2;
    [SerializeField] private GameObject Spear3;
    private int damage= 10;
    private int projdamage = 6;
    private bool isprojaktive=false;
    private GameObject aktiveSpear;
    private int numberofhits=1;
    void Start()
    {
        aktiveSpear = Spear1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetUpgradeType1()
    {
        
        gameObject.transform.localScale = gameObject.transform.localScale * 1.2f;
    }
    public void GetUpgradeType2(int lvl)
    {
        if (lvl == 2)
        {
            Spear1.gameObject.SetActive(false);
            Spear2.gameObject.SetActive(true);
            aktiveSpear = Spear2;
            if(isprojaktive == true)
            {
                aktiveSpear.GetComponent<SpearAtackNumber>().UpgradeProjDamage(projdamage);
            }
            Spear2.GetComponent<SpearAtackNumber>().UpgradeDamage(damage);
        }
        if (lvl == 4)
        {

            Spear2.gameObject.SetActive(false);
            Spear3.gameObject.SetActive(true);
            aktiveSpear = Spear3;
            if (isprojaktive == true)
            {
                aktiveSpear.GetComponent<SpearAtackNumber>().UpgradeProjDamage(projdamage);
            }
            Spear3.GetComponent<SpearAtackNumber>().UpgradeDamage(damage);
        }
    }
    public void DMG()
    {
        damage += 3;
        aktiveSpear.GetComponent<SpearAtackNumber>().UpgradeDamage(damage);
    }
    public void ProjGetUpgradeType1()
    {
        Debug.Log("продж2");
        isprojaktive =true;  
        projdamage += 3;
        aktiveSpear.GetComponent<SpearAtackNumber>().UpgradeProjDamage(projdamage);
        aktiveSpear.GetComponent<SpearAtackNumber>().UpgradeNumberofHits(numberofhits);
    }
    public void ProjGetUpgradeType2(int lvl)
    {
        numberofhits += 1;
        aktiveSpear.GetComponent<SpearAtackNumber>().UpgradeNumberofHits(numberofhits);
    }
   
}
