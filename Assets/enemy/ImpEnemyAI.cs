using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;
using static UnityEngine.Rendering.DebugUI;

public class ImpEnemyAI : EntityAi
{
    
    private Transform Player;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject visualmodel;
    [SerializeField] private int drift;
   
    private float atacktime = 0.3f;
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

        //var direction = heading / distance;
        if (isstuned == true)
        {
            visualmodel.gameObject.GetComponent<AnimatorManager>().Idle();
            rb.drag = drift;

        }
        else { rb.gameObject.GetComponent<move>().Move(targetDir); }

        if (rb.velocity != Vector2.zero && isstuned == false)
        {

            rb.drag = 0;
            if (distance > 5.0f) { visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyWalking(); }

            if (distance <= 5.0f)
            {
                visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyWalking();
                if (isatack == false)
                {
                    hitbox.gameObject.GetComponent<DamagedealEnemy>().ProcessHit(targetDir);
                    Atackreload(atacktime);
                }

            }


        }




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
