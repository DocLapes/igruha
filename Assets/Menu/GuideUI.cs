using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GuideUI : MonoBehaviour
{
    [SerializeField] private GameObject GuideText;
    private bool gmstate=true;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SwitchBool), 5f);
    }
    //void OnMouseDown()
    //{
    //    Debug.Log("брах");
    //    SwitchBool();
    //    // Code here is called when the GameObject is clicked on.
    //}
    // Update is called once per frame
    public void SwitchBool()
    {
        gmstate=!gmstate;
        GuideText.SetActive(gmstate);
    }
   
}   
