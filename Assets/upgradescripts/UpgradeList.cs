using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeList : MonoBehaviour
{
    [SerializeField] Button UpgradeOne;
    [SerializeField] Button UpgradeTwo;
    [SerializeField] upgrade Upgrade;
    [SerializeField] upgrade Upgrade1;
    [SerializeField] upgrade Upgrade2;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    public void RNG_Upgrade()
    {
        upgrade[] List = { Upgrade, Upgrade1, Upgrade2 };
        int count = List.Length;
        int n1 = Random.Range(0, count);
        int n2 = Random.Range(0, count);
        upgrade upgr1 = List[n1];
        upgrade upgr2 = List[n2];


        if (n1 != n2)
        {
            Debug.Log(n1);
            Debug.Log(n2);
            Debug.Log(count);
            UpgradeOne.GetComponent<UpgradeDisplay>().GetUpgrade(upgr1);
            UpgradeTwo.GetComponent<UpgradeDisplay>().GetUpgrade(upgr2);

        }
        else
        {
            RNG_Upgrade();
        }

    }
}
