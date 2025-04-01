using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject Visual;
    private int damage;
    [SerializeField] private float time;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Boom());
        
    }
    public IEnumerator Boom()
    {
        Visual.GetComponent<AnimatorManager>().Explosion();
        gameObject.GetComponentInChildren<Damagedeal>().GetDamag(damage);
        yield return new WaitForSeconds(0.07f);
        gameObject.GetComponentInChildren<Damagedeal>().ProcessHitCircle();
        yield return new WaitForSeconds(time);
        Destroy(gameObject);

    }
    public void GiveExplosionDamage(int dmg, float scale)
    {

        damage = dmg;
        transform.localScale = transform.localScale * scale;
    }

}
