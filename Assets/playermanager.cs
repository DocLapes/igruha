using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    [SerializeField] private GameObject hitboxL;
    [SerializeField] private GameObject hitboxR;
    [SerializeField] private GameObject hitboxU;
    [SerializeField] private GameObject hitboxD;
    private SpriteRenderer spriteRenderer;
    private Vector2 cmoveVector;
    private Vector2 moveVector;
    private Vector2 lastmove;
    [SerializeField] private GameObject visualmodel;

    // Update is called once per frame
    void Awake()
    {
        
    }
    
    void Update()
    {

       
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.y = Input.GetAxis("Vertical");
            lastmove = moveVector.normalized;
            
        }


        if (Input.GetMouseButtonDown(0))
        {
            
            if(lastmove == Vector2.left)
            {
                
                Debug.Log("левой");

                hitboxL.gameObject.GetComponent<Damagedeal>().ProcessHit();

            }
            if (lastmove == Vector2.right)
            {
                Debug.Log("правой");
                hitboxR.gameObject.GetComponent<Damagedeal>().ProcessHit();
            }
            if (lastmove == Vector2.up)
            {
                Debug.Log("вверх");
                hitboxU.gameObject.GetComponent<Damagedeal>().ProcessHit();
            }
            if (lastmove == Vector2.down)
            {
                Debug.Log("вниз");
                hitboxD.gameObject.GetComponent<Damagedeal>().ProcessHit();
            }


        }
    }
    void FixedUpdate()
    {
        
        //visualmodel.gameObject.GetComponent<AnimatorManager>().walking();
        hitboxL.GetComponent<SpriteRenderer>().enabled = false;
        hitboxR.GetComponent<SpriteRenderer>().enabled = false;
        hitboxU.GetComponent<SpriteRenderer>().enabled = false;
        hitboxD.GetComponent<SpriteRenderer>().enabled = false;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            visualmodel.gameObject.GetComponent<AnimatorManager>().walking();
            Hero.GetComponent<Rigidbody2D>().drag = 1;

        }
        else
        {
            Hero.GetComponent<Rigidbody2D>().drag = 25;
            visualmodel.gameObject.GetComponent<AnimatorManager>().idle();
        }
        cmoveVector.x = Input.GetAxis("Horizontal");
        cmoveVector.y = Input.GetAxis("Vertical");
        Hero.gameObject.GetComponent<move>().Move(cmoveVector.normalized);


    }

    
}

