using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    bool isstuned;
    private Rigidbody2D rb;
    private Collider2D colider;
    [SerializeField] private float speed;
    [SerializeField] private float speedatk;
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
        

    }
    public void Dash(Vector2 direction)
    {
        StunEntity(0.1f);
        rb.MovePosition(rb.position + direction*2f);
        //rb.AddForce(direction * 40f * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
        
    }
   
    public void Move(Vector2 direction)
    {

      
      if (isstuned) return;
      //visualmodel.gameObject.GetComponent<AnimatorManager>().walking();
      moveVector = direction;
      rb.velocity= moveVector.normalized * speed * Time.fixedDeltaTime*100;
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
