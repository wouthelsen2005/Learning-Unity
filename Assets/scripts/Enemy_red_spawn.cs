using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_red_spawn : MonoBehaviour
{

    public GameObject Enemy_red;
    public Vector3 spawn_pos;
    public Vector3 spawn_pos_horde = new(400, 0);
    private readonly float spawn_timer = 10;
    private float timer = 0;
   
  

    // Start is called before the first frame update
    void Start()
    {
       
        
 
        


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ( timer >= spawn_timer)
        {
          
            horde();
            timer = 0;
        }
    }

    public void horde()
    {
        int beginspawnpos = Random.Range(-300, 100);
        for (int y = 0;  y < PlayerPrefs.GetInt("HordeWith"); y ++)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("HordeLenght") * 60; i += 60)
            {
                Instantiate(Enemy_red, new Vector3(500 + i, spawn_pos_horde.y + y*50 + beginspawnpos, spawn_pos_horde.z), transform.rotation);

            }
        }
    }

   
}
