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
    private int enemy_count=4;
    private int enemy_count_current = 0;
    private int enemy_count_max= 10;
    [SerializeField] public GameObject impenemy;
    [SerializeField] public GameObject spearskeleton;
    [SerializeField] public GameObject gorguel;
    [SerializeField] public GameObject range;
    private int dificulty = 0;
    float time;
    private int t =0;
    private int spearskeleton_count;
    private int range_count;
    private int gorguel_count=1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemyspawn());
        StartCoroutine(EnemyspawnGorgoel());
        StartCoroutine(EnemyspawnSkelet());
        StartCoroutine(EnemyspawnRange());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 25);
        if ( t < minutes )
        {
            t = minutes;
            dificulty++;
            enemy_count += 2;
            Debug.Log(dificulty);
            enemy_count_max += 3;
            return;
        }

    }

    private IEnumerator Enemyspawn( )
    {

        if (enemy_count_max > enemy_count_current)
        {
            for (int i = 0; i < enemy_count; i++)
            {
                enemy_count_current += 1;
                Vector2 circle = Random.onUnitSphere;
                circle = circle.normalized;
                Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                GameObject enemy = Instantiate(impenemy, swpawnpoint, Quaternion.identity);

            }
        }
        //Debug.Log(enemy_count_current);
        
       
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(Enemyspawn());
    }
    private IEnumerator EnemyspawnSkelet()
    {
        if (dificulty > 0)
        {
            spearskeleton_count = Random.Range(1, 2);
            for (int i = 0; i < spearskeleton_count; i++)
            {
                Vector2 circle = Random.onUnitSphere;
                circle = circle.normalized;
                Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                GameObject enemy = Instantiate(spearskeleton, swpawnpoint, Quaternion.identity);

            }
            //Debug.Log(enemy_count);

            
        }
        yield return new WaitForSeconds(Random.Range(15f, 19f));
        StartCoroutine(EnemyspawnSkelet());
    }
    private IEnumerator EnemyspawnRange()
    {
        if (dificulty >= 0)
        {
            range_count = Random.Range(1, 2);
            for (int i = 0; i < range_count; i++)
            {
                Vector2 circle = Random.onUnitSphere;
                circle = circle.normalized;
                Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                GameObject enemy = Instantiate(range, swpawnpoint, Quaternion.identity);

            }
            //Debug.Log(enemy_count);


        }
        yield return new WaitForSeconds(Random.Range(10f, 15f));
        StartCoroutine(EnemyspawnRange());
    }
    private IEnumerator EnemyspawnGorgoel()
    {
        if (dificulty > 1)
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
        yield return new WaitForSeconds(Random.Range(19f, 26f));
        StartCoroutine(EnemyspawnGorgoel());
    }
    public void MinusEnemy()
    {
        enemy_count_current += -1;
    }
}
