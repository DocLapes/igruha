using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    [SerializeField] private GameObject hitboxL;
    [SerializeField] private GameObject hitboxR;
    [SerializeField] private GameObject hitboxU;
    [SerializeField] private GameObject hitboxD;
    [SerializeField] private int drift;
    private SpriteRenderer spriteRenderer;
    private Vector2 cmoveVector;
    private Vector2 moveVector;
    private Vector2 lastmove;
    [SerializeField] private GameObject visualmodel;
    private bool isatack;
    private float atacktime=1f;

    // Update is called once per frame
    void Awake()
    {
        
    }

    void Update()
    {
        
        cmoveVector.x = Input.GetAxisRaw("Horizontal");
        cmoveVector.y = Input.GetAxisRaw("Vertical");
        

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            moveVector.x = Input.GetAxisRaw("Horizontal");
            moveVector.y = Input.GetAxisRaw("Vertical");
            lastmove = moveVector.normalized;

        }


        if (Input.GetMouseButtonDown(0) & isatack == false )
        {

            StartCoroutine(Atackwithdelay(lastmove));

        }
    }
    public void Atackreload(float atacktimemetod)
    {
        isatack = true;
        Invoke(nameof(OutAtackreload), atacktimemetod);
    }
    public void OutAtackreload()
    {
        isatack = false;
    }
    
    void FixedUpdate()
    {
        if (cmoveVector.normalized != Vector2.zero)
        {
            Hero.gameObject.GetComponent<move>().Move(cmoveVector.normalized);
        }
        //visualmodel.gameObject.GetComponent<AnimatorManager>().walking();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            visualmodel.gameObject.GetComponent<AnimatorManager>().Walking();
            Hero.GetComponent<Rigidbody2D>().drag = 0;

        }
        else
        {
            Hero.GetComponent<Rigidbody2D>().drag = drift;
            visualmodel.gameObject.GetComponent<AnimatorManager>().Idle();
        }
        
        
        if (Input.GetKey(KeyCode.Space) & isatack == false)
        {
            Hero.gameObject.GetComponent<move>().Dash(cmoveVector.normalized);
            Atackreload(atacktime);
        }


    }

    private IEnumerator Atackwithdelay( Vector2 Atackdirection)
    {
        if (Atackdirection == Vector2.left)
        {
            hitboxL.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack(Vector2.left);
            yield return new WaitForSeconds(0.1f);
            hitboxL.gameObject.GetComponent<Damagedeal>().ProcessHit(Vector2.left);
            Atackreload(atacktime);
        }
        if (Atackdirection == Vector2.right)
        {
            hitboxR.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack(Vector2.right);
            yield return new WaitForSeconds(0.1f);
            hitboxR.gameObject.GetComponent<Damagedeal>().ProcessHit(Vector2.right);
            Atackreload(atacktime);
        }
        if (Atackdirection == Vector2.up)
        {
            hitboxU.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack(Vector2.up);
            yield return new WaitForSeconds(0.1f);
            hitboxU.gameObject.GetComponent<Damagedeal>().ProcessHit(Vector2.up);
            Atackreload(atacktime);
        }
        if (Atackdirection == Vector2.down)
        {
            hitboxD.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack(Vector2.down);
            yield return new WaitForSeconds(0.1f);
            hitboxD.gameObject.GetComponent<Damagedeal>().ProcessHit(Vector2.down);
            Atackreload(atacktime);
        }
    }

}

