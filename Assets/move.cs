using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 moveVector;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void MoveHero(Vector2 m)
    {
        moveVector = m;
        rb.AddForce(moveVector * speed, ForceMode2D.Impulse);
    }
    

}