using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;
using static UnityEngine.Rendering.DebugUI;

public class SpearEnemyAi : MonoBehaviour
{
    // Start is called before the first frame update

    bool isstuned;
    private Transform Player1;
    [SerializeField] private GameObject hitbox;
    private Rigidbody2D rb;
    private Collider2D cl;
    [SerializeField] private GameObject visualmodel;
    [SerializeField] private Transform Player;
    [SerializeField] private int drift;
    private bool isatack;
    private bool havedirection;
    private float atacktime = 5f;
    private float atacktimemetod = 1f;
    Vector2 Atackpoint;
    enum EnemyState
    {
        Stalk,
        Atack,
        AtackOut
    }
    private EnemyState enemyState = EnemyState.Stalk;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<CircleCollider2D>();
        //Player = GameManager.instance.Player.transform;
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
        if(enemyState == EnemyState.Stalk)
        {
            Debug.Log(enemyState);
            
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

                //if (distance <= 5.0f)
                //{
                //    visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyAtackWalking();
                //    if (isatack == false)
                //    {
                //        hitbox.gameObject.GetComponent<DamagedealEnemy>().ProcessHit(targetDir);
                //        Atackreload(atacktime);
                //    }

                //}
            }
            if (isstuned == false) rb.gameObject.GetComponent<move>().Move(targetDir);

            Atackpoint = targetDir;
            
            if (distance <= 50.0f && isatack== false) enemyState = EnemyState.Atack;



        }
        if (enemyState == EnemyState.Atack)
        {
            
            cl.enabled = false;
            visualmodel.gameObject.GetComponent<AnimatorManager>().Atack();
            //Vector2.MoveTowards(transform.position, Atackpoint, 25f);
            rb.gameObject.GetComponent<move>().MoveAtack(Atackpoint);
            hitbox.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            
            Debug.Log(enemyState);
            //Debug.Log(Vector2.Distance(Atackpoint, (Vector2)transform.position));
            Atackreload(atacktime);
            ChangeState1(atacktimemetod);

            //if (Atackpoint.x == transform.position.x & Atackpoint.y == transform.position.y) enemyState = EnemyState.Stalk;

        }
        if (enemyState == EnemyState.AtackOut)
        {
            //StartCoroutine(AtackOutM());
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
    //private IEnumerator AtackOutM()
    //{
    //    hitbox.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    //    visualmodel.gameObject.GetComponent<AnimatorManager>().AtackOut();
    //    yield return new WaitForSeconds(0.1f);
    //    Atackreload(atacktime);
    //}
    public void Atackreload(float atacktime)
    {
        isatack = true;
        Invoke(nameof(OutAtackreload), atacktime);
    }
    public void OutAtackreload()
    {
        isatack = false;
    }
    public void ChangeState2()
    {
        enemyState = EnemyState.Stalk;
        cl.enabled = true;
        hitbox.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ChangeState1(float atacktimemetod)
    {
        Invoke(nameof(ChangeState2), atacktimemetod);
    }
    public void StunEntity(float stuntime)
    {

        isstuned = true;
        Invoke(nameof(OutStunEntity), stuntime);
    }
    public void OutStunEntity()
    {
        isstuned = false;
    }
}
