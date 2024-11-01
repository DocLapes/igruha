using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{

    [SerializeField] private GameObject hitboxL;
    [SerializeField] private GameObject hitboxR;
    [SerializeField] private GameObject hitboxU;
    [SerializeField] private GameObject hitboxD;
    private Vector2 cmoveVector;
    private Vector2 moveVector;
    private Vector2 lastmove;
    [SerializeField] private GameObject Hero;
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
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            Hero.GetComponent<Rigidbody2D>().drag = 0;

        }
        else
        {
            Hero.GetComponent<Rigidbody2D>().drag = 10;

        }
        cmoveVector.x = Input.GetAxis("Horizontal");
        cmoveVector.y = Input.GetAxis("Vertical");
        Hero.gameObject.GetComponent<move>().MoveHero(cmoveVector.normalized);
    }

}
