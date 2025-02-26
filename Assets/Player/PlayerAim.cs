using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Vector3 mousepos;
    Vector3 aimDirection;
    Vector3 localscale;
    [SerializeField] private GameObject Aim;
    Transform KopieTrans;
    private GameObject cube;
    float angle;
    private bool isAtack=false;
    // Start is called before
    // the first frame update
    private void Awake()
    {
        localscale = Vector3.one;
    }
    void Start()
    {
        cube = gameObject;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isAtack == false)
        {
            mousepos = Input.mousePosition;
            mousepos.z = 10.0f;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            //gameObject.transform.position = mousepos;
            aimDirection = (mousepos - Aim.transform.position).normalized;
            angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            Aim.transform.eulerAngles = new Vector3(0, 0, angle);
            
            if (angle > 90 || angle < -90){
                localscale.y = -1f;
            }else{
                localscale.y = +1f;
            }
            Aim.transform.localScale = localscale;
        }
        else {
            mousepos = Input.mousePosition;
            mousepos.z = 10.0f;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            //gameObject.transform.position = mousepos;
            aimDirection = (mousepos - Aim.transform.position).normalized;
            angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            Aim.transform.eulerAngles = new Vector3(0, 0, angle);

            if (angle > 90 || angle < -90)
            {
                localscale.y = -1f;
            }
            else
            {
                localscale.y = +1f;
            }
            Aim.transform.localScale = localscale;
        }
    }
    public void Hit()
    {
        
        cube.GetComponent<Damagedeal>().ProcessHit(aimDirection);
    }
   

    //public void Atackreload(float atacktimemetod)
    //{
    //    isAtack = true;
    //    Invoke(nameof(OutAtackreload), atacktimemetod);
    //}
    //public void OutAtackreload()
    //{
    //    isAtack = false;
    //}
    public void ChangeBool()
    {
        isAtack = !isAtack;
    }
}
