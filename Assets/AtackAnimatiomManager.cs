using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAnimatiomManager : MonoBehaviour
{
    
    private Animator entityanimator;
    private SpriteRenderer spriter;
    private Vector2 atackVector;
    private float atacktime = 0.56f;
    private float shieldatacktime = 0.42f;
    private float healatacktime = 0.49f;
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
    public void Default()
    {
       
        entityanimator.CrossFade("default", 0f, 0); ;
        
        
    }
    public void Atack(Vector2 direction)
    {

        atackVector = direction;
        if (atackVector == Vector2.right)
        {
           
            spriter.enabled = true;
            Invoke(nameof(Otobrazeniechange), 0.6f);
            entityanimator.CrossFade("atackLR", 0f, 0);
            Invoke(nameof(Default), atacktime);
            
        }
        if (atackVector == Vector2.left)
        {
            
            spriter.enabled = true;
            Invoke(nameof(Otobrazeniechange), 0.6f);
            entityanimator.CrossFade("atackLR", 0f, 0);
            Invoke(nameof(Default), atacktime);
            

        }
        if (atackVector == Vector2.down)
        {
           
            spriter.enabled = true;
            Invoke(nameof(Otobrazeniechange), 0.6f);
            entityanimator.CrossFade("atackDW", 0f, 0);
            Invoke(nameof(Default), atacktime);

        }
        if (atackVector == Vector2.up)
        {
           
            spriter.enabled = true;
            Invoke(nameof(Otobrazeniechange), 0.6f);
            entityanimator.CrossFade("atackUP", 0f, 0);
            Invoke(nameof(Default), atacktime);

        }
    }
    public void ShieldAtack(Vector2 direction)
    {
        atackVector = direction;
        if (atackVector == Vector2.right)
        {

            spriter.enabled = true;
            Invoke(nameof(Otobrazeniechange), 0.6f);
            entityanimator.CrossFade("shield", 0f, 0);
            Invoke(nameof(Default), shieldatacktime);

        }
        if (atackVector == Vector2.left)
        {

            spriter.enabled = true;
            Invoke(nameof(Otobrazeniechange), 0.6f);
            entityanimator.CrossFade("shield", 0f, 0);
            Invoke(nameof(Default), shieldatacktime);


        }


    }

    public void HealAtack()
    {
        
        spriter.enabled = true;
        Invoke(nameof(Otobrazeniechange), 0.6f);
        entityanimator.CrossFade("heal", 0f, 0);
        Invoke(nameof(Default), shieldatacktime);

    }
    public void Otobrazeniechange()
    {
        spriter.enabled = false;
    }
}
