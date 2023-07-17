using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    //public Vector3 spawnpoint = new(-33, 0, 0);//
    
    public Vector3 targetposition;
    public Rigidbody2D arrow_bodie;
    public float speed = 15;
    public int damage = 5;
    public float YVectorChange;
    private float Angle;
    private Vector3 newtargetposition;

    // Start is called before the first frame update
    void Start()
    {
        DetermeAngle();
        CreateVectorOfAngle();
        CorrectVectorAgleOfArrow(Angle, targetposition);
    }

    // Update is called once per frame
    void Update()
    {
        arrow_bodie.MovePosition(transform.position + newtargetposition*speed);
        //transform.position += speed * Time.deltaTime * newtargetposition;//
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "enemie")

        {
            Destroy(gameObject);
        }

    }

    private void CorrectVectorAgleOfArrow(float angle, Vector3 targetposition)
    {
        if (angle <= 45 && angle > 0)
        {
            newtargetposition =  new(targetposition.x, targetposition.y + YVectorChange, 0);
        }
        else if (angle > 45 && angle < 180)
        {
            newtargetposition = new(targetposition.x + +YVectorChange, targetposition.y, 0);
        }
        else if (angle < 0 && angle > -45)
        {
            newtargetposition = new(targetposition.x, targetposition.y + YVectorChange, 0);
        }
        else if (angle < -45 && angle > -180)
        {
            newtargetposition = new(targetposition.x + +YVectorChange, targetposition.y, 0);
        }
        else
        {
            newtargetposition = new(targetposition.x + +YVectorChange, targetposition.y, 0);    //need to check on this not correct
        }
    }

    private void DetermeAngle()
    {
        var start_pos = transform.position;
        var mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDelta = mouse_pos - start_pos;
        mouseDelta.Normalize();
        Vector3 newmousedelta = new(mouseDelta.x, mouseDelta.y + YVectorChange);
        newmousedelta.Normalize();
        var angle = -(Mathf.Atan2(newmousedelta.x, newmousedelta.y) * Mathf.Rad2Deg) + 90;

        Angle = angle;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void CreateVectorOfAngle()
    {
        Vector3 target_position_set_z_0 = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        target_position_set_z_0.z = 0;

        targetposition = (target_position_set_z_0 - transform.position);
        targetposition.Normalize();
    }

    
}