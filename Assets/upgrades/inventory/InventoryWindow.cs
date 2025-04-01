using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Inventory inventory;
    [SerializeField] RectTransform itemsPanel;
    private List<GameObject> DrawnIcons = new List<GameObject>();
    void Start()
    {
        Redraw();
        Inventory.AddNewIcon.AddListener(Redraw);
    }
    private void Update()
    {
       
    }
    // Update is called once per frame
    public void Redraw()
    {
        Clear();
        for (int i = 0; i < inventory.InventoryItems.Count; i++) 
        { 
            var item = inventory.InventoryItems[i];

            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.Icon;

            icon.transform.SetParent(itemsPanel);

            DrawnIcons.Add(icon);
        }
    }
    public void Clear() { 
        for (int i = 0;i < DrawnIcons.Count; i++)
        {
            Destroy(DrawnIcons[i]);
        }
        DrawnIcons.Clear();
    }
} 
