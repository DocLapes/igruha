using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class SpearAtackNumber : MonoBehaviour
{
    [SerializeField] private GameObject firstSpear;
    [SerializeField] private GameObject secondSpear;
    [SerializeField] private GameObject thirdSpear;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AtackSpear()
    {
        firstSpear.gameObject.GetComponent<PlayerAim>().Hit();
        if (secondSpear != null) secondSpear.gameObject.GetComponent<PlayerAim>().Hit();
        if (thirdSpear != null) thirdSpear.gameObject.GetComponent<PlayerAim>().Hit();

    }
    public void UpgradeDamage(int damag)
    {
        firstSpear.gameObject.GetComponent<Damagedeal>().GetDamag(damag);
        if (secondSpear != null) secondSpear.gameObject.GetComponent<Damagedeal>().GetDamag(damag);
        if (thirdSpear != null) thirdSpear.gameObject.GetComponent<Damagedeal>().GetDamag(damag);
    }
    public void GiveStats()
    {

    }
    public void UpgradeProjDamage(int damag)
    {
        Debug.Log("продж3");
        firstSpear.gameObject.GetComponent<Damagedeal>().GetProjDamag(damag);
        if (secondSpear != null) secondSpear.gameObject.GetComponent<Damagedeal>().GetProjDamag(damag);
        if (thirdSpear != null) thirdSpear.gameObject.GetComponent<Damagedeal>().GetProjDamag(damag);
    }
    public void UpgradeNumberofHits(int num)
    {
        firstSpear.gameObject.GetComponent<Damagedeal>().NumberofHits(num);
        if (secondSpear != null) secondSpear.gameObject.GetComponent<Damagedeal>().NumberofHits(num);
        if (thirdSpear != null) thirdSpear.gameObject.GetComponent<Damagedeal>().NumberofHits(num);
    }
}
