using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("Settings")]
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    [Header(":fe")]
    public Dropdown resolutionDropFown;
    [Header("SaveComponent")]
    public Slider volumeSlider;
    public Dropdown graphDropDown;
    public Dropdown resolutionDropDown;
    public Button PlayWithoutCutSceneBtn;

    private void Start()
    {
        if (PlayerPrefs.GetInt("PlayWithoutCutSceneBtn") == 0)
        {
            PlayWithoutCutSceneBtn.interactable = false;
        }
        resolutions = Screen.resolutions;

        resolutionDropFown.ClearOptions();
        List<string> options = new List<string>();

        int indexResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                indexResolution = i;
            }
        }
        resolutionDropFown.AddOptions(options);
        resolutionDropFown.value = indexResolution;
        resolutionDropFown.RefreshShownValue();
        DefoultSettings();
    }
    private void Update()
    {
    }
    #region Btn
    public void PlayBtn()
    {
        SceneManager.LoadScene("FirstScene");
    }
    public void PlayWithoutCutSceneBtnMethod()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void SettingBtn()
    {
        
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    #endregion
    #region Settings
    private int _SetresolutionIndex
    {
        get
        {
            return PlayerPrefs.GetInt("SetresolutionIndex");
        }
        set
        {
            PlayerPrefs.SetInt("SetresolutionIndex",value);
        }
    }
    private float _Setvolume
    {
        get
        {
            return PlayerPrefs.GetFloat("Setvolume");
        }
        set
        {
            PlayerPrefs.SetFloat("Setvolume", value);
            Debug.Log(value);
        }
    }
    private int _Setquality
    {
        get
        {
            return PlayerPrefs.GetInt("Setquality");
        }
        set
        {
            PlayerPrefs.SetInt("Setquality", value);
        }
    }
    private void DefoultSettings()
    {
        Setresolution(_SetresolutionIndex);
        SetValue(_Setvolume);
        SetQuality(_Setquality);
        volumeSlider.value = _Setvolume;
        graphDropDown.value = _Setquality;
        resolutionDropDown.value = _SetresolutionIndex;
    }
    public void Setresolution(int index)
    {
        Resolution resolution = this.resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
        _SetresolutionIndex = index;
    }
    public void SetValue(float value)
    {
        audioMixer.SetFloat("volume", value);
        _Setvolume = value;
    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        _Setquality = index;
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; 
    }
    #endregion
}
