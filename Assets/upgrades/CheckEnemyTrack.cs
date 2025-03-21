using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyTrack : MonoBehaviour
{
    
    [SerializeField] private GameObject projectile;
    private GameObject thisgm;
    private int projNumber=1;
    private float reloadtime = 7f;
    private int damage = 13;

    private bool isreload=false;
    void Awake()
    {
        thisgm = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isreload==false)
        {
            SendProjectile();
            Atackreload(reloadtime);
        }
    }
    public void SendProjectile()
    {
        
        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[20];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("entity");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        RaycastHit2D hit = hits[0];
        float distance=1000 ;
        for (int i = 0; i < c_hits; i++)
        {
            RaycastHit2D hit2 = hits[i];
            if (hit2.collider.gameObject.GetComponent<smert>() != null)
            {
                var heading2 = hit2.transform.position - transform.position;
                float distance2 = heading2.sqrMagnitude;
                if (distance2 < distance)
                {
                    distance = distance2;
                    hit = hit2;
                }
            }
        }
        if (hit.collider.gameObject != null)
        {

            GameObject clone;
            clone = Instantiate(projectile, transform.position, Quaternion.identity);
            clone.GetComponent<TrackingProjectile>().GetDir(hit.collider.gameObject);

        }
        GameObject[] clone1 = new GameObject[projNumber];
        for (int n = 0; n < projNumber; n++)
        {
            RaycastHit2D[] checkedhits = { };
            int LengthHits = 1;
            for (int i = 0; i < c_hits; i++)
            {
                RaycastHit2D hitchek = hits[i];
                if (hitchek.collider.gameObject.GetComponent<smert>() != null)
                {
                    Array.Resize(ref checkedhits, LengthHits);
                    checkedhits[LengthHits - 1] = hitchek;
                    LengthHits += 1;
                }
            }
            RaycastHit2D hit3 = checkedhits[UnityEngine.Random.Range(0, checkedhits.Length - 1)];
            if (hit3.collider.gameObject.GetComponent<smert>() != null)
            {
                clone1[n] = Instantiate(projectile, transform.position, Quaternion.identity);
                clone1[n].GetComponent<TrackingProjectile>().GetDir(hit3.collider.gameObject);
                clone1[n].GetComponent<TrackingProjectile>().UpdateDmg(damage);
            }
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
        reloadtime += -0.25f;

    }
    public void GetUpgradeType2(int lvl)
    {
        if (lvl == 2)
        {
            projNumber = 3;
        }
        if (lvl == 4)
        {
            projNumber = 5;
        }
    }
}
