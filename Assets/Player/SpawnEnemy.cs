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
    private int dog_count;
    private int dog_count_current = 0;
    private int dog_count_max = 1;
    private int skelet_count;
    private int skelet_count_current = 0;
    private int skelet_count_max = 2;
    [SerializeField] public GameObject impenemy;
    [SerializeField] public GameObject dog;
    [SerializeField] public GameObject skelet;
    [SerializeField] public GameObject spearskeleton;
    [SerializeField] public GameObject worm;
    [SerializeField] public GameObject gorguel;
    [SerializeField] public GameObject range;
    [SerializeField] public GameObject skull;
    private int dificulty = 0;
    float time;
    private int t =0;
    private int t2 = 0;
    private int spearskeleton_count=1;
    private int spearskeleton_count_current = 0;
    private int spearskeleton_count_max = 1;
    private int worm_count = 1;
    private int worm_count_current = 0;
    private int worm_count_max = 1;
    private int skull_count = 1;
    private int skull_count_current = 0;
    private int skull_count_max = 2;
    private int range_count;
    private int range_count_current = 0;
    private int range_count_max = 1;
    private int gorguel_count=1;
    // Start is called before the first frame update
    void Start()
    {
        if (impenemy != null)
        {
            StartCoroutine(Enemyspawn());
        }
        if (gorguel != null)
        {
            StartCoroutine(EnemyspawnGorgoel());
        }
        if (spearskeleton != null)
        {
            StartCoroutine(EnemyspawnSkelet());
        }
        if (range != null)
        {
            StartCoroutine(EnemyspawnRange());
        }
        if (worm != null)
        {
            StartCoroutine(EnemyspawnWorm());
        }
        if (skull != null)
        {
            StartCoroutine(EnemyspawnSkull());
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        int halfminutes = Mathf.FloorToInt(time / 25);
        if ( t < halfminutes)
        {
            t = halfminutes;
            dificulty++;
            Debug.Log(dificulty);
            enemy_count_max += 2;
            dog_count_max += 1;
            return;
        }
        int minutes = Mathf.FloorToInt(time / 60);
        if (t2 < minutes)
        {
            t2 = minutes;
            range_count_max += 1;
            skelet_count_max++;
            return;
        }

    }

    private IEnumerator Enemyspawn( )
    {

        if (enemy_count_max > enemy_count_current)
        {
            if (dificulty < 3)
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
            if (dificulty <= 6 && dificulty >= 3)
            {
                enemy_count = enemy_count_max - enemy_count_current;
                dog_count = dog_count_max - dog_count_current;
                for (int i = 0; i < enemy_count; i++)
                {
                    enemy_count_current += 1;
                    Vector2 circle = Random.onUnitSphere;
                    circle = circle.normalized;
                    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                    GameObject enemy = Instantiate(impenemy, swpawnpoint, Quaternion.identity);

                }
                for (int i = 0; i < dog_count; i++)
                {
                    dog_count_current += 1;
                    Vector2 circle = Random.onUnitSphere;
                    circle = circle.normalized;
                    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                    GameObject enemy2 = Instantiate(dog, swpawnpoint, Quaternion.identity);

                }

            }
            if (dificulty > 6)
            {
                enemy_count = enemy_count_max - enemy_count_current;
                dog_count = dog_count_max - dog_count_current;
                skelet_count = skelet_count_max - skelet_count_current;
                for (int i = 0; i < enemy_count; i++)
                {
                    enemy_count_current += 1;
                    Vector2 circle = Random.onUnitSphere;
                    circle = circle.normalized;
                    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                    GameObject enemy = Instantiate(impenemy, swpawnpoint, Quaternion.identity);

                }
                for (int i = 0; i < dog_count; i++)
                {
                    dog_count_current += 1;
                    Vector2 circle = Random.onUnitSphere;
                    circle = circle.normalized;
                    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                    GameObject enemy2 = Instantiate(dog, swpawnpoint, Quaternion.identity);

                }
                //for (int i = 0; i < skelet_count; i++)
                //{
                //    skelet_count_current += 1;
                //    Vector2 circle = Random.onUnitSphere;
                //    circle = circle.normalized;
                //    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                //    GameObject enemy3 = Instantiate(skelet, swpawnpoint, Quaternion.identity);

                //}

            }
        }
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
        }
        yield return new WaitForSeconds(23f);
        StartCoroutine(EnemyspawnGorgoel());
    }
    private IEnumerator EnemyspawnWorm()
    {
        if (worm_count_max > worm_count_current)
        {
            if (dificulty >= 3)
            {

                for (int i = 0; i < worm_count; i++)
                {
                    worm_count_current += 1;
                    Vector2 circle = Random.onUnitSphere;
                    circle = circle.normalized;
                    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                    GameObject enemy = Instantiate(worm, swpawnpoint, Quaternion.identity);

                }
            }
        }
        yield return new WaitForSeconds(20f);
        StartCoroutine(EnemyspawnWorm());
    }
    private IEnumerator EnemyspawnSkull()
    {
        if (skull_count_max > skull_count_current)
        {
            if (dificulty > 1)
            {
                skull_count = skull_count_max - skull_count_current;

                for (int i = 0; i < skull_count; i++)
                {
                    Vector2 circle = Random.onUnitSphere;
                    circle = circle.normalized;
                    Vector2 swpawnpoint = (circle * 15) + (Vector2)transform.position;
                    GameObject enemy = Instantiate(skull, swpawnpoint, Quaternion.identity);

                }
 
            }
        }
        yield return new WaitForSeconds(12f);
        StartCoroutine(EnemyspawnSkull());
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
    public void MinusWorm()
    {
        worm_count_current += -1;
    }
    public void MinusSkull()
    {
        skull_count_current += -1;
    }
    public void MinusDog()
    {
        dog_count_current += -1;
    }

}
