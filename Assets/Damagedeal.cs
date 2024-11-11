using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagedeal : MonoBehaviour
{
    private int damage = 5;
    private int power = 45;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject Hero;
    private Rigidbody2D rb;
    float stuntime = 0.5f;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject visualmodel;
    

    void Start()
    {
       
    }
    public void ProcessHit(Vector2 direction)
    {

       
        //this.spriteRenderer = hitboxL.GetComponent<SpriteRenderer>();
        //this.spriteRenderer.enabled = true;
        Hero.GetComponent<move>().StunEntity(stuntime);
        visualmodel.gameObject.GetComponent<AnimatorManager>().Atack(direction);
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
            RaycastHit2D hit= hits[i];
            if (hit.collider.gameObject.GetComponent<smert>() != null)
                hit.collider.gameObject.GetComponent<smert>().takedamage(damage);
                hit.collider.gameObject.GetComponent<smert>().otkinytbyatack(direction,power);


        }
    }
}
