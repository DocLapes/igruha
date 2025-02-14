using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 5;
    private bool isatack;
    private GameObject Pr;
    private Vector2 Direction;
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

    void Awake()
    {
        Pr = gameObject;
    }
    private void FixedUpdate()
    {
        Pr.GetComponent<move>().Move(Direction);


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
                //hit.collider.gameObject.GetComponent<move>().StunEntity(stuntime);
                hit.collider.gameObject.GetComponent<smert>().takedamage(damage);
                Destroy(Pr);
            //hit.collider.gameObject.GetComponent<smert>().otkinytbyatack(direction, power);
            //Atackreload(3);
            if (hit.collider.gameObject.GetComponent<smert>() == null)
            {
                Destroy(Pr);
            }



        }

    }
    public void GetDir(Vector3 dir)
    {
        Direction=dir;
    }
    //public void Atackreload(float atacktimemetod)
    //{
    //    isatack = true;
    //    Invoke(nameof(OutAtackreload), atacktimemetod);
    //}
    //public void OutAtackreload()
    //{
    //    isatack = false;
    //}
}
