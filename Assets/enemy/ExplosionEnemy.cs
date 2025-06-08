using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Visual;
    private int damage;
    [SerializeField] private float time1;
    [SerializeField] private float time2;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Boom());
        
    }
    public IEnumerator Boom()
    {
        Visual.GetComponent<AnimatorManager>().Explosion();
        yield return new WaitForSeconds(time1);
        gameObject.GetComponentInChildren<DamagedealEnemy>().ProcessHitCircle();
        yield return new WaitForSeconds(time2);
        Destroy(gameObject);

    }
    public void GiveExplosionDamage(int dmg, float scale)
    {

        damage = dmg;
        transform.localScale = transform.localScale * scale;
    }

}
