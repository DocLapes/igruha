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
    [SerializeField] private bool isbounce;
    private Vector2 Direction;
    [SerializeField] private int numberofHits=1;
    private GameObject CheckE;
    int numofhits = 0;

    void Start()
    {
        Invoke(nameof(Destr), 5);
        
        //Pr.GetComponent<Rigidbody2D>().velocity = Direction.normalized * 3f * Time.fixedDeltaTime * 100;

    }
    private void FixedUpdate()
    {
        gameObject.GetComponent<move>().Move(Direction);
        
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
            RaycastHit2D hit = hits[i];
            Debug.Log(numofhits);
            Debug.Log(c_hits);
            if (hit.collider.gameObject.GetComponent<Smert>() != null)
            {
                numofhits += 1;
                //hit.collider.gameObject.GetComponent<move>().StunEntity(stuntime);
                hit.collider.gameObject.GetComponent<Smert>().takedamage(damage);
                if (numberofHits == numofhits)
                {
                    Destroy(gameObject);
                }
                if (isbounce == true)
                {
                    //Invoke(nameof(Bounce), 0.5f);
                    Bounce();
                }

            }

        }

    }
    public void GetDir(Vector3 dir)
    {
        Debug.Log("баунс");
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
        Destroy(gameObject);
    }
    public void GetCheckModule(GameObject checkEnemy)
    {
        CheckE=checkEnemy;
    }
    public void Bounce()
    {
        CheckE.GetComponent<CheckEnemy>().ChangeDirection(gameObject);
    }

}
