using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagedeal : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int power;
    [SerializeField] private float lifestealpercent;
    //[SerializeField] private GameObject hitbox;
    //[SerializeField] private GameObject Hero;
    private Rigidbody2D rb;
    private GameObject gm;
    [SerializeField] private float stuntime;
    private SpriteRenderer spriteRenderer;
    [SerializeField] public GameObject projectile;
    public bool isprojectile = false;
    //[SerializeField] private GameObject hitboxV;


    void Start()
    {
        
    }
    public void ProcessHit(Vector2 direction)
    {


        //this.spriteRenderer = hitboxL.GetComponent<SpriteRenderer>();
        //this.spriteRenderer.enabled = true;
        //Hero.GetComponent<move>().StunEntity(stuntime);
        
        //Debug.Log("говно");
        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[3];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("entity");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        // Instantiate the projectile at the position and rotation of this transform
        if (isprojectile == true)
        {
            GameObject clone;
            clone = Instantiate(projectile, transform.position, Quaternion.identity);

            clone.GetComponent<Projectile>().GetDir(direction);
        }
        for (int i = 0; i < c_hits; i++)
        {
            RaycastHit2D hit= hits[i];
            if (hit.collider.gameObject.GetComponent<smert>() != null)
            {
                
                hit.collider.gameObject.GetComponentInChildren<EntityAi>().StunEntity(stuntime);

                hit.collider.gameObject.GetComponent<smert>().takedamage(damage);
                hit.collider.gameObject.GetComponent<smert>().otkinytbyatack(direction, power);
            }



        }
    }
    public void ProcessHitShield(Vector2 direction)
    {


        //this.spriteRenderer = hitboxL.GetComponent<SpriteRenderer>();
        //this.spriteRenderer.enabled = true;
        //Hero.GetComponent<move>().StunEntity(stuntime);

        //Debug.Log("говно");
        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[20];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("entity");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        // Instantiate the projectile at the position and rotation of this transform
        for (int i = 0; i < c_hits; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.collider.gameObject.GetComponent<smert>() != null)
            {

                hit.collider.gameObject.GetComponentInChildren<EntityAi>().StunEntity(stuntime);

                hit.collider.gameObject.GetComponent<smert>().takedamage(damage);
                hit.collider.gameObject.GetComponent<smert>().otkinytbyatack(direction, power);
            }



        }
    }
    public void ProcessHitCircle()
    {

        gm = gameObject;
        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[20];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask("entity");
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        // Instantiate the projectile at the position and rotation of this transform
        for (int i = 0; i < c_hits; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.collider.gameObject.GetComponent<smert>() != null)
            {
                hit.collider.gameObject.GetComponent<EntityAi>().StunEntity(0.1f);
                hit.collider.gameObject.GetComponent<smert>().takedamage(damage);
                hit.collider.gameObject.GetComponent<smert>().otkinytbyatack(hit.collider.gameObject.transform.position - gm.transform.position, power);
            }

        }
    }
    public void ProcessHitlifesteal(Vector2 direction, GameObject entity)
    {
        gm = gameObject;

        //this.spriteRenderer = hitboxL.GetComponent<SpriteRenderer>();
        //this.spriteRenderer.enabled = true;
        //Hero.GetComponent<move>().StunEntity(stuntime);

        //Debug.Log("говно");
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
            if (hit.collider.gameObject.GetComponent<smert>() != null)
            {
                hit.collider.gameObject.GetComponent<EntityAi>().StunEntity(stuntime);
                hit.collider.gameObject.GetComponent<smert>().Lifesteal(entity, lifestealpercent);
                hit.collider.gameObject.GetComponent<smert>().takedamage(damage);
                hit.collider.gameObject.GetComponent<smert>().otkinytbyatack(hit.collider.gameObject.transform.position - gm.transform.position, power);
            }



        }
    }
    public void DMG()
    {
        damage += 3;
    }
    public void GetPrjctl()
    {
        isprojectile = true;
    }

}
