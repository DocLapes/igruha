using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuningFlames : MonoBehaviour
{
    private GameObject GameObject;
    [SerializeField] private GameObject Flame;
    private float angle;
    private int damage = 10;
    private bool isreload;
    public bool isplayernear;
    void Awake()
    {
        
        GameObject = gameObject;
        angle = GameObject.transform.eulerAngles.z;
        //Atack(reloadtime);
    }

    // Update is called once per frame
    void Update()
    {

        if (isreload == false )
        {
            angle += 100f * Time.deltaTime;
            GameObject.transform.eulerAngles = new Vector3(0, 0, angle);
           
        }
    }
    
    public void Atack( )
    {
        angle = 0;
        GameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        Flame.gameObject.SetActive(true);
        Invoke(nameof(Atackreload), 10f);
    }
    public void Atackreload()
    {
        isreload = true;
        isplayernear = false;
        Flame.gameObject.SetActive(false);
        Invoke(nameof(OutAtackreload), 10f);
    }
    public void OutAtackreload()
    {
        isreload = false;
    }
}
