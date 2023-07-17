using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fireball_dragon_script : MonoBehaviour
{
    public Animator animator;
    public Vector3 move = new(.001f, 0, 0);
    public float speed = 5;
    public bool alive = true;
    public Material mat;
    public Color _emissionColorValue;
    public float fire_ball_damage = 2;
    public SpriteRenderer image;
    public bool moving = false;
    public Rigidbody2D body;
    public Material fademat;







    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GrowFireBall());
        Material matcop = new Material(Shader.Find("Shader Graphs/glow"));
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        
        //StartCoroutine(GlowFireBall(matcop));//
        matcop.SetColor("_Color", _emissionColorValue * 10000);
        
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moving && alive)
        {
            transform.position += move * speed;

        }

        if ((transform.position.x < -400) && alive)
        {
            alive = false;
            GameObject hpbar = GameObject.Find("hpbarcanvas");
            Slider hpslider = hpbar.GetComponentInChildren<Slider>();
            hpslider.value -= fire_ball_damage;
            
            
            
            
        }
    }

    IEnumerator GlowFireBall(Material math)
    {
        
        
           
         math.SetColor("_Color", _emissionColorValue * 5);


   
        for (float i = 10; i > 0; i -= 0.01f) //start snel met glow en eindig traag
        {

            Debug.Log("test");
            math.SetColor("_Color", _emissionColorValue * i);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator GrowFireBall()
    {
        for (float i = 0; i < 100; i+=1.5f)
        {
            image.transform.localScale = new Vector3(-i, i, 1);
            yield return new WaitForEndOfFrame();

            if (i == 45)
            {
                moving = true;
            }


        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            alive = false;
            GameObject hpbar = GameObject.FindGameObjectWithTag("MainHpBar");
            hpbar.GetComponent<MainHPbar>().currenthp -= 5;
            gameObject.GetComponent<SpriteRenderer>().material = fademat;
            StartCoroutine(fade());

        }
        
    }

    IEnumerator fade()
    {
        for (float i = 1; i>0; i-=0.03f)
        {
            fademat.SetFloat("_Fade", i);
            yield return new WaitForEndOfFrame();
        }         
       
       
        Destroy(gameObject);
    }
}
