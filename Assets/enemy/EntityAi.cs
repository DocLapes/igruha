using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAi : MonoBehaviour
{

    protected bool isstuned;
    protected Rigidbody2D rb;
    protected bool isatack;
    protected bool stuntype2=false;


    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {



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
    public void StunEntity(float stuntime)
    {
        isstuned = true;
        if (stuntime >= 2f)
        {
            stuntype2 = true;
        }
        Invoke(nameof(OutStunEntity), stuntime);
    }
    public void OutStunEntity()
    {
        stuntype2= false;
        isstuned = false;
    }
    
}
