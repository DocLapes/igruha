using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeList : MonoBehaviour
{
    [SerializeField] Button UpgradeOne;
    [SerializeField] Button UpgradeTwo;
    [SerializeField] upgrade[] Massive;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Massive[0]);
        Debug.Log(Massive[1]);
        Debug.Log(Massive[2]);
        Debug.Log(Massive.Length);
    }

    // Update is called once per frame
    public void RNG_Upgrade()
    {
        
        int count = Massive.Length;
        int n1 = Random.Range(0, count);
        int n2 = Random.Range(0, count);
        upgrade upgr1 = Massive[n1];
        upgrade upgr2 = Massive[n2];


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
