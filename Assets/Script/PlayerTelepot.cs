using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTelepot : MonoBehaviour
{
    private GameObject currentTeleporter;
    public Image blackImgTeleport;

    private bool isFading;

    private void Start()
    {
        SetOpacity(0f);
        blackImgTeleport.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Telepor>().GetDestination().position;

                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        if (isFading)
            yield break;

        blackImgTeleport.gameObject.SetActive(true);
        isFading = true;
        SetOpacity(1f);


        yield return new WaitForSeconds(0.1f); 
        float duration = 1f;
        float elapsedTime = 0f;
        float startOpacity = 1f;
        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(startOpacity, 0f, elapsedTime / duration);
            SetOpacity(alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetOpacity(0f);
        blackImgTeleport.gameObject.SetActive(false);
        isFading = false;
    }

    public void SetOpacity(float opacity)
    {
        Color color = blackImgTeleport.color;
        color.a = opacity;
        blackImgTeleport.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
        if (Input.GetKeyDown(KeyCode.E) && collision.CompareTag("Teleporter") && Enemy_Controller.isChasingPlayer == true)
        {
            collision.tag = "EnemyTele";
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E)&& collision.CompareTag("Teleporter")&& Enemy_Controller.isChasingPlayer == true)
        {
            collision.tag = "EnemyTele";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
