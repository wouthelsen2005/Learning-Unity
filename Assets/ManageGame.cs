using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{

    public int level = 60;
    public int HordeLenght;
    public int HordeWith;
    public int DragonHp;
    public int levelDuration = 60;


    public void Awake()
    {
        SetSettingToLevel();
    }

    public void SetSettingToLevel()
    {
        level = PlayerPrefs.GetInt("level");
        if (level < 5)
        {
            HordeLenght = 2;
            PlayerPrefs.SetInt("HordeLenght", HordeLenght);
            HordeWith = 1;
            PlayerPrefs.SetInt("HordeWith", HordeWith);
            DragonHp = 20;
            PlayerPrefs.SetInt("DragonHp", DragonHp);


        }
        else if (level < 100)
        {
            HordeLenght = 9;
            PlayerPrefs.SetInt("HordeLenght", HordeLenght);
            HordeWith = 4;
            PlayerPrefs.SetInt("HordeWith", HordeWith);
            DragonHp = 100;
            PlayerPrefs.SetInt("DragonHp", DragonHp);


        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
}
