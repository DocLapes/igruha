using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class RangeEnemyAi : EntityAi
{
    // Start is called before the first frame update
    [SerializeField] private GameObject hitbox;
    private Collider2D cl;
    [SerializeField] private GameObject visualmodel;
    [SerializeField] private Transform Player;
    bool isatacking;
    bool nodash;
    [SerializeField] private int drift;
    private bool havedirection;
    private float atacktime = 5f;
    private float atacktimemetod = 1f;
    Vector2 Atackpoint;
    [SerializeField] public GameObject projectile;
    enum EnemyState
    {
        Stalk,
        Atack,
        Retreat
        
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
        Vector2 circle = Random.onUnitSphere;
        circle = circle.normalized;
        Vector2 TeleportPoint = (circle * 10) + (Vector2)Player.position;

        if (Input.GetKey(KeyCode.Space) && nodash==false) {
            Teleport(TeleportPoint);
        }
            

        if (enemyState == EnemyState.Stalk)
        {
            //Debug.Log(enemyState);

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
            if (isstuned == false) {
                rb.gameObject.GetComponent<move>().Move(targetDir);
                if (distance <= 80.0f) ChangeState4();
            }
           
            
        }
        if (enemyState == EnemyState.Atack)
        {
            if (isstuned == true)
            {
                visualmodel.gameObject.GetComponent<AnimatorManager>().Idle();
                rb.drag = drift;

            }
            if (isstuned == false)
            {
                rb.drag = 20;
                if (isatack == false)
                {
                    StartCoroutine(Atackwithdelay(targetDir));
                }
                if (isatack == true && isatacking == false)
                {
                    visualmodel.gameObject.GetComponent<AnimatorManager>().Idle();

                    if (distance < 30.0f) ChangeState2();
                }
            }
        }
        if (enemyState == EnemyState.Retreat)
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

            if (isstuned == false) {
                rb.gameObject.GetComponent<move>().Move(targetDir); rb.gameObject.GetComponent<move>().Move(rb.transform.position - Player.position);
                if (distance >= 90.0f) ChangeState3();
            }
            
        }
    }
  
   
    private void ChangeState2()
    {
        enemyState = EnemyState.Retreat;


    }
    private void ChangeState3()
    {
        enemyState = EnemyState.Stalk;
    }
    private void ChangeState4()
    {
        enemyState = EnemyState.Atack;
    }
    private IEnumerator Atackwithdelay(Vector2 TargetDirection)
    {
        Atackreload(atacktime);
        isatacking = true;
        visualmodel.gameObject.GetComponentInChildren<AnimatorManager>().Atack();
        yield return new WaitForSeconds(0.28f);
  
        GameObject clone;
        clone = Instantiate(projectile, transform.position, Quaternion.identity);

        clone.GetComponent<Projectile>().GetDir(TargetDirection);
        
        yield return new WaitForSeconds(0.14f);
        isatacking = false;

    }
    private void Teleport(Vector2 Point)
    {
        rb.MovePosition(Point);
        DashKD(3);
    }
    public void DashKD(float stuntime)
    {

        nodash = true;
        Invoke(nameof(DashKDEnd), stuntime);
    }
    public void DashKDEnd()
    {
        nodash = false;
    }
    public void OnDestroy()
    {
        if (Player != null)
        {
            rb.gameObject.GetComponent<SpawnObject>().Spawn(rb.transform.position);
            Player.GetComponentInChildren<SpawnEnemy>().MinusEnemy();

        }
    }

}
