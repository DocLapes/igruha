using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedealEnemy : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int power;
    private GameObject gm;
    //[SerializeField] private GameObject hitbox;
    //[SerializeField] private GameObject Hero;
    private Rigidbody2D rb;
    [SerializeField] private float stuntime;
    private SpriteRenderer spriteRenderer;
    //[SerializeField] private GameObject hitboxV;


    void Start()
    {

    }
    public void ProcessHit(Vector2 direction)
    {
        //this.spriteRenderer = hitboxL.GetComponent<SpriteRenderer>();
        //this.spriteRenderer.enabled = true;
        //Hero.GetComponent<move>().StunEntity(stuntime);
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
            if (hit.collider.gameObject.GetComponent<Smert>() != null)
                hit.collider.gameObject.GetComponent<move>().StunEntity(stuntime);
                hit.collider.gameObject.GetComponent<Smert>().takedamage(damage);
                hit.collider.gameObject.GetComponent<Smert>().otkinytbyatack(direction, power);
        }
    }
    public void ProcessHitCircle()
    {

        gm = gameObject;
        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[20];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("player");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        // Instantiate the projectile at the position and rotation of this transform
        for (int i = 0; i < c_hits; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.collider.gameObject.GetComponent<Smert>() != null)
            {
                hit.collider.gameObject.GetComponent<Smert>().takedamage(damage);
                hit.collider.gameObject.GetComponent<Smert>().otkinytbyatack(hit.collider.gameObject.transform.position - gm.transform.position, power);
            }

        }
    }
}
