using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;
using static UnityEngine.Rendering.DebugUI;

public class SkullEnemyAI : EntityAi
{
    
    private Transform Player;
    [SerializeField] private GameObject visualmodel;
    [SerializeField] private int drift;
    private float atacktime = 0.3f;
    enum EnemyState
    {
        Stalk,
        Atack,
        AtackPrepare,
        Explosion
    }
    private EnemyState enemyState = EnemyState.Stalk;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (enemyState == EnemyState.Stalk)
        {
            
            visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyWalking();
            //var direction = heading / distance;
            if (isstuned == true)
            {
                rb.drag = drift;
            }
            else { rb.gameObject.GetComponent<move>().Move(targetDir); }

            if (rb.velocity != Vector2.zero && isstuned == false)
            {

                rb.drag = 0;

                if (distance <= 20.0f)
                {
                    ChangeState();
                }

            }
            
        }
        if (enemyState == EnemyState.Atack)
        {

            visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyAtackWalking();
            if (isstuned == true)
            {
                rb.drag = drift;
            }
            else { rb.gameObject.GetComponent<move>().Move(targetDir); }

            if (rb.velocity != Vector2.zero && isstuned == false)
            {

                rb.drag = 0;

                if (distance <= 1.0f)
                {

                    StartCoroutine(DestroyNow());
                    enemyState = EnemyState.Explosion;
                }


            }
        }
        if (enemyState == EnemyState.AtackPrepare)
        {
            rb.drag = drift;
        }
        if (enemyState == EnemyState.Explosion)
        {
            rb.drag = drift;
        }
    }
    private IEnumerator Prepare()
    {
        rb.velocity = Vector2.zero;
        visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyGetReady();
        yield return new WaitForSeconds(0.4f);
        ChangeState2();
    }
    private void ChangeState()
    {
        enemyState = EnemyState.AtackPrepare;
        StartCoroutine(Prepare());

    }
    private void ChangeState2()
    {
        enemyState = EnemyState.Atack;
        Invoke(nameof(DestroyThen), 4f);

    }
    public IEnumerator DestroyNow()
    {
        visualmodel.gameObject.GetComponent<AnimatorManager>().death();
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
    public void DestroyThen()
    {
        StartCoroutine(DestroyNow());
    }
    public void OnDestroy()
    {
        
        if (Player != null) {
            rb.gameObject.GetComponent<SpawnObject>().Spawn(rb.transform.position);
            Player.GetComponentInChildren<SpawnEnemy>().MinusEnemy(); 

        }
        
    }
    //if (rb.velocity != Vector2.zero && distance <= 5.0f && isatack == false)
    //{
    //    visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyAtackWalking();
    //    rb.drag = 0;
    //    hitbox.gameObject.GetComponent<DamagedealEnemy>().ProcessHit(targetDir);

    //    Atackreload(atacktime);
    //}




    //public void Atack(Vector2 direction)
    //{
    //    hitbox.gameObject.GetComponent<Damagedeal>().ProcessHit(direction);
    //    Atackreload(atacktime);
    //}

}
