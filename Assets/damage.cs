using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damag : MonoBehaviour
{
    private int damage = 5;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<smert>() != null)
            collision.gameObject.GetComponent<smert>().takedamage(damage);
            collision.gameObject.GetComponent<smert>().otkinyt(-30);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<smert>() != null)
            other.gameObject.GetComponent<smert>().takedamage(damage);
            
    }
}

