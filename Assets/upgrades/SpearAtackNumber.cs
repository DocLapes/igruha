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
    public void UpgradeDamage()
    {
        firstSpear.gameObject.GetComponent<Damagedeal>().DMG();
        if (secondSpear != null) secondSpear.gameObject.GetComponent<Damagedeal>().DMG();
        if (thirdSpear != null) thirdSpear.gameObject.GetComponent<Damagedeal>().DMG();
    }
}
