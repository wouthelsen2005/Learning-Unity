using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fireballscript : MonoBehaviour
{
    private Vector3 targetposition;
    public bool playing = true;
    public Rigidbody2D fire_body;
    private Vector3 spawn_pos;
    private int speed = 1000;
    public Animator animator;
    public CapsuleCollider2D m_Collider;
    private bool prep_animationn = true;
    public float Collider_duration = 0.1f;
    public bool hitting = false;
    public float Collider_duration_end;
    public bool test = false;


    
   











    // Start is called before the first frame update
    void Start()
    {


        
        spawn_pos = new(Random.Range(-350, 350), 180, 0);
        transform.position = spawn_pos;

        Vector3 target_position_set_z_0 = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        target_position_set_z_0.z = 0;
        targetposition = target_position_set_z_0;



        m_Collider.enabled = false;






        var start_pos = transform.position;
        var mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDelta = mouse_pos - start_pos;
        var angle = -(Mathf.Atan2(mouseDelta.x, mouseDelta.y) * Mathf.Rad2Deg) + 120;




        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {

       
     

        if (transform.position == targetposition)
        {
       
            if (prep_animationn)
            {
                


                hitting = true;
                Collider_duration_end = Time.time + Collider_duration;
                
                prep_animationn = false;
                prep_animation();
                m_Collider.enabled = true;
                

            }
            if (hitting)
            {
                if (Time.time >= Collider_duration_end)
                {
                    m_Collider.enabled = false;
                    hitting = false;
                }
            }


            



        }





        transform.position = Vector3.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);
        if (!(playing))
        {
            Destroy(gameObject);
        }
    }

    void SetPlaying()
    {

        playing = false;
    }

    void prep_animation()
    {
        m_Collider.enabled = true;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        animator.SetBool("Commet_Arrived", true);
        
    }

    
    
}

