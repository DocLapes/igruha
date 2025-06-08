using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Flames : MonoBehaviour
{
    [SerializeField] private GameObject Flame1;
    [SerializeField] private GameObject Flame2;
    [SerializeField] private GameObject Flame3;
    [SerializeField] private GameObject Flame4;
    [SerializeField] private GameObject Flamebase;
    private int ChangeDirectionNumber=0;
    private float ChangePositionNumber = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePosition() {
        if(ChangeDirectionNumber==40)
        {
            ChangeDirectionNumber = 0;
            ChangePositionNumber = -ChangePositionNumber;
        }
        ChangeDirectionNumber += 1;
        Flame1.transform.position = new Vector3((Flame1.transform.position.x + ChangePositionNumber), 0, 0);
        Flame2.transform.position = new Vector3(0, (Flame2.transform.position.y + ChangePositionNumber), 0);
        Flame3.transform.position = new Vector3((Flame3.transform.position.x - ChangePositionNumber), 0, 0);
        Flame4.transform.position = new Vector3(0, (Flame4.transform.position.y - ChangePositionNumber), 0);
    }
}
