using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze_script : MonoBehaviour
{
    
  
    public Rigidbody2D enemie_red_body;
    public Animator freeze_ani;
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
        
        
        

    }

    void Check()
    {
        FindObjectOfType<Audiomanarger>().Play("ice forming");
        freeze_ani.SetBool("Settled", true);
        StartCoroutine(freeze_animation());
        


    }

    IEnumerator freeze_animation()
    {
       
        yield return new WaitForSeconds(3);
        freeze_ani.SetBool("freeze_end", true);

    }
    void end_freeze()
    {
        
        gameObject.SetActive(false);
        Enemy_red_script enemiescript = GetComponentInParent<Enemy_red_script>();
        enemiescript.IsFreezed = false;
        Animator enemieanimator = GetComponentInParent<Animator>();
        enemieanimator.SetBool("IsFreezed", false);
        FindObjectOfType<Audiomanarger>().Play("ice breaking");
        enemie_red_body.constraints = RigidbodyConstraints2D.None;
        
    }




}
