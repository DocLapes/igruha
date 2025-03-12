using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class healtbar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Hero;
    public Slider healthslider;
    private float health;
    void Awake()
    {
        health = Hero.GetComponent<smert>().Entityheath;
    }

    // Update is called once per frame
    void Update()
    {
        health = Hero.GetComponent<smert>().Entityheath;
        if (healthslider.value != health)
        {
            healthslider.value = health;
        }
        
    }
}
