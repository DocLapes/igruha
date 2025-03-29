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
    private Smert Ymer;
    void Awake()
    {
        health = Hero.GetComponent<Smert>().Entityheath;
        Ymer = Hero.GetComponent<Smert>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ymer != null)
        {
            health = Ymer.Entityheath;
            if (healthslider.value != health)
            {
                healthslider.value = health;
            }
        }
    }
}
