using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 5;
    private bool isatack;
    Vector3 localscale;
    [SerializeField] private string Maska;
    private GameObject Pr;
    private Vector2 Direction;
    private int numberofHits=1;
    int numofhits = 0;

    void Start()
    {
        Pr = gameObject; 
        Invoke(nameof(Destr), 5);
        
        //Pr.GetComponent<Rigidbody2D>().velocity = Direction.normalized * 3f * Time.fixedDeltaTime * 100;

    }
    private void FixedUpdate()
    {
        Pr.GetComponent<move>().Move(Direction);
        


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Collider2D collider = GetComponent<Collider2D>();
        RaycastHit2D[] hits = new RaycastHit2D[2];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = LayerMask.GetMask(Maska);
        filter.useTriggers = true;
        filter.useLayerMask = true;
        int c_hits = collider.Cast(Vector2.zero, filter, hits);
        for (int i = 0; i < c_hits; i++)
        {
            
            numofhits += 1;
            RaycastHit2D hit = hits[i];
            Debug.Log(numofhits);
            Debug.Log(numberofHits);
            if (hit.collider.gameObject.GetComponent<Smert>() != null)
            {
                //hit.collider.gameObject.GetComponent<move>().StunEntity(stuntime);
                hit.collider.gameObject.GetComponent<Smert>().takedamage(damage);
                if (numberofHits == numofhits)
                {
                    Debug.Log("встреча проджа и варага2");
                    Destroy(Pr);
                }
            }
                

        }

    }
    public void GetDir(Vector3 dir)
    {
        Direction=dir;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
        if (angle > 90 || angle < -90)
        {
            localscale.y = -0.5f;
            localscale.x = 0.5f;
            localscale.z = 1;
        }
        else
        {
            localscale.y = +0.5f;
            localscale.x = 0.5f;
            localscale.z = 1;
        }
        gameObject.transform.localScale = localscale;
        
    }
    public void GetDmg(int numdmg)
    {
        damage = numdmg;
    }
    public void GetNum(int numhits)
    {
        numberofHits = numhits;
    }
    public void Destr()
    {
        Destroy(Pr);
    }
   
}
