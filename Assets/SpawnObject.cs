using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject Object;
    [SerializeField] private int damage=25;
    private float scale = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn(Vector2 swpawnpoint)
    {
        
        GameObject obj = Instantiate(Object, swpawnpoint, Quaternion.identity);
        if (obj.GetComponent<Damagedeal>() != null)
        {
            obj.GetComponent<Explosion>().GiveExplosionDamage(damage, scale);
        }
    }
    public void GetUpgradeType1()
    {
        damage += 10;
    }
    public void GetUpgradeType2(int lvl)
    {
        
        scale = scale * 1.25f;
        Debug.Log("scale" + scale);
    }


}
