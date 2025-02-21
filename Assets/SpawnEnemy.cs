using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] float spawnRate;
    float timeBetweenWaves = 5;
    [SerializeField] private Transform Player;
    private int enemy_count=2;
    [SerializeField] public GameObject impenemy;
    [SerializeField] public GameObject spearskeleton;
    [SerializeField] public GameObject gorguel;
    int dificulty = 0;
    float time;
    int t =0;
    int spearskeleton_count;
    int gorguel_count=1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemyspawn());
        //StartCoroutine(EnemyspawnGorgoel());
        StartCoroutine(EnemyspawnSkelet());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        if ( t < minutes )
        {
            t = minutes;
            dificulty++;
            enemy_count += 2;
            Debug.Log(dificulty);
            return;
        }

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
    private IEnumerator EnemyspawnSkelet()
    {
        if (dificulty == 0)
        {
            spearskeleton_count = Random.Range(1, 2);
            for (int i = 0; i < spearskeleton_count; i++)
            {
                Vector2 circle = Random.onUnitSphere;
                circle = circle.normalized;
                Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                GameObject enemy = Instantiate(spearskeleton, swpawnpoint, Quaternion.identity);

            }
            Debug.Log(enemy_count);

            
        }
        yield return new WaitForSeconds(Random.Range(8f, 12f));
        StartCoroutine(EnemyspawnSkelet());
    }
    private IEnumerator EnemyspawnGorgoel()
    {
        if (dificulty == 0)
        {

            for (int i = 0; i < gorguel_count; i++)
            {
                Vector2 circle = Random.onUnitSphere;
                circle = circle.normalized;
                Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                GameObject enemy = Instantiate(gorguel, swpawnpoint, Quaternion.identity);

            }
            Debug.Log(enemy_count);

            
        }
        yield return new WaitForSeconds(Random.Range(10f, 15));
        StartCoroutine(EnemyspawnGorgoel());
    }
    public void ChangeDif()
    {
        //enemy_count += 3;
        dificulty += 1;
        Debug.Log(dificulty);
    }
}
