using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DirectionToAltar : MonoBehaviour
{
    private GameObject Altar;
    Vector3 aimDirection;
    Vector3 localscale;
    [SerializeField] private GameObject Direction;
    float angle;
    // Start is called before the first frame update
    void Awake()
    {
        localscale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 GdeAltar = new Vector3(Altar.transform.position.x, Altar.transform.position.y,10f);
        aimDirection = (Altar.transform.position - Direction.transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Direction.transform.eulerAngles = new Vector3(0, 0, angle);

        if (angle > 90 || angle < -90)
        {
            localscale.y = -1f;
        }
        else
        {
            localscale.y = +1f;
        }
        Direction.transform.localScale = localscale;
    }
    public void GetAltar(GameObject NewAltar)
    {
        Altar = NewAltar;
    }
}
