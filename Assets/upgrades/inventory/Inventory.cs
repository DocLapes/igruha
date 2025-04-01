using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<upgrade> StartItems = new List<upgrade>();
    public List<upgrade> InventoryItems = new List<upgrade>();
    public static UnityEvent AddNewIcon = new UnityEvent();
    void Start()
    {
        for (int i = 0; i < StartItems.Count; i++) 
        {
            AddItems(StartItems[i]);
            Debug.Log("govno");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItems(upgrade upgrade)
    {
        int num = 0;
        foreach (upgrade item in InventoryItems)
        {
            if(item.Stat == upgrade.Stat)
            {
                num=num+1;
            }
        }
        if (num == 0)
        {
            InventoryItems.Add(upgrade);
            AddNewIcon.Invoke();
            Debug.Log("+");
        }
    }
}
