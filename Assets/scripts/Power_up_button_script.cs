using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power_up_button_script : MonoBehaviour
{
    public Vector3 mouse_pos;
    public GameObject Fireball;
    public float cooldown_duration = 10;
    public Slider slider;
    public bool on_cooldown = false;
    public int mana_cost = 25;
    public Manascript mana;
    public Material mat;
    public Color _emissionColorValue;
    public Material manamat;




    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = cooldown_duration;
        slider.value = cooldown_duration;
        mat.SetColor("_Color", _emissionColorValue * 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse_pos.z = 0;
        if (Input.GetKeyDown(KeyCode.Space) && (on_cooldown == false) && (mana_cost <= mana.current_mana))
        {
           
            GameObject Fireballl = Instantiate(Fireball);
            StartCoroutine(AnimateSliderOverTime(cooldown_duration));
            mana.current_mana -= mana_cost;




        }

        else if (Input.GetKeyDown(KeyCode.Space) && (on_cooldown == false) && (mana_cost > mana.current_mana))
        {


            StartCoroutine(GlowButton(manamat));

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
        StartCoroutine(GlowButton(mat));
        on_cooldown = false;
    }

    IEnumerator GlowButton(Material math)
    {

        for (float i = 1; i < 6; i += (0.1f)) //start traag met glow en eindig snel
        {

            mat.SetColor("_Color", _emissionColorValue * 0.4f * i);
            yield return new WaitForEndOfFrame();
        }

        for (float i = 6; i > 1; i -= (0.1f)) //start snel met glow en eindig traag
        {


            mat.SetColor("_Color", _emissionColorValue * 0.4f * i);
            yield return new WaitForEndOfFrame();
        }
    }
}
