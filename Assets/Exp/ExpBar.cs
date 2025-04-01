using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject upgradeList;
    [SerializeField] private GameObject specialupgradeList;
    public Slider expslider;
    private int Exp;
    private int ExpforNextLevel=50;
    private int Expleft;
    private int lvl=1;


    void Awake()
    {
        Exp = 0;
        ExpCollector.AddNewExp.AddListener(addExp);
    }

    // Update is called once per frame
    void Update()
    {
        expslider.value = Exp;
        if (Input.GetKeyUp(KeyCode.LeftControl)) {
            Exp += 100;
        }
        if (lvl % 2 == 1 && (Exp == ExpforNextLevel || Exp > ExpforNextLevel)) {
            Expleft = Exp - ExpforNextLevel;
            Exp = Expleft;
            ExpforNextLevel += 15;
            expslider.maxValue = ExpforNextLevel;
            lvl++;
            Debug.Log(lvl + "¿œ√–Ã≈Õ" + lvl%2 );
            UpgradeMenu.isupgrademenu = true;
            upgradeList.GetComponent<UpgradeList>().RNG_Upgrade();
            
        }
        if (lvl % 2 ==0 && (Exp == ExpforNextLevel || Exp > ExpforNextLevel) )
        {
            Expleft = Exp - ExpforNextLevel;
            Exp = Expleft;
            ExpforNextLevel += 50;
            expslider.maxValue = ExpforNextLevel;
            lvl++;
            Debug.Log(lvl + "—œ≈ÿ¿œ√–Ã≈Õ" + lvl % 2);
            SpecialUpgradeMenu.isspecialupgrademenu = true;
            specialupgradeList.GetComponent<SpecialUpgradeList>().RNG_Upgrade();
        }


    }
    public void addExp() {
        Exp += 15;
        Debug.Log(Exp);
    }

}
