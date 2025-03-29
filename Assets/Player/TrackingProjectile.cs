using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TrackingProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 5;
    private bool isatack;
    [SerializeField] private string Maska;
    private GameObject Pr;
    private GameObject Target;
    private Vector2 Direction;
    private AnimatorManager Anim;
    private int hittedmax=1;
    int hited;



    void Start()
    {
        hited = 0;
        Pr = gameObject; 
        Invoke(nameof(Destr), 5);
        Anim = Pr.GetComponentInChildren<AnimatorManager>();
        //Pr.GetComponent<Rigidbody2D>().velocity = Direction.normalized * 3f * Time.fixedDeltaTime * 100;

    }
    private void FixedUpdate()
    {
        //Anim.Walking();
        if (Target != null) {
            
            Pr.GetComponent<move>().Move(Target.transform.position - Pr.transform.position);
        }
        else {
            Anim.death();
            Invoke(nameof(Destr),0.21f); 
        }
        
        


    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (hittedmax > hited)
        {

            Smert hitted = other.gameObject.GetComponentInParent<Smert>();

            //Collider2D collider = GetComponent<Collider2D>();
            //RaycastHit2D[] hits = new RaycastHit2D[2];
            //ContactFilter2D filter = new ContactFilter2D();
            //filter.layerMask = LayerMask.GetMask(Maska);
            //filter.useTriggers = true;
            //filter.useLayerMask = true;
            //int c_hits = other.Cast(Vector2.zero, filter, hits);
            //for (int i = 0; i < c_hits; i++)
            //{
            //    RaycastHit2D hit = hits[i];
            //    if (hit.collider.gameObject.GetComponent<smert>() != null)
            //    {
            //        //hit.collider.gameObject.GetComponent<move>().StunEntity(stuntime);
            //        hit.collider.gameObject.GetComponent<smert>().takedamage(damage);
            //        Destr();
            //        Debug.Log("сел на вишнёвый пирог и заплакал2");
            //    }
            //}
            if (hitted != null && hitted.gameObject.layer == LayerMask.NameToLayer(Maska))
            {
                hited += 1;
                Debug.Log(hitted.gameObject.layer);
                Debug.Log(LayerMask.GetMask(Maska));
                //hit.collider.gameObject.GetComponent<move>().StunEntity(stuntime);
                hitted.takedamage(damage);
                Anim.death();
                Invoke(nameof(Destr), 0.21f);


            }
        }

    }
    public void GetDir(GameObject target)
    {
        Target = target;
    }
    public void UpdateDmg(int numdmg)
    {
        damage = numdmg;
    }
    public void Destr()
    {
        Destroy(Pr);
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
