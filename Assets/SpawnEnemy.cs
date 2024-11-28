using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] float spawnRate;
    [SerializeField] float timeBetweenWaves ;
    [SerializeField] private Transform Player;
    private int enemy_count=4;
    [SerializeField] public GameObject impenemy;
    private bool waveisdone;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemyspawn());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator Enemyspawn( )
    {
        
        
        for (int i = 0; i < enemy_count; i++)
        {
            Vector2 circle = Random.onUnitSphere;
            circle = circle.normalized;
            Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
            GameObject enemy = Instantiate(impenemy, swpawnpoint, Quaternion.identity);
            
        }
        Debug.Log(enemy_count);
       
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(Enemyspawn());
    }
}
