using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeWarrior : MonoBehaviour
{
    public Rigidbody2D WarriorBody;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);





    }

    void Check()
    {
        FindObjectOfType<Audiomanarger>().Play("ice forming");
        animator.SetBool("Settled", true);
        StartCoroutine(freeze_animation());



    }

    IEnumerator freeze_animation()
    {

        yield return new WaitForSeconds(3);
        animator.SetBool("freeze_end", true);

    }
    void end_freeze()
    {

        gameObject.SetActive(false);
        
        Animator enemieanimator = GetComponentInParent<Animator>();
        enemieanimator.SetBool("Frozen", false);
        FindObjectOfType<Audiomanarger>().Play("ice breaking");
        WarriorBody.constraints = RigidbodyConstraints2D.None;
    }
}
