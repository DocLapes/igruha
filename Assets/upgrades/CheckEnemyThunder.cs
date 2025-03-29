using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CheckEnemyThunder : MonoBehaviour
{
    
    [SerializeField] private GameObject explosion;
    private GameObject thisgm;
    private int damage = 25;
    private int numberofThunder = 1;
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

            for (int n = 0; n < numberofThunder; n++)
            {
                RaycastHit2D hit = hits[Random.Range(0, c_hits)];
                if (hit.collider.gameObject.GetComponent<Smert>() != null)
                {
                    ThunderStroke(hit);
                }

            }
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
        damage += 5;
        reloadtime += -0.25f;
        
    }
    public void GetUpgradeType2(int lvl)
    {
        if (lvl == 2)
        {
            numberofThunder = 2;
        }
        if (lvl == 4)
        {
            numberofThunder = 3;
        }
    }
    public void ThunderStroke(RaycastHit2D enemy)
    {
        GameObject clone;
        clone = Instantiate(explosion, enemy.transform.position, Quaternion.identity);
        clone.GetComponent<Explosion>().GiveExplosionDamage(damage);
    }
}
