using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    Vector3 start_pos;
    Vector3 mouse_pos;
    public Animator animator;

    







    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

       
        start_pos = transform.position;
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDelta = mouse_pos - start_pos;
        var angle = -(Mathf.Atan2(mouseDelta.x, mouseDelta.y) * Mathf.Rad2Deg) + 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //Animator.Play("BowShooting");//

    }


   
        
    public void Shoot_animation()
    {

        animator.SetBool("Shooting", true);
        
    }
    public void Stop_animation(string message)
    {

        if (message.Equals("StopAnimation"))
        {
        
            animator.SetBool("Shooting", false);

        }
    }
}
        