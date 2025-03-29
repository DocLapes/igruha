using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private Slider ReloadSlider;
    private float reloadatacktime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        ReloadSlider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ReloadSlider.value < reloadatacktime)
        {
            ReloadSlider.value += Time.deltaTime;
        }
        if (ReloadSlider.value >= reloadatacktime)
        {
            //gameObject.GetComponent<Image>().color.WithAlpha(60f);
        }
    }
    public void StartReload(float time)
    {
        reloadatacktime = time; 
        ReloadSlider.value = 0f;
        ReloadSlider.maxValue = time;
        //gameObject.GetComponent<Image>().color.WithAlpha(20f);
    }

}
