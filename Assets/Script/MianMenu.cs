using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MianMenu : MonoBehaviour
{
    [Header("Menu Bottons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button exitGameButton;

    private void Start()
    {
        if(!SaveManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }
    public void NewGameClicked()
    {
        DisableMenuButtons();
        Debug.Log("New Game");
        SaveManager.instance.NewGame();
        SceneManager.LoadSceneAsync("CutScene");
    }
    public void LoadGameClik()
    {
        DisableMenuButtons();
        Debug.Log("Continue Game");
        //SaveManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Scene01");

    }

    public void ExitGame()
    {
        DisableMenuButtons();
        Application.Quit();
    }
    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
        exitGameButton.interactable = false;
    }
}
