using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    [SerializeField] private GameObject Aim;
    [SerializeField] private GameObject shieldR;
    [SerializeField] private GameObject shieldL;
    [SerializeField] private GameObject HealAtack;
    private Rigidbody2D rb;
    [SerializeField] private int drift;
    private SpriteRenderer spriteRenderer;
    private Vector2 cmoveVector;
    private Vector2 moveVector;
    private Vector2 lastmove;
    [SerializeField] private GameObject visualmodel;
    private bool isatack;
    private bool shieldisatack;
    private bool healisatack;
    [SerializeField] private float atacktime=1f;
    [SerializeField] private float shieldatacktime = 1f;
    [SerializeField] private float healdatacktime = 1f;
    bool atacking;

    // Update is called once per frame
    void Awake()
    {
        rb = Hero.GetComponent<Rigidbody2D>();
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
        if (PauseMenu.ispaused == false)
        {
            if (Input.GetKeyDown(KeyCode.E) & shieldisatack == false)
            {

                StartCoroutine(ShieldAtackwithdelay(lastmove));

            }
            if (Input.GetKeyDown(KeyCode.Q) & healisatack == false)
            {

                StartCoroutine(HealAtackwithdelay());

            }

            //if (Input.GetMouseButtonDown(0) & isatack == false )
            //{

            //    StartCoroutine(Atackwithdelay(lastmove));

            //}
            if (atacking==true & isatack == false)
            {

                StartCoroutine(Atackwithdelay1());

            }
            if (Input.GetMouseButtonDown(0) )
            {

                atacking = !atacking;

            }
        }
       
    }
    public void Atackreload(float atacktimemetod)
    {
        isatack = true;
        Aim.gameObject.GetComponentInChildren<PlayerAim>().ChangeBool();
        Invoke(nameof(OutAtackreload), atacktimemetod);
    }
    public void OutAtackreload()
    {
        Aim.gameObject.GetComponentInChildren<PlayerAim>().ChangeBool();
        isatack = false;
    }
    public void ShieldAtackreload(float atacktimemetod)
    {
        shieldisatack = true;
        Invoke(nameof(ShieldOutAtackreload), atacktimemetod);
    }
    public void ShieldOutAtackreload()
    {
        shieldisatack = false;
    }
    public void HealdAtackreload(float atacktimemetod)
    {
        healisatack = true;
        Invoke(nameof(HealdOutAtackreload), atacktimemetod);
    }
    public void HealdOutAtackreload()
    {
        healisatack = false;
    }
    void FixedUpdate()
    {
        //Debug.Log(Hero.GetComponent<smert>().Playerheath);
        if (cmoveVector.normalized != Vector2.zero)
        {
            Hero.gameObject.GetComponent<move>().Move(cmoveVector.normalized);
        }
        //visualmodel.gameObject.GetComponent<AnimatorManager>().walking();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            visualmodel.gameObject.GetComponent<AnimatorManager>().Walking();
            rb.drag = 0;

        }
        else
        {
            rb.drag = drift;
            visualmodel.gameObject.GetComponent<AnimatorManager>().Idle();
        }
        
        
        if (Input.GetKey(KeyCode.Space))
        {
            Hero.gameObject.GetComponent<move>().Dash(cmoveVector.normalized);
           
        }


    }

    //private IEnumerator Atackwithdelay( Vector2 Atackdirection)
    //{
    //    if (Atackdirection == Vector2.left)
    //    {
    //        hitboxL.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack(Vector2.left);
    //        yield return new WaitForSeconds(0.1f);
    //        hitboxL.gameObject.GetComponent<Damagedeal>().ProcessHit(Vector2.left);
    //        Atackreload(atacktime);
    //    }
    //    if (Atackdirection == Vector2.right)
    //    {
    //        hitboxR.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack(Vector2.right);
    //        yield return new WaitForSeconds(0.1f);
    //        hitboxR.gameObject.GetComponent<Damagedeal>().ProcessHit(Vector2.right);
    //        Atackreload(atacktime);
    //    }
    //    if (Atackdirection == Vector2.up)
    //    {
    //        hitboxU.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack(Vector2.up);
    //        yield return new WaitForSeconds(0.1f);
    //        hitboxU.gameObject.GetComponent<Damagedeal>().ProcessHit(Vector2.up);
    //        Atackreload(atacktime);
    //    }
    //    if (Atackdirection == Vector2.down)
    //    {
    //        hitboxD.gameObject.GetComponentInChildren<AtackAnimatiomManager>().Atack(Vector2.down);
    //        yield return new WaitForSeconds(0.1f);
    //        hitboxD.gameObject.GetComponent<Damagedeal>().ProcessHit(Vector2.down);
    //        Atackreload(atacktime);
    //    }
    //}
    private IEnumerator Atackwithdelay1( )
    {
        Atackreload(atacktime);
        Aim.gameObject.GetComponentInChildren<SpearAtackNumberV>().AtackSpearVisual();
        yield return new WaitForSeconds(0.1f);
        Aim.gameObject.GetComponentInChildren<SpearAtackNumber>().AtackSpear();
        

    }
    private IEnumerator ShieldAtackwithdelay(Vector2 Atackdirection)
    {
        if (Atackdirection == Vector2.left)
        {

            shieldL.gameObject.GetComponentInChildren<AtackAnimatiomManager>().ShieldAtack(Vector2.left);
            yield return new WaitForSeconds(0.1f);
            shieldL.gameObject.GetComponent<Damagedeal>().ProcessHitShield(Vector2.left);
            ShieldAtackreload(shieldatacktime);
        }
        if (Atackdirection == Vector2.right)
        {
            
            shieldR.gameObject.GetComponentInChildren<AtackAnimatiomManager>().ShieldAtack(Vector2.right);
            yield return new WaitForSeconds(0.1f);
            shieldR.gameObject.GetComponent<Damagedeal>().ProcessHitShield(Vector2.right);
            ShieldAtackreload(shieldatacktime);
        }
    }
        private IEnumerator HealAtackwithdelay()
        {
            HealAtack.gameObject.GetComponentInChildren<AtackAnimatiomManager>().HealAtack();
            yield return new WaitForSeconds(0.21f);
            HealAtack.gameObject.GetComponent<Damagedeal>().ProcessHitlifesteal(Vector2.right, Hero);
            HealdAtackreload(healdatacktime);
        }

    public void UpgradeDMG()
    {
        Aim.GetComponentInChildren<SpearAtackNumber>().UpgradeDamage();
    }
    public void UpgradeHealth()
    {
        Hero.GetComponent<smert>().HP();
        
    }
    public void UpgradeReload()
    {
        atacktime += -0.05f;
        Debug.Log(atacktime);
    }
}

