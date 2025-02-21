using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExpCollector : MonoBehaviour
{
    // Start is called before the first frame update
    public static UnityEvent AddNewExp = new UnityEvent();
    // Start is called before the first frame update

    public static void TookExp()
    {
       
        AddNewExp.Invoke();
    }
}
