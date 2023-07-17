using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;





    void Start()
    {

       

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentresindex = 0;
        for (int i = 0; i <resolutions.Length; i++) //Make a list of all the possible resolutions form which the player can select
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentresindex = i;
            }
        }



        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

        Slider volumslider = GetComponentInChildren<Slider>();
        volumslider.value = PlayerPrefs.GetFloat("volume");   //Sett the slider of the volume to the volume of playerprefs


        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityindex")); //Sett the quality to the quality from playerprefs


        qualityDropdown.value = PlayerPrefs.GetInt("qualityindex");  //Sett the quality button correct to the corresponding quality from playerprefs

        Setres(PlayerPrefs.GetInt("resolutionindex")); //Sett the resolution correct to the corresponding resolution from playerprefs

        resolutionDropdown.value = PlayerPrefs.GetInt("resolutionindex"); //Sett the resolution button correct to the corresponding resolution from playerprefs




    }
   
    public void SetVolume(float volume)  //change the mainvolume of the game with the audiomixer
    {
       
        audiomixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
       
    }

    public void SetQuality(int qualityindex)  //change the quality of the game
    {
        QualitySettings.SetQualityLevel(qualityindex);
        PlayerPrefs.SetInt("qualityindex", qualityindex);
       
       
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Setres (int resultionindex)   //change the resolution
    {
        Resolution resolutionn = resolutions[resultionindex];
        
        Screen.SetResolution(resolutionn.width, resolutionn.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolutionindex", resultionindex);
        
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<Audiomanarger>().Play("never gonna");
        }
    }
}
