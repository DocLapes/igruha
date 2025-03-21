using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksList : MonoBehaviour
{
    [SerializeField] private GameObject Book1;
    [SerializeField] private GameObject Book2;
    [SerializeField] private GameObject Book3;

    public void GiveStats(int dam){

        Book1.GetComponent<Books>().GetStats(dam);
        if (Book2 != null)
        {
            Book2.GetComponent<Books>().GetStats(dam);
        }
        if (Book3 != null)
        {
            Book3.GetComponent<Books>().GetStats(dam);
        }
    }
    
}
