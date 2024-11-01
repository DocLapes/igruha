using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecommand : MonoBehaviour
{
    private Vector2 cmoveVector;
    [SerializeField] private GameObject Hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cmoveVector.x = Input.GetAxis("Horizontal");
        cmoveVector.y = Input.GetAxis("Vertical");
        Hero.gameObject.GetComponent<move>().MoveHero(cmoveVector.normalized);
        


    }
}
