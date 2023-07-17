using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healtbar_script : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private Image healthbarsprite;
    private float show_healtbar_duration = 2;
    private float timer;
    private bool visible = false;


    void Start()
    {
        float maxslidervalue = GetComponentInParent<Enemy_red_script>().MaxHp;
        slider.maxValue = maxslidervalue;
        gameObject.SetActive(false);

    }


    public void UpdateHealthBar(float health)
    {
        gameObject.SetActive(true);

        slider.value = health;
        timer = Time.time + show_healtbar_duration;
        visible = true;

    }
    void Update()
    {
        if((timer <= Time.time) && visible)
        {

            visible = false;
            gameObject.SetActive(false);

        }
    }


}
