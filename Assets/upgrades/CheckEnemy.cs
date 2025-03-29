using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    
    [SerializeField] private GameObject projectile;
    private GameObject thisgm;
    private int damage = 25;
    private int numberofHits = 1;
    private float reloadtime = 7f;
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
            var heading = hit.transform.position - thisgm.transform.position;
            float distance = heading.sqrMagnitude;
            if (hit.collider.gameObject.GetComponent<Smert>() != null)
            {
                for (int i = 0; i < c_hits; i++)
                {
                    RaycastHit2D hit2 = hits[i];
                    var heading2 = hit2.transform.position - transform.position;
                    float distance2 = heading.sqrMagnitude;
                    if (distance2 < distance)
                    {
                        distance = distance2;
                        hit = hit2;
                    }
                }

                GameObject clone;
                GameObject clone2;
                GameObject clone3;
                Vector3 direction = hit.transform.position - thisgm.transform.position;
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
