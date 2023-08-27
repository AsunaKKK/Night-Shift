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
        /*if(gameData == null)
        {
            SaveManager.instance.NewGame();
        }*/

        //SaveManager.instance.LoadGame();
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
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
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


