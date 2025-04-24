using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smert : MonoBehaviour
{
    private float CurrentEntityheath;
    [SerializeField] private int MaxHealth;
    [SerializeField] private GameObject AnimatorManager;
    [SerializeField] private GameObject VolumeDmg;
    private Rigidbody2D rb; 
    private Vector2 otkidVector;
    private int stealedhealth;
    private float regeninsec=0;
    [SerializeField] private bool isWorm=false;
    private bool isStuned=false;




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
        if (gameObject.GetComponent<playermanager>() != null)
        {
            Regeneration();
        }
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
        if (isWorm == false)
        {
            if (gameObject.GetComponent<playermanager>() != null)
            {
                StartCoroutine(ShowDmg());
            }
            if (AnimatorManager != null)
            {
                AnimatorManager.GetComponent<AnimatorManager>().hit();
            }
            CurrentEntityheath -= damageCount;


            if (CurrentEntityheath <= 0)
            {
                Destroy(gameObject);

            }
        }
        if(isWorm == true && isStuned == true) 
        {
            if (AnimatorManager != null)
            {
                AnimatorManager.GetComponent<AnimatorManager>().hit();
            }
            CurrentEntityheath -= damageCount;


            if (CurrentEntityheath <= 0)
            {
                Destroy(gameObject);

            }
        }
    }
    public void Lifesteal(GameObject entity)
    {
        entity.GetComponent<Smert>().GetHeal();
    }
    public void GetHeal()
    {
        CurrentEntityheath += 4;
        Debug.Log(stealedhealth);
    }

    public void otkinyt(int power)
    {
        if (isWorm == false)
        {
            rb.AddForce(otkidVector * power * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
        }
    }
    public void otkinytbyatack(Vector2 otkidDirection, int power)
    {
        if (isWorm == false)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(otkidDirection * power * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
        }
    }
    public void StunEntitySpear(float stuntime)
    {
        rb.GetComponent<SpearEnemyAi>().StunEntity(stuntime);
    }
    
    public void HP()
    {
        MaxHealth += 10;
        CurrentEntityheath += 10;
        regeninsec += 0.2f;
        Debug.Log(MaxHealth);
    }
    public void Regeneration()
    {
        CurrentEntityheath += regeninsec;
        Invoke(nameof(Regeneration),1f);
    }

    public IEnumerator ShowDmg() 
    {
        VolumeDmg.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        VolumeDmg.SetActive(false);

    }
    public void Stun()
    {
        isStuned = !isStuned;
    }
    public int ReturnHeath()
    {
        return MaxHealth;
    }
    public float ReturnRegen()
    {
        return regeninsec;
    }

}
