using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
    public GameObject Player => Hero;
    // Start is called before the first frame update
    public static GameManager instance = null; // ��������� �������

    // �����, ����������� ��� ������ ����
    void Start()
    {
        // ������, ��������� ������������� ����������
        if (instance == null)
        { // ��������� ��������� ��� ������
            instance = this; // ������ ������ �� ��������� �������
            InitializeGameManager();
        }
        else if (instance == this)
        { // ��������� ������� ��� ���������� �� �����
            
        }                                                                       


        
        
    }

    // ����� ������������� ���������
    private void InitializeGameManager()
    {
        /* TODO: ����� �� ����� ��������� ������������� */
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

