using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    private Animator entityanimator;
    private SpriteRenderer spriter;
    private Vector2 atackVector;
    private int animationpriority;
    private float atacktime = 0.56f;
    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        entityanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void Walking()
    {
        if (animationpriority < 2)
        {
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                spriter.flipX = false;
                entityanimator.CrossFade("walk", 0f, 0);
            }
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                spriter.flipX = true;
                entityanimator.CrossFade("walk", 0f, 0);
            }
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                entityanimator.CrossFade("walk", 0f, 0);
            }
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                entityanimator.CrossFade("walk", 0f, 0);
            }
        }
        else { return; }

    }
    public void EnemyWalking()
    {
        if (animationpriority < 2)
        {
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                spriter.flipX = false;
                entityanimator.CrossFade("walk", 0f, 0);
            }
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                spriter.flipX = true;
                entityanimator.CrossFade("walk", 0f, 0);
            }
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                entityanimator.CrossFade("walk", 0f, 0);
            }
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                entityanimator.CrossFade("walk", 0f, 0);
            }
        }
        else { return; }

    }
    public void EnemyAtackWalking()
    {
        if (animationpriority < 2)
        {
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                spriter.flipX = false;
                entityanimator.CrossFade("walkatack", 0f, 0);
            }
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                spriter.flipX = true;
                entityanimator.CrossFade("walkatack", 0f, 0);
            }
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                entityanimator.CrossFade("walkatack", 0f, 0);
            }
            if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                entityanimator.CrossFade("walkatack", 0f, 0);
            }
        }
        else { return; }

    }
    public void Idle()
    {
        if (animationpriority < 2)
        {
            entityanimator.CrossFade("idle", 0f, 0); 
        }
        else { return; }
    }
    //public void Atack(Vector2 direction)
    //{

    //    atackVector = direction;
    //    if (atackVector == Vector2.right)
    //    {
    //        animationpriority = 2;
    //        Invoke(nameof(Prioritychange), atacktime);
    //        spriter.flipX = false;
    //        entityanimator.CrossFade("atackLR", 0f, 0); 
    //    }
    //    if (atackVector == Vector2.left)
    //    {
    //        animationpriority = 2;
    //        Invoke(nameof(Prioritychange), atacktime);
            
    //        spriter.flipX = true;
    //        entityanimator.CrossFade("atackLR", 0f, 0);
            
    //    }
    //    if (atackVector == Vector2.down)
    //    {
    //        animationpriority = 2;
    //        Invoke(nameof(Prioritychange), atacktime);
    //        spriter.flipX = false;
    //        entityanimator.CrossFade("hitdown", 0f, 0);

    //    }
    //    if (atackVector == Vector2.up)
    //    {
    //        animationpriority = 2;
    //        Invoke(nameof(Prioritychange), atacktime);
    //        spriter.flipX = false;
    //        entityanimator.CrossFade("hitup", 0f, 0);

    //    }
    //}
    public void Prioritychange()
    {
        animationpriority=1;
    }
}
