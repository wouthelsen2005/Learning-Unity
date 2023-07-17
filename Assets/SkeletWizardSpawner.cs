using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletWizardSpawner : MonoBehaviour
{
    private float SpawnTime = 8;
    float timer;
    public GameObject SkeletWizard;
    public Vector3 spawn_pos_horde = new(400, 0);

    // Start is called before the first frame update
    void Start()
    {
        horde();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > SpawnTime)
        {
            timer = 0;
            horde();

        }
        

    }

    public void horde()
    {
        int beginspawnpos = Random.Range(-300, 100);
        for (int y = 0; y < PlayerPrefs.GetInt("HordeWith"); y++)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("HordeLenght") * 60; i += 60)
            {
                GameObject SkeletWizardClone = Instantiate(SkeletWizard, new Vector3(500 + i, spawn_pos_horde.y + y * 50 + beginspawnpos, spawn_pos_horde.z), transform.rotation);
                if (SkeletWizardClone.transform.position.y > 200 || SkeletWizardClone.transform.position.y < -200)
                {
                    Destroy(SkeletWizardClone);
                }

            }
        }
    }
}
