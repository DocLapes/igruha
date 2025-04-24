using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    

    public GameObject Player => Hero;
    public static GameManager instance = null; 

    
   
    void Start()
    {
        if (instance == null)
        { 
            instance = this; 
        }
        else if (instance == this)
        { 
            
        }

    }
    
    //private void InitializeGameManager()
    //{
    //}
}


