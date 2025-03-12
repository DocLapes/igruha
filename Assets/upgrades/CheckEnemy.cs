using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    
    [SerializeField] private GameObject projectile;
    private GameObject thisgm;

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
            Atackreload(5);
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
        var heading = hit.transform.position - transform.position;
        float distance = heading.sqrMagnitude;
        if (hit.collider.gameObject.GetComponent<smert>() != null)
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
            clone = Instantiate(projectile, transform.position, Quaternion.identity);
            clone.GetComponent<Projectile>().GetDir(hit.transform.position - thisgm.transform.position);
            clone2 = Instantiate(projectile, transform.position, Quaternion.identity);
            clone2.GetComponent<Projectile>().GetDir(hit.transform.position - thisgm.transform.position + new Vector3(1f, 1f, 0));
            clone3 = Instantiate(projectile, transform.position, Quaternion.identity);
            clone3.GetComponent<Projectile>().GetDir(hit.transform.position - thisgm.transform.position + new Vector3(-1f, -1f, 0));

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
