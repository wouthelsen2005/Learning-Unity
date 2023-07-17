using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletWarriorHpBar : MonoBehaviour
{
    public Slider slider;
   

    // Start is called before the first frame update
    void Start()
    {
       
        slider.maxValue = GetComponentInParent<SkeletWarrior>().hp;
        gameObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GetComponentInParent<SkeletWarrior>().hp;

    }
}
