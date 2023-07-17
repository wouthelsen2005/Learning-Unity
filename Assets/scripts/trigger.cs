using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class trigger : MonoBehaviour
{

    private List<GameObject> freezes = new List<GameObject>();
  
    public bool triggered = false;


    void Start()
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
    void Update()
    {
        
        if(triggered)
        {
            StartCoroutine(manage_col());
            triggered = false;
            
        }

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemie")
        {
            freezes.Add(collision.gameObject);

        }
    }
    

    IEnumerator manage_col()
    {
        GetComponent<Collider2D>().isTrigger = true;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForSeconds(0.05f);
        foreach (GameObject enemie in freezes)
        {
            try
            {
                
                enemie.SendMessage("freezee");
            }
            
            catch (Exception e)
            {
                print("object is dood");
            }




            
        }
        
        freezes.Clear();
        GetComponent<Collider2D>().isTrigger = false;
       


    }

   



}
