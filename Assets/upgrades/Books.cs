using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour
{
    private GameObject gm;
    [SerializeField] private int damage;
    [SerializeField] private int power;
    void Start()
    {
        gm = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        Collider2D collider = GetComponent<Collider2D>();

        RaycastHit2D[] hits = new RaycastHit2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("entity");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        for (int i = 0; i < c_hits; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.collider.gameObject.GetComponent<smert>() != null )
                hit.collider.gameObject.GetComponent<move>().StunEntity(0.1f);
                hit.collider.gameObject.GetComponent<smert>().takedamage(damage);
                hit.collider.gameObject.GetComponent<smert>().otkinytbyatack(hit.collider.gameObject.transform.position - gm.transform.position, power);
            



        }

    }
}
