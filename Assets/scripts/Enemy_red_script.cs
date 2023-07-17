using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_red_script : MonoBehaviour
{
    public Rigidbody2D enemie_red_body;
    private float speed = 1;

    public float MaxHp;
    private float Hp;
  
    public float fire_duration = 3;
    [SerializeField] public healtbar_script healtbar;
    public firescript fire;
    public Freeze_script freeze;
    public Animator enemie_animator;
    public bool attacking = false;
    public GameObject fireball;
    public bool IsFreezed = false;

    






   





    // Start is called before the first frame update
    void Start()
    {
        MaxHp = PlayerPrefs.GetInt("DragonHp");
       

       
        Hp = MaxHp;
        StartCoroutine(shoot_fire_ball());


    }

    // Update is called once per frame
    void Update()
    {





        if (transform.position.x > 100 && IsFreezed == false)
        {
            
            Vector3 position = new Vector3(-speed, 0, 0);
            enemie_red_body.MovePosition(position + transform.position);

        }
        

        if (Hp <= 0)
        {
            
            Destroy(gameObject);

        }

       

        
       


    }
    void OnCollisionEnter2D(Collision2D collision)

    {
        

        if (collision.gameObject.CompareTag("arrow"))

        {
           
            Hp -= collision.gameObject.GetComponent<ArrowScript>().damage;
            healtbar.UpdateHealthBar(Hp);
            





        }

        if (collision.gameObject.CompareTag("fire"))
        {
            Debug.Log("BAM!");
            Hp -= 15;
            healtbar.UpdateHealthBar(Hp);
            fire.gameObject.SetActive(true);
            StartCoroutine(Fire());

           






        }
        

    }

    

    IEnumerator Fire()
    {
        
        for ( int i = 0; i<3; i++)
        {
            
            
            yield return new WaitForSeconds(2);
            Hp -= 1;
            healtbar.UpdateHealthBar(Hp);
        }
        fire.gameObject.SetActive(false);
        
        
    }

    public void freezee()
    {
        enemie_animator.SetBool("IsFreezed", true);
        freeze.gameObject.SetActive(true);
        IsFreezed = true;
        enemie_red_body.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Setattack()
    {
        
        enemie_animator.SetBool("attack", false);

    }
    public void create_fire_ball()
    {
        Vector3 spawnpoint = new(transform.position.x - 25, transform.position.y);
        GameObject fireballl = Instantiate(fireball, spawnpoint, transform.rotation);
    }

    

    IEnumerator shoot_fire_ball()
    {
        while (true)
        {
            if (transform.position.x <= 100 && IsFreezed == false)
            {
                enemie_animator.SetBool("attack", true);
               
                yield return new WaitForSeconds(Random.Range(3,5));
                
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    

}



