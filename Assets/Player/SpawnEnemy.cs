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
    private int enemy_count;
    private int enemy_count_current = 0;
    private int enemy_count_max= 10;
    [SerializeField] public GameObject impenemy;
    [SerializeField] public GameObject spearskeleton;
    [SerializeField] public GameObject worm;
    [SerializeField] public GameObject gorguel;
    [SerializeField] public GameObject range;
    private int dificulty = 0;
    float time;
    private int t =0;
    private int t2 = 0;
    private int spearskeleton_count=1;
    private int spearskeleton_count_current = 0;
    private int spearskeleton_count_max = 1;
    private int range_count;
    private int range_count_current = 0;
    private int range_count_max = 1;
    private int gorguel_count=1;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Enemyspawn());
        //StartCoroutine(EnemyspawnGorgoel());
        //StartCoroutine(EnemyspawnSkelet());
        //StartCoroutine(EnemyspawnRange());
        StartCoroutine(EnemyspawnWorm());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int halfminutes = Mathf.FloorToInt(time / 25);
        if ( t < halfminutes)
        {
            t = halfminutes;
            dificulty++;
            Debug.Log(dificulty);
            enemy_count_max += 3;
            return;
        }
        int minutes = Mathf.FloorToInt(time / 60);
        if (t2 < minutes)
        {
            t2 = minutes;
            range_count_max += 1;
            return;
        }

    }

    private IEnumerator Enemyspawn( )
    {

        if (enemy_count_max > enemy_count_current)
        {
            enemy_count = enemy_count_max - enemy_count_current;
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
        if (spearskeleton_count_max > spearskeleton_count_current) {
            if (dificulty > 2)
            {
                
                for (int i = 0; i < spearskeleton_count; i++)
                {
                    spearskeleton_count_current += 1;
                    Vector2 circle = Random.onUnitSphere;
                    circle = circle.normalized;
                    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                    GameObject enemy = Instantiate(spearskeleton, swpawnpoint, Quaternion.identity);

                }
                //Debug.Log(range_count);

            }
        }
        yield return new WaitForSeconds(Random.Range(15f, 19f));
        StartCoroutine(EnemyspawnSkelet());
    }
    private IEnumerator EnemyspawnRange()
    {
        if (range_count_max > range_count_current) {    
            if (dificulty >= 1)
            {
                range_count = range_count_max - range_count_current;
                for (int i = 0; i < range_count; i++)
                {
                    range_count_current += 1;
                    Vector2 circle = Random.onUnitSphere;
                    circle = circle.normalized;
                    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                    GameObject enemy = Instantiate(range, swpawnpoint, Quaternion.identity);

                }
                //Debug.Log(enemy_count);

            }
        }
        yield return new WaitForSeconds(12f);
        StartCoroutine(EnemyspawnRange());
    }
    private IEnumerator EnemyspawnGorgoel()
    {
        if (dificulty > 4)
        {

            for (int i = 0; i < gorguel_count; i++)
            {
                Vector2 circle = Random.onUnitSphere;
                circle = circle.normalized;
                Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                GameObject enemy = Instantiate(gorguel, swpawnpoint, Quaternion.identity);

            }
            //Debug.Log(enemy_count);

            
        }
        yield return new WaitForSeconds(23f);
        StartCoroutine(EnemyspawnGorgoel());
    }
    private IEnumerator EnemyspawnWorm()
    {
        if (spearskeleton_count_max > spearskeleton_count_current)
        {
            if (dificulty >= 0)
            {

                for (int i = 0; i < spearskeleton_count; i++)
                {
                    Vector2 circle = Random.onUnitSphere;
                    circle = circle.normalized;
                    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                    GameObject enemy = Instantiate(worm, swpawnpoint, Quaternion.identity);

                }
                //Debug.Log(range_count);

            }
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine(EnemyspawnSkelet());
    }
    public void MinusEnemy()
    {
        enemy_count_current += -1;
    }
    public void MinusSpearEnemy()
    {
        spearskeleton_count_current += -1;
    }
    public void MinusRangeEnemy()
    {
        range_count_current += -1;
    }
}
