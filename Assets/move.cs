using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    bool isstuned;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 moveVector;
    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {


    }
    public void Move(Vector2 direction)
    {
      if (isstuned) return;
      moveVector = direction;
        if (moveVector == Vector2.left)
        {

        }
      rb.AddForce(moveVector * speed * Time.fixedDeltaTime*100, ForceMode2D.Impulse);
        
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
