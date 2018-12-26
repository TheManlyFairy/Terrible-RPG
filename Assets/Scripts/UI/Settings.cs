using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    public static Settings instance;

    Resolution[] screenResolutions;
    [Header("Resolution Settings")]  
    public Dropdown screenResolutionDropDown;
    public int dropDownValue;
    public Toggle fullScreenToggle;
    public bool isFullScreen;
    public List<string> resolutionList;
    
    [Space(10)]
    [Header("Sound Settings")]
    [Range(0, 1)]
    public float musicVolume;
    public Slider musicSlider;
    [Range(0, 1)]
    public float sfxVolume;
    public Slider sfxSlider;
    [Range(0, 1)]
    public float battleVolume;
    public Slider battleSlider;

    void Awake()
    {
        if (instance == null)
            instance = this;

        screenResolutions = Screen.resolutions;
        musicSlider.value = 0.5f;
        musicVolume = musicSlider.value;
        sfxSlider.value = 0.5f;
        sfxVolume = sfxSlider.value;
        battleSlider.value = 0.5f;
        battleVolume = battleSlider.value;
        screenResolutionDropDown.onValueChanged.AddListener(delegate { DropDownValueChange(screenResolutionDropDown); });
        fullScreenToggle.onValueChanged.AddListener(delegate { ToggleValueChanged(fullScreenToggle); });
        fullScreenToggle.isOn = true;
        isFullScreen = fullScreenToggle.isOn;
    }

	// Use this for initialization
	void Start ()
    {
	    foreach(Resolution Res in screenResolutions)
        {
            resolutionList.Add(Res.height + " X " + Res.width);
        }

        screenResolutionDropDown.ClearOptions();
        screenResolutionDropDown.AddOptions(resolutionList);

	}
	
	// Update is called once per frame
	void Update ()
    {
        musicVolume = musicSlider.value;
        sfxVolume = sfxSlider.value;
        battleVolume = battleSlider.value;

        if(dropDownValue != 0)
        ChangeResolutoin(screenResolutions, dropDownValue); 
	}

    void ChangeResolutoin(Resolution[] screenResolutuins, int value)
    {
       Screen.SetResolution(screenResolutions[value].width, screenResolutions[value].height, isFullScreen);
    }

    void DropDownValueChange(Dropdown resolutionDropdown)
    {
        dropDownValue = resolutionDropdown.value;
    }

    void ToggleValueChanged(Toggle fullScreen)
    {
        isFullScreen = fullScreen.isOn;
    }

    
}
