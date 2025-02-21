using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Slider expslider;
    private int Exp;
    private int ExpforNextLevel=50;
    private int Expleft;


    void Awake()
    {
        Exp = 0;
        ExpCollector.AddNewExp.AddListener(addExp);
    }

    // Update is called once per frame
    void Update()
    {
        expslider.value = Exp;
        
        if (Exp == ExpforNextLevel || Exp > ExpforNextLevel) {
            Expleft = Exp - ExpforNextLevel;
            Exp = Expleft;
            ExpforNextLevel += 50;
            expslider.maxValue = ExpforNextLevel;
        }

    }
    public void addExp() {
        Exp += 10;
        Debug.Log(Exp);
    }

}
