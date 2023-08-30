using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public GameObject smyDoor;
    public Image blackImageFade;
    public float fadeDuration = 1.0f;
    private bool isFading = false;
    public TextMeshProUGUI textFade;
    public AudioSource fadeSource;

    private void Start()
    {
        smyDoor.SetActive(false);
        textFade.alpha = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KPlayer")
        {
            smyDoor.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "KPlayer")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if(!isFading)
                {
                    StartCoroutine(FadeInAndStartAction(ChangScenes));
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "KPlayer")
        {
            smyDoor.SetActive(false);
        }
    }
    private IEnumerator FadeInAndStartAction(System.Action action)
    {
        isFading = true;
        fadeSource.Play();
        yield return StartCoroutine(Fade(0, 1)); // Fade in
        textFade.alpha = 1;

        action.Invoke();

        //yield return StartCoroutine(Fade(1, 0)); // Fade out

        isFading = false;
    }

    private void ChangScenes()
    {
        SceneManager.LoadSceneAsync("Scene01");
        SaveManager.instance.NewGame();
    }
    private IEnumerator Fade(float startOpacity, float targetOpacity)
    {
        Color color = blackImageFade.color;
        color.a = startOpacity;
        blackImageFade.color = color;

        Color textMeshProColor = textFade.color;
        textMeshProColor.a = startOpacity;
        textFade.color = textMeshProColor;

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;

            color.a = Mathf.Lerp(startOpacity, targetOpacity, normalizedTime);
            blackImageFade.color = color;

            textMeshProColor.a = Mathf.Lerp(startOpacity, targetOpacity, normalizedTime);
            textFade.color = textMeshProColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = targetOpacity;
        blackImageFade.color = color;

        textMeshProColor.a = targetOpacity;
        textFade.color = textMeshProColor;
    }

}
