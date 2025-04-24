using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;
using static UnityEngine.Rendering.DebugUI;

public class Worm : EntityAi
{
    // Start is called before the first frame update
    [SerializeField] private GameObject hitbox;
    //[SerializeField] private GameObject Smertnost;
    private Collider2D cl;
    [SerializeField] private GameObject visualmodel;
    private Transform Player;
    [SerializeField] private int drift;
    private float atacktime = 5f;
    private Vector2 currenttargetdir = Vector2.one;
    [SerializeField] private Smert Smertnost;
    enum EnemyState
    {
        Stalk,
        Stun,
        StunOut
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
        if (enemyState == EnemyState.Stalk)
        {
            if (isstuned == true && stuntype2 == true)
            {
                Smertnost.Stun();
                StartCoroutine(Stun());

            }

            if (distance > 30f)
            {
               currenttargetdir = targetDir;
            }
           
            //else { rb.gameObject.GetComponent<move>().Move(targetDir); }
            visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyWalking();
            rb.gameObject.GetComponent<move>().Move2(currenttargetdir);
            //Smertnost.enabled = false;
            hitbox.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        }
        if (enemyState == EnemyState.Stun)
        {
            visualmodel.gameObject.GetComponent<AnimatorManager>().Idle();
        }
        if (enemyState == EnemyState.StunOut)
        {
            
        }
    }


    private IEnumerator StunOutC()
    {
        ChangeState2();
        rb.velocity = Vector2.zero;
        Smertnost.enabled = false;
        visualmodel.gameObject.GetComponent<AnimatorManager>().Stunout();
        yield return new WaitForSeconds(0.55f);
        rb.mass = 25f;
        rb.drag = 0;
        Smertnost.Stun();
        ChangeState3();

    }
    private IEnumerator Stun()
    {
        ChangeState4();
        rb.velocity = Vector2.zero;
        rb.mass = 100f;
        rb.drag = 50f;
        Smertnost.enabled = true;
        hitbox.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(3f);
        StartCoroutine(StunOutC());
    }
    private void ChangeState2()
    {
        enemyState = EnemyState.StunOut;
    }
    private void ChangeState3()
    {
        enemyState = EnemyState.Stalk;
    }
    private void ChangeState4()
    {
        enemyState = EnemyState.Stun;
    }
    public void OnDestroy()
    {
        if (Player != null)
        {
            rb.gameObject.GetComponent<SpawnObject>().Spawn(rb.transform.position);
            Player.GetComponentInChildren<SpawnEnemy>().MinusWorm();

        }
    }
}
