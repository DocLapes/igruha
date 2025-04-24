using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Smert Smert;
    [SerializeField] private SpearList Damagedeal;
    [SerializeField] private playermanager Playermanager;
    [SerializeField] private TextMeshProUGUI Text1;
    [SerializeField] private TextMeshProUGUI Text2;
    [SerializeField] private TextMeshProUGUI Text3;
    [SerializeField] private TextMeshProUGUI Text4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playermanager != null) {
            Text1.text = string.Format("Max Health {0}", Smert.ReturnHeath());
            Text2.text = string.Format("Health regen {0}", Smert.ReturnRegen());
            Text3.text = string.Format("Atack speed {0}", Playermanager.ReturnAtackSpeed());
            Text4.text = string.Format("Damage {0}", Damagedeal.ReturnDamage());


        } 

    }
}
