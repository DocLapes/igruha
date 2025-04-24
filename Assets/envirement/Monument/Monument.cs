using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Monument : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject visualmodel;
    [SerializeField] private GameObject NextMonolith;
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject OblastV;
    [SerializeField] private GameObject Oblast;
    [SerializeField] private TextMeshProUGUI numSouls;
    private bool isPlayerNear=false;
    private int souls=1;
    [SerializeField] private int Needsouls;
    private float distance;

    enum State
    {
        Idle,
        TakeEnergy,
        Ready

    }
    private State state = State.Idle;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameManager.instance.Player.transform;
        StartCoroutine(LoseSoul());
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            Vector2 targetDir = Player.position - transform.position;
            var heading = Player.position - transform.position;
            distance = heading.sqrMagnitude;
        }
        if (distance <= 55f)
        {
            isPlayerNear = true;
        }
        if (distance > 55f)
        {
            isPlayerNear = false;
        }
        if (state == State.Idle)
        {
           
            Oblast.SetActive(false);
            OblastV.SetActive(false);
            visualmodel.GetComponent<AnimatorManager>().Idle(); 
        }
        if (state == State.TakeEnergy)
        {
            
            numSouls.text = string.Format("{0}/{1}", souls, Needsouls);
            Oblast.SetActive(true);
            OblastV.SetActive(true);
            visualmodel.GetComponent<AnimatorManager>().Walking();
            if(souls>= Needsouls)
            {
                ActivateNext();
            }

        }
        if (state == State.Ready)
        {
            Oblast.SetActive(false);
            OblastV.SetActive(false);
            visualmodel.GetComponent<AnimatorManager>().Atack();
        }

    }
    public void Activate()
    {
        state = State.TakeEnergy;
    }
    public void ActivateNext()
    {
        if (NextMonolith != null)
        {
            NextMonolith.GetComponent<Monument>().Activate();
            state = State.Ready;
        }
        if(Win != null)
        {
            Win.GetComponent<Timer>().WinScreen();
        }
      
    }
    public void GetSouls()
    {
        
        if (state == State.TakeEnergy)
        {
            souls += 1;
        }
    }
    public IEnumerator LoseSoul()
    {
        if (state == State.TakeEnergy)
        {
            if (isPlayerNear == false)
            {
                if (souls > 0)
                {
                    souls = souls - 1;
                }
                

            }
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(LoseSoul());
    }
}
