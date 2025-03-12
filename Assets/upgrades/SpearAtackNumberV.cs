using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class SpearAtackNumberV : MonoBehaviour
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
    public void AtackSpearVisual()
    {
        
        firstSpear.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack();
        if (secondSpear != null) secondSpear.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack();
        if (thirdSpear != null) thirdSpear.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack();
    }
}
