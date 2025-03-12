using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookRotaiting : MonoBehaviour
{
    private GameObject GameObject;
    [SerializeField] private GameObject Book1;
    [SerializeField] private GameObject Book2;
    private float angle;
    private bool isreload;
    private bool isatack;
    void Awake()
    {
        GameObject = gameObject;
        angle = GameObject.transform.eulerAngles.z;
        Atack(5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isreload == false)
        {
            angle += 0.25f;
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
        Book2.gameObject.SetActive(false);
        Invoke(nameof(OutAtackreload), 5f);
    }
    public void OutAtackreload()
    {
        angle = 0;
        GameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        Book2.gameObject.SetActive(true);
        isreload = false;
        Atack(5f);


    }
}
