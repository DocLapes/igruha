using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float time;
    //int t = 10;
    [SerializeField] TextMeshProUGUI timertext;
    [SerializeField] GameObject Win;
    [SerializeField] GameObject Monument;
    [SerializeField] private bool WinCondition;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Monument!=null)
        {
            Monument.GetComponent<Monument>().Activate();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (minutes == 4 && seconds == 0 && WinCondition==true)
        {
            WinScreen();
        }

    }

    public void WinScreen()
    {
        Win.GetComponent<PauseMenu>().Win();
    }
}
