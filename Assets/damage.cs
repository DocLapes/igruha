using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class damag : MonoBehaviour
{
    [SerializeField] private int damage;
    private bool isatack;
    
    
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.GetComponent<smert>() != null)
    //        collision.gameObject.GetComponent<smert>().takedamage(damage);
    //        collision.gameObject.GetComponent<smert>().otkinyt(-30);

    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.GetComponent<smert>() != null)
    //        other.gameObject.GetComponent<smert>().takedamage(damage);
    //        other.gameObject.GetComponent<move>().StunEntity(stuntime);
    //        other.gameObject.GetComponent<smert>().otkinytbyatack(direction, power);

    //}
    //private void Update()
    //{

    //    collider.GetComponent<DamagedealEnemy>().ProcessHit(Vector2.left);
    //}
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        Collider2D collider = GetComponent<Collider2D>();
        
        RaycastHit2D[] hits = new RaycastHit2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("player");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        for (int i = 0; i < c_hits; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.collider.gameObject.GetComponent<Smert>() != null & isatack == false)
                //hit.collider.gameObject.GetComponent<move>().StunEntity(stuntime);
                hit.collider.gameObject.GetComponent<Smert>().takedamage(damage);
                //hit.collider.gameObject.GetComponent<smert>().otkinytbyatack(direction, power);
                Atackreload(3);



        }

    }
    public void Atackreload(float atacktimemetod)
    {
        isatack = true;
        Invoke(nameof(OutAtackreload), atacktimemetod);
    }
    public void OutAtackreload()
    {
        isatack = false;
    }
}

