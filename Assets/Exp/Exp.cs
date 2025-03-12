using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    GameObject Obj;
   
    // Start is called before the first frame update
    void Awake()
    {
        
        Obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<ExpCollector>() != null)
        {

            ExpCollector.TookExp();
            
            Destroy(Obj);
        }
        
    }
}
