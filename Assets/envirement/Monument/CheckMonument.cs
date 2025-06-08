using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMonument : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChechMon()
    {
        
        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("monument");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        for (int i = 0; i < c_hits; i++)
        {
            
            RaycastHit2D hit = hits[i];
            if (hit.collider.gameObject.GetComponentInParent<Monument>() != null)
            {
                Debug.Log("idle2");
                hit.collider.gameObject.GetComponentInParent<Monument>().GetSouls();
            }


        }
    }
}
