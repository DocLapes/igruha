using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookRotaiting : MonoBehaviour
{
    private GameObject GameObject;
    [SerializeField] private GameObject Book1;
    [SerializeField] private GameObject Book2;
    [SerializeField] private GameObject Book3;
    private GameObject aktiveBook;
    private float angle;
    private int damage = 10;
    private bool isreload;
    private bool isatack;
    private float reloadtime = 7f;
    void Awake()
    {
        aktiveBook = Book1;
        GameObject = gameObject;
        angle = GameObject.transform.eulerAngles.z;
        //Atack(reloadtime);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isreload == false)
        {
            angle += 100f*Time.deltaTime;
            GameObject.transform.eulerAngles = new Vector3(0, 0, angle);
            
        }
    }
    public void Atack(float atacktimemetod)
    {     
        Invoke(nameof(Atackreload), atacktimemetod);
    }
    public void Atackreload()
    {
        isreload = true;
        aktiveBook.gameObject.SetActive(false);
        Invoke(nameof(OutAtackreload), 5f);
    }
    public void OutAtackreload()
    {
        angle = 0;
        GameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        aktiveBook.gameObject.SetActive(true);
        isreload = false;
        Atack(5f);

    }
    public void GetUpgradeType1()
    {
        Atack(reloadtime);
        damage += 3;
        reloadtime += -0.25f;
        aktiveBook.GetComponent<BooksList>().GiveStats(damage);
    }
    public void GetUpgradeType2(int lvl)
    {
        if (lvl == 2)
        {
            Book1.gameObject.SetActive(false);
            Book2.gameObject.SetActive(true);
            aktiveBook = Book2;
            Book2.GetComponent<BooksList>().GiveStats(damage);
        }
        if (lvl == 4)
        {
           
            Book2.gameObject.SetActive(false);
            Book3.gameObject.SetActive(true);
            aktiveBook = Book3;
            Book3.GetComponent<BooksList>().GiveStats(damage);
        }
    }
}
