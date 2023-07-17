using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeWizard : MonoBehaviour
{
    public Rigidbody2D WizardBody;
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
        WizardBody.constraints = RigidbodyConstraints2D.None;  //let the body move again
    }
}
