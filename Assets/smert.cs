using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class smert : MonoBehaviour
{
    [SerializeField] private int playerheath;
    private Rigidbody2D rb;
    private Vector2 otkidVector;
    

    public int Playerheath
    {
        get
        {
            return playerheath;
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
       playerheath -= damageCount ;
        Debug.Log(playerheath);
        if (playerheath <= 0)
        {
            Destroy(gameObject);
        }
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
