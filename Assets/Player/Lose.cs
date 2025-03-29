using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lose : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Menu;
    private PauseMenu Pmenu;
    private void OnDestroy()
    {
        if (Menu != null)
        {
            Pmenu = Menu.GetComponent<PauseMenu>();
            if (Pmenu != null)
            {
                Pmenu.Lose();
            }
        }
        
    }
}
