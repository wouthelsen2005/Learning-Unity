using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] muisicObj = GameObject.FindGameObjectsWithTag("Musicplayer");
        if(muisicObj.Length > 1)
        {
           
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        
    }

}
