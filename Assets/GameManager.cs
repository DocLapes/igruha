using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    

    public GameObject Player => Hero;
    // Start is called before the first frame update
    public static GameManager instance = null; // Ёкземпл€р объекта

    
    // ћетод, выполн€емый при старте игры
    void Start()
    {
        // “еперь, провер€ем существование экземпл€ра
        if (instance == null)
        { // Ёкземпл€р менеджера был найден
            instance = this; // «адаем ссылку на экземпл€р объекта
            InitializeGameManager();
        }
        else if (instance == this)
        { // Ёкземпл€р объекта уже существует на сцене
            
        }

        



    }
    
    // ћетод инициализации менеджера
    private void InitializeGameManager()
    {
        /* TODO: «десь мы будем проводить инициализацию */
    }
}


