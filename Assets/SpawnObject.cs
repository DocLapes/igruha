using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject Object;
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
        GameObject enemy = Instantiate(Object, swpawnpoint, Quaternion.identity);
    }
    

}
