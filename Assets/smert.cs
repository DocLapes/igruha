using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class smert : MonoBehaviour
{
    [SerializeField] private int playerheath;
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
        
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
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
}
