using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class freeze_button_script : MonoBehaviour
{

    public Slider slider;
    public trigger trigger;
    public bool on_cooldown = false;
    public int cooldown_duration = 5;
    public Manascript mana;
    public int mana_cost = 80;
    public Material mat;
    public Color _emissionColorValue;
    public Color manacolor;

    public GameObject Mana;
   




    private void Start()
    {
        slider.maxValue = cooldown_duration;
        slider.value = cooldown_duration;
        mat.SetColor("_Color",_emissionColorValue * 0.4f);
        Debug.Log("color sett");

        Manascript manascript = Mana.GetComponentInChildren<Manascript>();
        manascript.ManaMat.SetColor("_Color", manacolor);


    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && (on_cooldown == false) && (mana_cost <= mana.current_mana))

        {
            StartCoroutine(AnimateSliderOverTime(cooldown_duration));
          
            trigger.triggered = true;

            mana.current_mana -= mana_cost; //?
        }
        else if (Input.GetKeyDown(KeyCode.R) && (on_cooldown == false) && (mana_cost > mana.current_mana))
        {
            Manascript manascript = Mana.GetComponentInChildren<Manascript>();
            manascript.ManaMat.SetColor("_Color",manacolor);
            manascript.startit();
            
          
            
        }

       
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("kk");
            StartCoroutine(GlowButtonfreeze(mat, _emissionColorValue));
        }

    }

    IEnumerator AnimateSliderOverTime(float seconds)
    {
        on_cooldown = true;
        float animationTime = 0f;
        while (animationTime < seconds)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / seconds;
            slider.value = Mathf.Lerp(0, cooldown_duration, lerpValue);
            yield return null;
        }
        StartCoroutine(GlowButtonfreeze(mat, _emissionColorValue));
        on_cooldown = false;
        
       
    }

    IEnumerator GlowButtonfreeze(Material math, Color color)
    {
       
        for (float i = 1; i<6; i += (0.1f)) //start traag met glow en eindig snel
        {

            mat.SetColor("_Color", color * 0.4f * i);
            yield return new WaitForEndOfFrame();
        }
        
        for (float i = 6; i > 1; i -= (0.1f)) //start snel met glow en eindig traag
        {


            mat.SetColor("_Color", color * 0.4f * i);
            yield return new WaitForEndOfFrame();
        }
    }
}
