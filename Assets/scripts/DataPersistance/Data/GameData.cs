using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public int hp;
    public Vector3 playerpos;
     


    public GameData()
    {
        this.hp = 5;
        playerpos = Vector3.zero;

    }

    
}
