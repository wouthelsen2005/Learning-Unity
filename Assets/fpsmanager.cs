using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsmanager : MonoBehaviour
{
    public int targetFrameRate = 80;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

   

   

}
