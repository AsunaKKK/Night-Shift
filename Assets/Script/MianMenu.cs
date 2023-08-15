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

    public Image imageClick;
    public float fadeDuration = 1.0f;
    private bool isFading = false;

    private void Start()
    {
        if (!SaveManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }
    public void NewGameClicked()
    {
        if (!isFading)
        {
            StartCoroutine(FadeInAndStartAction(StartNewGame));
        }
    }

    public void LoadGameClick()
    {
        if (!isFading)
        {
            StartCoroutine(FadeInAndStartAction(LoadGame));
        }
    }

    public void ExitGame()
    {
        if (!isFading)
        {
            StartCoroutine(FadeInAndStartAction(Exit));
        }
    }

    private IEnumerator FadeInAndStartAction(System.Action action)
    {
        isFading = true;

        yield return StartCoroutine(Fade(0, 1)); // Fade in

        action.Invoke();

        //yield return StartCoroutine(Fade(1, 0)); // Fade out

        isFading = false;
    }

    private void StartNewGame()
    {
        DisableMenuButtons();
        SaveManager.instance.DeletePallDeta();
        SceneManager.LoadSceneAsync("CutScene");
    }

    private void LoadGame()
    {
        DisableMenuButtons();
        Debug.Log("Continue Game");
        SaveManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Scene01");
    }

    private void Exit()
    {
        DisableMenuButtons();
        Application.Quit();
    }

    private IEnumerator Fade(float startOpacity, float targetOpacity)
    {
        Color color = imageClick.color;
        color.a = startOpacity;
        imageClick.color = color;

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(startOpacity, targetOpacity, elapsedTime / fadeDuration);
            imageClick.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = targetOpacity;
        imageClick.color = color;
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
        exitGameButton.interactable = false;
    }
}
