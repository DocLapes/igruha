using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float time;
    int t = 10;
    [SerializeField] TextMeshProUGUI timertext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

       
    }

    
}
