using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smert : MonoBehaviour
{
    private int CurrentEntityheath;
    [SerializeField] private int MaxHealth;
    [SerializeField] private GameObject AnimatorManager;
    private Rigidbody2D rb;
    private Vector2 otkidVector;
    private int stealedhealth;
   
    

    public float Entityheath
    {
        get
        {
            return (float)CurrentEntityheath/ (float)MaxHealth;
        }
    }

    private bool gameover;
    // Start is called before the first frame update
    void Awake()
    {
        CurrentEntityheath = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        otkidVector = rb.velocity;
        if (CurrentEntityheath > MaxHealth)
        {
            CurrentEntityheath = MaxHealth;
        }
        
    }
    public void takedamage(int damageCount)
    {
        if (AnimatorManager != null)
        {
            AnimatorManager.GetComponent<AnimatorManager>().hit();
        }
        CurrentEntityheath -= damageCount ;
       
        
        if (CurrentEntityheath <= 0)
        {
            Destroy(gameObject);
            
        }
    }
    public void Lifesteal(GameObject entity,float stealpercent)
    {
        stealedhealth = (int)(CurrentEntityheath * stealpercent);
        entity.GetComponent<Smert>().GetHeal(stealedhealth);
    }
    public void GetHeal(int stealedhealth)
    {
        CurrentEntityheath += stealedhealth;
        Debug.Log(stealedhealth);
    }

    public void otkinyt(int power)
    {
        
        rb.AddForce(otkidVector * power * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
    }
    public void otkinytbyatack(Vector2 otkidDirection, int power)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(otkidDirection * power * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
    }
    public void StunEntitySpear(float stuntime)
    {
        rb.GetComponent<SpearEnemyAi>().StunEntity(stuntime);
    }
    
    public void HP()
    {
        MaxHealth += 10;
        CurrentEntityheath += 10;
        Debug.Log(MaxHealth);
    }
   
}
