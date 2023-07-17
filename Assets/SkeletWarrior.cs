using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletWarrior : MonoBehaviour
{
    public Rigidbody2D SkeletRigidBody;
    private float speed = 1;
    public float hp = 20;
    public GameObject HpBar;
    public Animator animator;
    public bool IsAlive = true;
    public Collider2D colliderr;
    public FreezeWarrior freeze;
    public bool attacking = false;
    public firescript fire;
    public float HitTimer = 0;
    public bool hitted = false;
 
    






    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive && attacking == false && hitted == false) 
        {

            Vector3 Direction = new(-speed, 0, 0);
            SkeletRigidBody.MovePosition(Direction + transform.position);
          
        }


        if (hp <= 0)
        {
            if (IsAlive)
            {
                if (animator.GetBool("Frozen")) // need to do this bc freezescript is inactive when skeleton not frozen
                {
                    FreezeWarrior WarriorFreezeScript = GetComponentInChildren<FreezeWarrior>();
                    WarriorFreezeScript.animator.SetBool("freeze_end", true);   // destroy ice when skeleton is dead
                }
                
                HitTimer = 0;
                colliderr.enabled = false;
                HpBar.SetActive(false);
                IsAlive = false;
                animator.SetBool("Frozen", false); // end freeze animation 
                animator.SetBool("IsDead", true);

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
        if (collision.gameObject.tag == "arrow")
        {

            hp -= collision.gameObject.GetComponent<ArrowScript>().damage;
            HitTimer = 2;
            Destroy(collision.gameObject);
            //animator.SetBool("isHit", true);  for lightning//
            
            StartCoroutine(KnockBack());






        }

        if (collision.gameObject.tag == "wall" && attacking == false)
        {
            animator.SetBool("isAttack", true);
            attacking = true;

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
        Debug.Log("frozen");
        freeze.gameObject.SetActive(true);

        SkeletRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void DealDmg()
    {
        GameObject hpbar = GameObject.FindGameObjectWithTag("MainHpBar");
        hpbar.GetComponent<MainHPbar>().currenthp -= 2;
        
       
       
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

    public void EndHitAnimation()   
    {
        //animator.SetBool("isHit", false); // for lightning
        //hitted = false;//
       
    }

    public IEnumerator KnockBack()
    {
        hitted = true;
        SkeletRigidBody.velocity = Vector3.zero;
        SkeletRigidBody.AddForce(new Vector2(-1, 0) * 150, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2);

        hitted = false;
    }
}
