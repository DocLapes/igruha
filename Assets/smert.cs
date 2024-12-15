using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class smert : MonoBehaviour
{
    [SerializeField] private int entityheath;
    private Rigidbody2D rb;
    private Vector2 otkidVector;
    private int stealedhealth;

    public int Entityheath
    {
        get
        {
            return entityheath;
        }
    }

    private bool gameover;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        otkidVector = rb.velocity;
        if (gameover)
        {
            SceneManager.LoadScene("level");
        }
        
    }
    public void takedamage(int damageCount)
    {
       entityheath -= damageCount ;
        
        if (entityheath <= 0)
        {
            Destroy(gameObject);
            
        }
    }
    public void Lifesteal(GameObject entity,float stealpercent)
    {
        stealedhealth = (int)(entityheath * stealpercent);
        entity.GetComponent<smert>().GetHeal(stealedhealth);
    }
    public void GetHeal(int stealedhealth)
    {
        entityheath += stealedhealth;
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
}
