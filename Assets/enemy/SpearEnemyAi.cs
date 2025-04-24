using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;
using static UnityEngine.Rendering.DebugUI;

public class SpearEnemyAi : EntityAi
{
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject hitbox2;
    private Collider2D cl;
    [SerializeField] private GameObject visualmodel;
    private Transform Player;
    [SerializeField] private int drift;
    private bool havedirection;
    private float atacktime = 5f;
    [SerializeField] private float atacktimemetod = 0.6f;
    [SerializeField] private float LAreloadTime = 0.4f;
    private bool isatacklight;
    Vector2 Atackpoint;
    enum EnemyState
    {
        Stalk,
        Atack,
        AtackPrepare,
        AtackOut
    }

    private EnemyState enemyState = EnemyState.Stalk;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<CircleCollider2D>();
        Player = GameManager.instance.Player.transform;
    }

    void FixedUpdate()
    {
        Vector2 targetDir = Player.position - transform.position;
        var heading = Player.position - transform.position;
        float distance = heading.sqrMagnitude;
       
        if (enemyState == EnemyState.Stalk)
        {
            if (isstuned == true)
            {
                visualmodel.gameObject.GetComponent<AnimatorManager>().Idle();
                rb.drag = drift;

            }

            if (rb.velocity != Vector2.zero && isstuned == false)
            {
                rb.drag = 0;
                visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyWalking();

            }
            if (isstuned == false) rb.gameObject.GetComponent<move>().Move(targetDir);

            Atackpoint = targetDir;
            
            if (distance <= 50.0f && distance > 15.0f && isatack== false) enemyState = EnemyState.AtackPrepare;
            if (distance <= 4.0f && isatack == true)
            {
                if (isatacklight == false)
                {
                    hitbox2.gameObject.GetComponent<DamagedealEnemy>().ProcessHit(targetDir);
                    Debug.Log("smallatack");
                    LightAtackreload(LAreloadTime);
                }

            }

        }
        if (enemyState == EnemyState.Atack)
        {
            
            cl.enabled = false;
            visualmodel.gameObject.GetComponent<AnimatorManager>().Atack();
            rb.gameObject.GetComponent<move>().MoveAtack(Atackpoint);
            hitbox.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            ChangeState1(atacktimemetod);
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
        yield return new WaitForSeconds(0.7f);
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
    public void LightAtackreload(float atacktimemetod)
    {
        isatacklight = true;
        Invoke(nameof(LightOutAtackreload), atacktimemetod);
    }
    public void LightOutAtackreload()
    {
        isatacklight = false;
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
    public void OnDestroy()
    {
        if (Player != null)
        {
            rb.gameObject.GetComponent<SpawnObject>().Spawn(rb.transform.position);
            Player.GetComponentInChildren<SpawnEnemy>().MinusSpearEnemy();
        }
    }
}
