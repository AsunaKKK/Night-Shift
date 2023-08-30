using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViroDialogShow : MonoBehaviour
{
    public GameObject smyboolDialogShow;
    public DialogK dialog;
    public bool showDialog = false;
    public GameObject obj;
    public GameObject doorOpen;

    public Image blackImage;
    public float fadeDuration = 15f;
    // Start is called before the first frame update
    void Start()
    {
        smyboolDialogShow.SetActive(false);
        dialog.gameObject.SetActive(false);
        obj.SetActive(false);
        doorOpen.SetActive(false);
        StartCoroutine(Fade(1, 0));
    }
    private void Update()
    {
        if (showDialog)
        {
            dialog.gameObject.SetActive(true);
        }
        else
        {
            dialog.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "KPlayer")
        {
            if (Input.GetKey(KeyCode.E))
            {
                showDialog = true;
                obj.SetActive(true);
                doorOpen.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KPlayer")
        {
            smyboolDialogShow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "KPlayer")
        {
            smyboolDialogShow.SetActive(false);
            dialog.gameObject.SetActive(false);
            obj.SetActive(false);
        }
    }
    private IEnumerator Fade(float startOpacity, float targetOpacity)
    {
        Color color = blackImage.color;
        color.a = startOpacity;
        blackImage.color = color;

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(startOpacity, targetOpacity, elapsedTime / fadeDuration);
            blackImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = targetOpacity;
        blackImage.color = color;
    }
}
