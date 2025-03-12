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
    void Start()
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
}
