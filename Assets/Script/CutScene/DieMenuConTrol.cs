using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DieMenuConTrol : MonoBehaviour
{
    public Image imageClick;
    public float fadeDuration = 1.0f;
    public TextMeshProUGUI textBlack;
    private bool isFading = false;

    private void Start()
    {
        textBlack.alpha = 0;
    }

    public void BlackHomesClick()
    {
        if (!isFading)
        {
            StartCoroutine(FadeInAndStartAction(BlackHome));
        }
    }

    public void ContinueGameClick()
    {
        if (!isFading)
        {
            StartCoroutine(FadeInAndStartAction(ContinueGame));
        }
    }

    private IEnumerator FadeInAndStartAction(System.Action action)
    {
        isFading = true;

        yield return StartCoroutine(Fade(0, 1)); // Fade in
        textBlack.alpha = 1;
        action.Invoke();

        isFading = false;
    }

    private void BlackHome()
    {
        SceneManager.LoadSceneAsync("Scene00");
    }

    private void ContinueGame()
    {
        Debug.Log("Continue Game");
        SaveManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Scene01");
    }

    private void Exit()
    {
        Application.Quit();
    }

    private IEnumerator Fade(float startOpacity, float targetOpacity)
    {
        Color color = imageClick.color;
        color.a = startOpacity;
        imageClick.color = color;

        Color textMeshProColor = textBlack.color;
        textMeshProColor.a = startOpacity;
        textBlack.color = textMeshProColor;

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;

            color.a = Mathf.Lerp(startOpacity, targetOpacity, elapsedTime / fadeDuration);
            imageClick.color = color;

            textMeshProColor.a = Mathf.Lerp(startOpacity, targetOpacity, normalizedTime);
            textBlack.color = textMeshProColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = targetOpacity;
        imageClick.color = color;

        textMeshProColor.a = targetOpacity;
        textBlack.color = textMeshProColor;
    }
}
