using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_spawn_script : MonoBehaviour
{

    public GameObject arrow;
    public float spawnRate = 2;
    public float timer = 0;
    public float angle;
    public BowScript bow;
    public int damage = 8;
    public int MultiArrow = 3;
    public float BeginArrowSpawn;
    public float EndArrowSpawn;








    // Start is called before the first frame update
    void Start()

    {

        DetermeArrowSpace();

       
        bow.Shoot_animation();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {


            
            

            for (float i = BeginArrowSpawn; i <= EndArrowSpawn; i += 0.04f)
            {
                GameObject arrowobject = Instantiate(arrow, transform.position, transform.rotation);
                ArrowScript arrow_script = arrow.GetComponent<ArrowScript>();
                arrow_script.YVectorChange = i;
            }

            timer = 0;


           

            bow.Shoot_animation();



        }
        

    }

    private void DetermeArrowSpace()
    {
        if (MultiArrow == 2)
        {
            BeginArrowSpawn = -0.02f;
            EndArrowSpawn = 0.02f;
        }

        if (MultiArrow == 3)
        {
            BeginArrowSpawn = -0.04f;
            EndArrowSpawn = 0.04f;
        }

        if (MultiArrow == 4)
        {
            BeginArrowSpawn = -0.06f;
            EndArrowSpawn = 0.06f;
        }
        if (MultiArrow == 5)
        {
            BeginArrowSpawn = -0.08f;
            EndArrowSpawn = 0.08f;
        }
        if (MultiArrow == 6)
        {
            BeginArrowSpawn = -0.1f;
            EndArrowSpawn = 0.1f;
        }

    }
}
