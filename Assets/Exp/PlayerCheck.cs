using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField]private GameObject expmove;
    private Transform Player;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameManager.instance.Player.transform;
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
        if (distance <= 15f)
        {
            expmove.GetComponent<move>().Move(targetDir);

        }
        
    }

}
