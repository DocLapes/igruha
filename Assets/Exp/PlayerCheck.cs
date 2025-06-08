using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField]private GameObject expmove;
    private Transform Player;
    private float radius;
    private float speed;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameManager.instance.Player.transform;
        
    }
    private void Start()
    {
        radius = Player.gameObject.GetComponent<playermanager>().radius;
        speed = Player.gameObject.GetComponent<playermanager>().speed;
        expmove.GetComponent<move>().GetSpeed(speed);
        Debug.Log(radius);
        Debug.Log(speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player == null)
        {
            Destroy(gameObject);
        }
        Vector2 targetDir = Player.position - transform.position;
        var heading = Player.position - transform.position;
        float distance = heading.sqrMagnitude;
        
        if (distance <= radius)
        {
           
            expmove.GetComponent<move>().Move(targetDir);

        }
        
    }

}
