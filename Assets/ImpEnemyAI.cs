using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;
using static UnityEngine.Rendering.DebugUI;

public class ImpEnemyAI : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject hitbox;
    private Rigidbody2D rb;
    [SerializeField] private GameObject visualmodel;
    [SerializeField] private int drift;
    private bool isatack;
    private float atacktime = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetDir = Player.position - transform.position;
        var heading = Player.position - transform.position;
        float distance = heading.sqrMagnitude;
        //SpriteRenderer sprite = hitbox.gameObject.GetComponent<SpriteRenderer>();
        rb.gameObject.GetComponent<move>().Move(targetDir);
        //var direction = heading / distance;
        if (rb.velocity != Vector2.zero && distance  > 5.0f)
        {
            visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyWalking();
            rb.drag = 0;
            
        }
        if (rb.velocity != Vector2.zero && distance <= 5.0f && isatack == false)
        {
            visualmodel.gameObject.GetComponent<AnimatorManager>().EnemyAtackWalking();
            rb.drag = 0;
            hitbox.gameObject.GetComponent<Damagedeal>().ProcessHit(targetDir);
            
            Atackreload(atacktime);
        }
        if (rb.velocity == Vector2.zero)
        {
            Debug.Log("idle" + distance);
            rb.drag = drift;
            visualmodel.gameObject.GetComponent<AnimatorManager>().Idle();
        }
       
    }
    public void Atack(Vector2 direction)
    {
        hitbox.gameObject.GetComponent<Damagedeal>().ProcessHit(direction);
        Atackreload(atacktime);
    }
    public void Atackreload(float atacktimemetod)
    {
        isatack = true;
        Invoke(nameof(OutAtackreload), atacktimemetod);
    }
    public void OutAtackreload()
    {
        isatack = false;
    }
}
