using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private int damage = 25;
    [SerializeField] private int numberofHits = 1;
    private float reloadtime = 7f;
    private bool isreload=false;
    [SerializeField] private bool superupg;
    [SerializeField] private bool isbounce;
   
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isreload==false)
        {
            if (isbounce == true)
            {
                SendProjectile2();
            }
            else if (superupg == true)
            {
                SendProjectile3();
            }
            else 
            { 
                SendProjectile(); 
            }
            
            
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
        if(c_hits > 0) {
            Atackreload(reloadtime);
            RaycastHit2D hit = hits[0];
            float distance = 1000;
            for (int i = 0; i < c_hits; i++)
            {
                RaycastHit2D hit2 = hits[i];
                if (hit2.collider.gameObject.GetComponent<Smert>() != null)
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
            if (hit.collider.gameObject.GetComponent<Smert>() != null)
            {
                GameObject clone;
                GameObject clone2;
                GameObject clone3;
                Vector3 direction = hit.transform.position - gameObject.transform.position;
                clone = Instantiate(projectile, transform.position, Quaternion.identity);
                clone.GetComponent<Projectile>().GetDmg(damage);
                clone.GetComponent<Projectile>().GetNum(numberofHits);
                clone.GetComponent<Projectile>().GetDir(direction);
                clone2 = Instantiate(projectile, transform.position, Quaternion.identity);
                clone2.GetComponent<Projectile>().GetDmg(damage);
                clone2.GetComponent<Projectile>().GetNum(numberofHits);
                clone2.GetComponent<Projectile>().GetDir(direction + new Vector3(1f, 1f, 0));
                clone3 = Instantiate(projectile, transform.position, Quaternion.identity);
                clone3.GetComponent<Projectile>().GetDmg(damage);
                clone3.GetComponent<Projectile>().GetNum(numberofHits);
                clone3.GetComponent<Projectile>().GetDir(direction + new Vector3(-1f, -1f, 0));
            }
        }
        
    }
    public void SendProjectile2()
    {

        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[20];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("entity");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        if (c_hits > 0)
        {
            Atackreload(reloadtime);
            RaycastHit2D hit = hits[0];
            float distance = 1000;
            for (int i = 0; i < c_hits; i++)
            {
                RaycastHit2D hit2 = hits[i];
                if (hit2.collider.gameObject.GetComponent<Smert>() != null)
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
            if (hit.collider.gameObject.GetComponent<Smert>() != null)
            {
                GameObject clone;
                Vector3 direction = hit.transform.position - gameObject.transform.position;
                clone = Instantiate(projectile, transform.position, Quaternion.identity);
                clone.GetComponent<Projectile>().GetDmg(damage);
                clone.GetComponent<Projectile>().GetNum(numberofHits);
                clone.GetComponent<Projectile>().GetDir(direction);
                clone.GetComponent<Projectile>().GetCheckModule(gameObject);

            }
        }

    }
    public void SendProjectile3()
    {

        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[20];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("entity");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        if (c_hits > 0)
        {
            Atackreload(reloadtime);
            RaycastHit2D hit = hits[0];
            float distance = 1000;
            for (int i = 0; i < c_hits; i++)
            {
                RaycastHit2D hit2 = hits[i];
                if (hit2.collider.gameObject.GetComponent<Smert>() != null)
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
            if (hit.collider.gameObject.GetComponent<Smert>() != null)
            {
                GameObject clone;
                GameObject clone2;
                GameObject clone3;
                Vector3 direction = hit.transform.position - gameObject.transform.position;
                clone = Instantiate(projectile, transform.position, Quaternion.identity);
                clone.GetComponent<Projectile>().GetDmg(damage);
                clone.GetComponent<Projectile>().GetNum(numberofHits);
                clone.GetComponent<Projectile>().GetDir(direction);
                clone.GetComponent<Projectile>().GetCheckModule(gameObject);
                clone2 = Instantiate(projectile, transform.position, Quaternion.identity);
                clone2.GetComponent<Projectile>().GetDmg(damage);
                clone2.GetComponent<Projectile>().GetNum(numberofHits);
                clone2.GetComponent<Projectile>().GetCheckModule(gameObject);
                clone2.GetComponent<Projectile>().GetDir(direction + new Vector3(1f, 1f, 0));
                clone3 = Instantiate(projectile, transform.position, Quaternion.identity);
                clone3.GetComponent<Projectile>().GetDmg(damage);
                clone3.GetComponent<Projectile>().GetNum(numberofHits);
                clone3.GetComponent<Projectile>().GetCheckModule(gameObject);
                clone3.GetComponent<Projectile>().GetDir(direction + new Vector3(-1f, -1f, 0));

            }
        }

    }
    public void ChangeDirection(GameObject bouncproj)
    {

        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[20];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("entity");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        RaycastHit2D hit = hits[0];
        //float distance = 1000;
        if (c_hits > 0)
        {
            hit = hits[Random.Range(0, c_hits)];
            //for (int i = 0; i < c_hits; i++)
            //{
            //    RaycastHit2D hit2 = hits[i];
            //    if (hit2.collider.gameObject.GetComponent<Smert>() != null)
            //    {
            //        var heading2 = hit2.transform.position - transform.position;
            //        float distance2 = heading2.sqrMagnitude;
            //        if (distance2 < distance)
            //        {
            //            distance = distance2;
            //            hit = hit2;
            //        }
            //    }
            //}
            if (hit.collider.gameObject.GetComponent<Smert>() != null)
            {
                Vector3 direction = hit.transform.position - bouncproj.transform.position;
                bouncproj.GetComponent<Projectile>().GetDir(direction);
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
        damage += 5;
        reloadtime += -0.25f;
        
    }
    public void GetUpgradeType2(int lvl)
    {
        if (lvl == 2)
        {
            numberofHits = 2;
        }
        if (lvl == 4)
        {
            numberofHits = 3;
        }
    }
}
