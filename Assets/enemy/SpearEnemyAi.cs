using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;
using static UnityEngine.Rendering.DebugUI;

public class SpearEnemyAi : EntityAi
{
    // Start is called before the first frame update

    
    
    [SerializeField] private GameObject hitbox;
    private Collider2D cl;
    [SerializeField] private GameObject visualmodel;
    private Transform Player;
    [SerializeField] private int drift;
    private bool havedirection;
    private float atacktime = 5f;
    private float atacktimemetod = 1f;
    Vector2 Atackpoint;
    enum EnemyState
    {
        Stalk,
        Atack,
        AtackPrepare,
        AtackOut
    }
    private EnemyState enemyState = EnemyState.Stalk;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<CircleCollider2D>();
        Player = GameManager.instance.Player.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rb.GetComponent<smert>().Entityheath);
        Vector2 targetDir = Player.position - transform.position;
        var heading = Player.position - transform.position;
        float distance = heading.sqrMagnitude;
        //SpriteRenderer sprite = hitbox.gameObject.GetComponent<SpriteRenderer>();
        //Debug.Log(rb.GetComponent<smert>().Entityheath);
        //var direction = heading / distance;
        if (enemyState == EnemyState.Stalk)
        {
            //Debug.Log(enemyState);
            
            if (isstuned == true)
            {
                visualmodel.gameObject.GetComponent<AnimatorManager>().Idle();
                rb.drag = drift;

            }
            //else { rb.gameObject.GetComponent<move>().Move(targetDir); }

            if (rb.velocity != Vector2.zero && isstuned == false)
            {
                rb.drag = 0;
                visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyWalking();

            }
            if (isstuned == false) rb.gameObject.GetComponent<move>().Move(targetDir);

            Atackpoint = targetDir;
            
            if (distance <= 50.0f && isatack== false) enemyState = EnemyState.AtackPrepare;



        }
        if (enemyState == EnemyState.Atack)
        {
            
            cl.enabled = false;
            visualmodel.gameObject.GetComponent<AnimatorManager>().Atack();
            //Vector2.MoveTowards(transform.position, Atackpoint, 25f);
            rb.gameObject.GetComponent<move>().MoveAtack(Atackpoint);
            hitbox.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            
            
            //Debug.Log(Vector2.Distance(Atackpoint, (Vector2)transform.position));
            
            ChangeState1(atacktimemetod);

            //if (Atackpoint.x == transform.position.x & Atackpoint.y == transform.position.y) enemyState = EnemyState.Stalk;

        }
        if (enemyState == EnemyState.AtackOut)
        {
            StartCoroutine(AtackOutM());
        }
        if (enemyState == EnemyState.AtackPrepare)
        {
            Atackpoint = targetDir;
            StartCoroutine(AtackPrepare());

        }
    }

    //private IEnumerator Atack(Vector2 direction)
    //{
    //    visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyGetReady();

    //    yield return new WaitForSeconds(0.1f);
    //    visualmodel.gameObject.GetComponent<AnimatorManager>().Atack();
    //    hitbox.gameObject.GetComponent<BoxCollider2D>().enabled = true;

    //    Invoke(nameof(AtackOut), atacktimemetod);
    //}
    private IEnumerator AtackOutM()
    {
        rb.velocity = Vector2.zero;
        cl.enabled = true;
        hitbox.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        visualmodel.gameObject.GetComponent<AnimatorManager>().AtackOut();
        Atackreload(atacktime);
        yield return new WaitForSeconds(0.6f);
        ChangeState1(0f);

    }
    private IEnumerator AtackPrepare()
    {
        visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyGetReady();
        yield return new WaitForSeconds(0.49f);
        ChangeState4();
    }
    private void ChangeState2()
    {
        enemyState = EnemyState.AtackOut;
        
        
    }
    private void ChangeState3()
    {
        enemyState = EnemyState.Stalk;
    }
    private void ChangeState4()
    {
        enemyState = EnemyState.Atack;
    }

    private void ChangeState1(float atacktimemetod)
    {
        if (enemyState== EnemyState.Atack)
        {
            Invoke(nameof(ChangeState2), atacktimemetod);
        }
        if (enemyState == EnemyState.AtackOut)
        {
            Invoke(nameof(ChangeState3), atacktimemetod);
        }
    }
   
}
