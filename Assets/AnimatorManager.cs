using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    private Animator entityanimator;
    private SpriteRenderer spriter;
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
    public void walking()
    {
        if(Hero.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            spriter.flipX = false;
            entityanimator.CrossFade("walk", 0f, 0);
        }
        if (Hero.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            spriter.flipX = true;
            entityanimator.CrossFade("walk", 0f, 0);
        }

    }
    public void idle()
    {
            entityanimator.CrossFade("idle", 0f, 0); ;
    }
}
