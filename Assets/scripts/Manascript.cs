using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manascript : MonoBehaviour
{
    public Material ManaMat;
    public int maxmana = 100;
    public int current_mana = 100;
    public float regen_time = 1f;
    public Color manacolor;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(mana_refilling());

    }

    // Update is called once per frame
    void Update()
    {
        ManaMat.SetColor("_Color", manacolor * 10);
    }
    public void startit()
    {
        StartCoroutine(GlowButton());
    }

    IEnumerator mana_refilling()
    {
        while (true)
        {
            if (current_mana <100)
            {
                current_mana += 1;
               
                yield return new WaitForSeconds(regen_time);
            }
            else
            {
                yield return new WaitForSeconds(1); //anders stuck in while loop --> game crashed
            }
        }
    }

    IEnumerator GlowButton()
    {
        
        for (float i = 1; i < 5; i += 0.01f) //start traag met glow en eindig snel
        {
            Debug.Log("g");
            ManaMat.SetColor("_Color", manacolor *10* i);
            yield return new WaitForEndOfFrame();
        }

        for (float i = 5; i > 1; i -= 0.01f) //start snel met glow en eindig traag
        {

            
            ManaMat.SetColor("_Color", manacolor* 10*i);
            yield return new WaitForEndOfFrame();
        }
    }
}
