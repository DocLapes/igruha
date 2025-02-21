using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent TimerChangeDif = new UnityEvent();
    // Start is called before the first frame update

    public static void TimerChange()
    {

        TimerChangeDif.Invoke();
    }

}
