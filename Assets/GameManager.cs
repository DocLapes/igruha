using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
//    void Start()
//    {
//        Singleton.GetInstance(Hero);
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
   
//}
//public class Singleton
//{
//    private static Singleton instance;

//    public GameObject Player { get; private set; }
//    private Singleton(GameObject player)
//    {
//        this.Player = player;
//    }

//    public static Singleton GetInstance(GameObject player)
//    {
//        if (instance == null)
//            instance = new Singleton(player);
//        return instance;
//    }

