using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SaintCircle : MonoBehaviour
{
    private GameObject circle;
    private bool isreload;
    private float reloadtime = 1;
    int damage = 6;
    private Vector3 Scale;
    void Awake()
    {
        circle= gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isreload==false)
        {
            circle.gameObject.GetComponent<Damagedeal>().ProcessHitCircle();
            Atackreload(reloadtime);
        }
    }
    public void Atackreload(float atacktimemetod)
    {
        isreload = true;
        
        Invoke(nameof(OutAtackreload), atacktimemetod);
    }
    public void OutAtackreload()
    {
        isreload = false;
    }
    public void GetUpgradeType1()
    {
        damage += 3;
        circle.GetComponent<Damagedeal>().GetDamag(damage);

    }
    public void GetUpgradeType2(int lvl)
    {
        circle.transform.localScale = circle.transform.localScale * 1.2f;
    }
}
