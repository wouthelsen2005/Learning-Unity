using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageData : MonoBehaviour
{
    private float volume;

    public void SaveData()
    {
        SettingsMenu settings = GetComponent<SettingsMenu>();

        PlayerPrefs.SetFloat("MainVolume", 40);

    }
    public void LoadData()
    {
        
    }
        
}
