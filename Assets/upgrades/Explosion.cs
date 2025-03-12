using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private GameObject ThisGameObj;
    // Start is called before the first frame update
    void Awake()
    {
        ThisGameObj= gameObject;
        StartCoroutine(Boom());
        
    }
    public IEnumerator Boom()
    {
        //gameObject.GetComponentInChildren<AtackAnimatiomManager>().();
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponentInChildren<Damagedeal>().ProcessHitCircle();
        yield return new WaitForSeconds(0.1f);
        Destroy(ThisGameObj);

    }
    
}
