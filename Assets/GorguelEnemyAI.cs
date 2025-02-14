using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;
using static UnityEngine.Rendering.DebugUI;

public class GorguelEnemyAI : EntityAi
{
    [SerializeField] private Transform Player;
    private Transform Player1;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject visualmodel;
    [SerializeField] private int drift;
    private Collider2D cl;
    
    enum EnemyState
    {
        Stalk,
        Atack,
        AtackOut
    }
    private EnemyState enemyState = EnemyState.Stalk;
    private float atacktime = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //Player = GameManager.instance.Player.transform;
        cl = GetComponent<CircleCollider2D>();
        cl.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rb.GetComponent<smert>().Entityheath);
        Vector2 targetDir = Player.position - transform.position;
        var heading = Player.position - transform.position;
        float distance = heading.sqrMagnitude;
        //SpriteRenderer sprite = hitbox.gameObject.GetComponent<SpriteRenderer>();

        //var direction = heading / distance;
        if (enemyState == EnemyState.Stalk)
        {
            rb.drag = 0;
            rb.mass = 1;
            if (distance > 1.0f )
            {
                rb.gameObject.GetComponent<move>().Move(targetDir);
                
                visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyWalking();
            }
            if (distance <= 1.0f )
            {
                visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyWalking();
                rb.gameObject.GetComponent<move>().Move(targetDir);
                if (isatack == false)
                {
                    StartCoroutine(Atack(targetDir));
                }

            }
        }
        if (enemyState == EnemyState.AtackOut)
        {
            rb.mass = 100;
            StartCoroutine(AtackOutM());
        }
        //if (rb.velocity != Vector2.zero && distance <= 5.0f && isatack == false)
        //{
        //    visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyAtackWalking();
        //    rb.drag = 0;
        //    hitbox.gameObject.GetComponent<DamagedealEnemy>().ProcessHit(targetDir);

            //    Atackreload(atacktime);
            //}



    }
    private IEnumerator AtackOutM()
    {
        Atackreload(atacktime);
        rb.velocity = Vector2.zero;
        
        visualmodel.gameObject.GetComponent<AnimatorManager>().AtackOut();
        yield return new WaitForSeconds(0.5f);
        cl.enabled = false;
        yield return new WaitForSeconds(0.4f);
        ChangeState3();


    }
    private IEnumerator Atack(Vector2 dir)
    {
        enemyState = EnemyState.Atack;
        rb.velocity = Vector2.zero;
        visualmodel.gameObject.GetComponent<AnimatorManager>().Atack();
        yield return new WaitForSeconds(0.35f);
        hitbox.gameObject.GetComponent<DamagedealEnemy>().ProcessHit(dir);
        cl.enabled = true;
        ChangeState2();
    }
    private void ChangeState2()
    {
        enemyState = EnemyState.AtackOut;


    }
    private void ChangeState3()
    {
        enemyState = EnemyState.Stalk;
    }

    private void ChangeState1(float atacktimemetod)
    {
        if (enemyState == EnemyState.Atack)
        {
            Invoke(nameof(ChangeState2), atacktimemetod);
        }
        if (enemyState == EnemyState.AtackOut)
        {
            Invoke(nameof(ChangeState3), atacktimemetod);
        }
    }
}
