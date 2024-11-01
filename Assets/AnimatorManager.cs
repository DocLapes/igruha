using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    private Animator entityanimator;
    // Start is called before the first frame update
    void Start()
    {
        entityanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walking();

    }
    void walking()
    {
        if(Hero.gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            entityanimator.CrossFade("walk", 0f, 0);
        }
    }
}
