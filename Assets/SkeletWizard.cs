using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletWizard : MonoBehaviour
{
    public Rigidbody2D SkeletRigidBody;
    private readonly float speed = 1;
    public float hp = 200;
    public GameObject HpBar;
    public Animator animator;
    public bool IsAlive = true;
    public Collider2D colliderr;
    public FreezeWizard freeze;
    public bool attacking = false;
    public GameObject fireball;
    public GameObject MainHpbar;
    public float HitTimer = 0;
    public firescript fire;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive && attacking == false)
        {

            Vector3 Direction = new(-speed, 0, 0);
            SkeletRigidBody.MovePosition(Direction + transform.position);
           
        }
        
        if (transform.position.x <= 100 && attacking == false)
        {
            Debug.Log("attacking...");
            attacking = true;
            animator.SetBool("isAttack", true);

        }

        if (hp <= 0)
        {
            if (IsAlive)
            {
                if (animator.GetBool("Frozen")) // need to do this bc freezescript is inactive when skeleton not frozen
                {
                    FreezeWizard WizardFreezeScript = GetComponentInChildren<FreezeWizard>();
                    WizardFreezeScript.animator.SetBool("freeze_end", true);   // destroy ice when skeleton is dead
                }
               
                HitTimer = 0;
                
                colliderr.enabled = false;
                HpBar.SetActive(false);  // disable hp bar
                IsAlive = false;
                animator.SetBool("Frozen", false); // end freeze animation 
                animator.SetBool("IsDead", true); // start death animation

            }
            
            
           
        }
        if (HitTimer <= 0 && HpBar.activeSelf)
        {
            HitTimer = 0;
            HpBar.SetActive(false);
        }

        if (HitTimer > 0 && !(HpBar.activeSelf))
        {
            HpBar.SetActive(true);
        }

        if (HitTimer > 0)
        {
            HitTimer -= 0.02f;
        }
    } 


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("arrow"))
        {

            hp -= collision.gameObject.GetComponent<ArrowScript>().damage;
            HitTimer = 2;
            Destroy(collision.gameObject);
          
            


        }

        if (collision.gameObject.tag == "fire")
        {
            StartCoroutine(OnFireAnimation());


        }
    }

  

    

    public void DestroyGameObject()
    {
        
        Destroy(gameObject);
    }
    public void freezee()
    {
        animator.SetBool("Frozen", true);
        freeze.gameObject.SetActive(true);

        SkeletRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void PauseAnimation(float value)  // for the void ball the skeleton shoots
    {
        float time = value;
        Vector3 FireBallSpawnPos = new(transform.position.x -15 , transform.position.y + 20, 0);
        if (time == 0.4f)
        {
            Instantiate(fireball, FireBallSpawnPos, transform.rotation);
        }
        
        StartCoroutine(pauseanimation(time));

    }
    IEnumerator pauseanimation(float time) //freeze the skeleton while the void ball is forming
    {
        animator.speed = 0;
        yield return new WaitForSeconds(time);
        animator.speed = 1;
    }

    public IEnumerator OnFireAnimation()
    {
        fire.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        HitTimer = 2;
        hp -= 20;
        yield return new WaitForSeconds(1);
        //StartCoroutine(ShowHp());//
        hp -= 10;
        HitTimer = 2;
        yield return new WaitForSeconds(1);
        fire.gameObject.SetActive(false);

    }

}


