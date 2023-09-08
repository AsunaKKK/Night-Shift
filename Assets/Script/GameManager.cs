using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pause;
    private GameData gameData;
    [Header("Sound Setting")]
    public AudioMixer soundMixer;
    public AudioMixer effectMixer;

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    private void Start()
    {
        SaveManager.instance.NewGame();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        if (resolution.width == 1920 && resolution.height == 1080)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        AdjustAspectRatio();
    }
    private void AdjustAspectRatio()
    {
        float targetAspect = 16f / 9f; 
        float currentAspect = (float)Screen.width / Screen.height;

        float scaleHeight = currentAspect / targetAspect;

        Camera mainCamera = Camera.main;
        Rect rect = mainCamera.rect;

        if (scaleHeight < 1.0f)
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }

        mainCamera.rect = rect;
    }

    private void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pause.SetActive(true);
            }
        }
    }

    public void OnGame()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pause.SetActive(false);
        }
    }

    public void SetVolumeSound(float volume)
    {
        soundMixer.SetFloat("sVolume", volume);
    }

    public void SetVolumeEffect(float evolume)
    {
        effectMixer.SetFloat("eVolume", evolume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}


