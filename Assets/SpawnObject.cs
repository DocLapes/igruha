using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject Object;
    private int damage=25;

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
            obj.GetComponentInChildren<Damagedeal>().GetDamag(damage);
        }
    }
    public void GetUpgradeType1()
    {
        damage += 10;
    }
    public void GetUpgradeType2(int lvl)
    {
        
    }


}
