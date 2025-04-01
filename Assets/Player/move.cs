using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    bool isstuned;
    bool nodash;
    private Rigidbody2D rb;
    private Collider2D colider;
    [SerializeField] private float speed;
    [SerializeField] private float speedatk;
    [SerializeField] private GameObject ExplosionAfterDash;
    [SerializeField] private GameObject Nimb;
    [SerializeField] private bool isSpecialDash=false;
    private float DashKDTime = 3f;
    //[SerializeField] private float maxspeed;
    private Vector2 moveVector;
    //[SerializeField] private GameObject visualmodel;
    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<Collider2D>();
        
    }

    void Update()
    {
        if (Nimb != null && nodash==false)
        {
            Nimb.GetComponent<AnimatorManager>().Idle();
        }

    }
    public void Dash(Vector2 direction)
    {
        if (nodash) return;
        StunEntity(0.1f);
        if (isSpecialDash == true) {
            ExplosionAfterDash.GetComponent<SpawnObject>().Spawn(transform.position);
        }
        //rb.MovePosition(rb.position + direction*3f);
        rb.velocity = moveVector.normalized * 15 * Time.fixedDeltaTime * 100;
        //rb.AddForce(direction * 40f * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
        DashKD(DashKDTime);
    }
   
    public void Move(Vector2 direction)
    {

      
      if (isstuned) return;
      //visualmodel.gameObject.GetComponent<AnimatorManager>().walking();
      moveVector = direction;
      rb.velocity= moveVector.normalized * speed * Time.fixedDeltaTime*100;
      //rb.AddForce(moveVector.normalized * 1f * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);

        //if (rb.velocity.magnitude > maxspeed)
        //{
        //    rb.velocity = rb.velocity.normalized * maxspeed;
        //} 

    }
    public void MoveAtack(Vector2 direction)
    {


        if (isstuned) return;
        //visualmodel.gameObject.GetComponent<AnimatorManager>().walking();
        moveVector = direction;
        rb.velocity = moveVector.normalized * speedatk * Time.fixedDeltaTime * 100;
        //if (rb.velocity.magnitude > maxspeed)
        //{
        //    rb.velocity = rb.velocity.normalized * maxspeed;
        //} 

    }
    public void StunEntity(float stuntime)
    {
        rb.velocity = new Vector2(0,0);
        isstuned=true;
        Invoke(nameof (OutStunEntity), stuntime);
    }
    public void OutStunEntity()
    {
        isstuned = false;
    }
    public void DashKD(float stuntime)
    {

        nodash = true;
        Nimb.SetActive(false);
        Invoke(nameof(DashKDEnd), stuntime);
    }
    public void DashKDEnd()
    {
        nodash = false;
        Nimb.SetActive(true);
        Nimb.GetComponent<AnimatorManager>().Ready();
    }
    public void AktivSpDash()
    {
        isSpecialDash = true;
    }
    public void DashBuff()
    {
        DashKDTime += -0.3f;
    }

    //physic2d raycast
    //public abstract class BaseInputController
    //{

    //    public abstract void UpdateControll();
    //}

    //public class DefaultInputController : BaseInputController
    //{
    //    public DefaultInputController() { }

    //    public override void UpdateControll()
    //    {
    //        moveVector = m;
    //        rb.AddForce(moveVector * speed, ForceMode2D.Impulse);
    //    }
    //}

    //public class StunInputController : BaseInputController
    //{
    //    public override void UpdateControll()
    //    {
    //        //Можно, например, показывать всплывающее сообщение над персонажем при попытке его сдвинуть
    //    }
    //}
    //public class AtackInputController : BaseInputController
    //{
    //    public override void UpdateControll()
    //    {
    //        //Можно, например, показывать всплывающее сообщение над персонажем при попытке его сдвинуть
    //    }
    //}
}
