using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BossAI : EntityAi
{
    [SerializeField] private GameObject hitbox;
    //[SerializeField] private GameObject hitbox2;
    private Collider2D cl;
    bool isatacking=false;
    bool isspecatack = false;
    [SerializeField] private GameObject visualmodel;
    [SerializeField] private Transform Player;
    [SerializeField] private int drift;
    private float atacktime = 5f;
    private float atacktimemetod = 20f;
    [SerializeField] public GameObject projectile;
    [SerializeField] public GameObject area;
    [SerializeField] public GameObject flames;
    [SerializeField] public GameObject skull;
    //private bool isatacklight;
    Vector2 Atackpoint;
    enum EnemyState
    {
        Stalk,
        RangeAtack
    }

    private EnemyState enemyState = EnemyState.Stalk;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<CircleCollider2D>();
        //Player = GameManager.instance.Player.transform;
    }

    void FixedUpdate()
    {
        Vector2 targetDir = Player.position - transform.position;
        var heading = Player.position - transform.position;
        float distance = heading.sqrMagnitude;

        if (enemyState == EnemyState.Stalk)
        {
            visualmodel.gameObject.GetComponent<AnimatorManager>().Walking();
            if (isstuned == true)
            {
                rb.drag = drift;
            }
            if (rb.velocity != Vector2.zero && isstuned == false)
            {
                rb.drag = 0;
            }
            if (isspecatack == false & distance <= 10f & isatacking==false)
            {
                StartCoroutine(MeleeAtackSpecial());
            }
            if (isatack == false & distance <= 30f)
            {
                StartCoroutine(Atackwithdelay(targetDir)); 
            }
            if (isatacking == false & isatacking == false)
            {
                rb.gameObject.GetComponent<move>().Move(targetDir);
            }

            if (distance >= 100.0f) ChangeState2();
            

        }
        if (enemyState == EnemyState.RangeAtack)
        {
            visualmodel.gameObject.GetComponent<AnimatorManager>().Walking();
            if (isstuned == true)
            {
                rb.drag = drift;
            }
            if (rb.velocity != Vector2.zero && isstuned == false)
            {
                rb.drag = 0;
            }
            if (isspecatack == false & isatacking == false)
            {
                StartCoroutine(RangeAtackSpecial());
            }
            if (isatacking == false)
            {
                rb.gameObject.GetComponent<move>().Move(targetDir);
            }
            if (isatack == false & isatacking == false)
            {
                StartCoroutine(RangeAtackwithdelay(targetDir));
            }
            
            if (distance <= 90.0f) ChangeState3();
        }
        

    }
    private void ChangeState2()
    {
        atacktime = 3f;
        atacktimemetod = 10f;
        gameObject.GetComponent<move>().GetSpeed(1f);
        enemyState = EnemyState.RangeAtack;
    }
    private void ChangeState3()
    {
        atacktime = 5f;
        atacktimemetod = 20f;
        gameObject.GetComponent<move>().GetSpeed(0.5f);
        enemyState = EnemyState.Stalk;
    }
    private void SpecAtackReload()
    {
        isspecatack = true;
        Invoke(nameof(outSpecAtackReload), atacktimemetod);
    }
    private void outSpecAtackReload()
    {
        isspecatack = false;
    }

    private IEnumerator RangeAtackwithdelay(Vector2 TargetDirection)
    {
        Debug.Log("атака");
        Atackreload(atacktime);
        isatacking = true;
        rb.velocity = Vector2.zero;
        visualmodel.gameObject.GetComponentInChildren<AnimatorManager>().Atack();
        yield return new WaitForSeconds(0.28f);

        GameObject clone;
        GameObject clone2;
        GameObject clone3;
        clone = Instantiate(projectile, transform.position, Quaternion.identity);
        clone.GetComponent<Projectile>().GetDir(TargetDirection);
        clone2 = Instantiate(projectile, transform.position, Quaternion.identity);
        clone2.GetComponent<Projectile>().GetDir(TargetDirection + new Vector2(1f, 1f));
        clone3 = Instantiate(projectile, transform.position, Quaternion.identity);
        clone3.GetComponent<Projectile>().GetDir(TargetDirection + new Vector2(-1f, -1f));


        yield return new WaitForSeconds(0.14f);
        isatacking = false;
    }
    private IEnumerator Atackwithdelay(Vector2 TargetDirection)
    {
        Atackreload(atacktime);
        rb.velocity = Vector2.zero;
        isatacking = true;
        visualmodel.gameObject.GetComponent<AnimatorManager>().Atack();
        yield return new WaitForSeconds(0.5f);

        GameObject clone;
        GameObject clone2;
        GameObject clone3;
        clone = Instantiate(area, Player.transform.position, Quaternion.identity);
        clone.GetComponent<ExplosionEnemy>().GiveExplosionDamage(25, 1);
        clone2 = Instantiate(area, Player.transform.position + new Vector3(Random.Range(1f, 5f), Random.Range(1f, 5f), 0), Quaternion.identity);
        clone2.GetComponent<ExplosionEnemy>().GiveExplosionDamage(25, 1);
        clone3 = Instantiate(area, Player.transform.position + new Vector3(Random.Range(1f, 5f), Random.Range(1f, 5f), 0), Quaternion.identity);
        clone3.GetComponent<ExplosionEnemy>().GiveExplosionDamage(25, 1);

        yield return new WaitForSeconds(0.4f);
        isatacking = false;
    }
    private IEnumerator MeleeAtackSpecial()
    {
        isatacking = true;
        rb.velocity = Vector2.zero;
        visualmodel.gameObject.GetComponent<AnimatorManager>().Atack();
        yield return new WaitForSeconds(0.5f);
        flames.GetComponent<RuningFlames>().Atack();
        SpecAtackReload();
        yield return new WaitForSeconds(0.4f);
        isatacking = false;
    }
    private IEnumerator RangeAtackSpecial()
    {
        isatacking = true;
        rb.velocity = Vector2.zero;
        visualmodel.gameObject.GetComponent<AnimatorManager>().Atack();
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 2; i++)
        {
            Vector2 swpawnpoint = transform.position + new Vector3(Random.Range(3f, 6f), Random.Range(3f, 6f), 0);
            GameObject enemy = Instantiate(skull, swpawnpoint, Quaternion.identity);
        }
        SpecAtackReload();
        yield return new WaitForSeconds(0.4f);
        isatacking = false;
    }
}
