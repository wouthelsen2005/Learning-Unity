using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manabarscript : MonoBehaviour
{
   
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = GetComponentInParent<Manascript>().maxmana;
        slider.value = GetComponentInParent<Manascript>().maxmana;

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GetComponentInParent<Manascript>().current_mana;
    }

    
}
