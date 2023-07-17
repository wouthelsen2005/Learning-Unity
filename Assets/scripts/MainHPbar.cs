using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHPbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public float maxhp = 100;
    public float currenthp;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxhp;
        currenthp = maxhp;
        slider.value = maxhp;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
        slider.value = currenthp;

        if (slider.value <= 0)
        {
            Application.Quit();
        }
    }

    public IEnumerator hp_slide(float seconds)  // not used
    {
        float animationTime = 0f;
        float begin_value = slider.value;
        float end_value = (slider.value - 10);
        while (animationTime < seconds)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / seconds;
            slider.value = Mathf.Lerp(begin_value, end_value , lerpValue);
            Debug.Log(slider.value);
            Debug.Log(seconds - animationTime);
            yield return null;
        }
    }
}
