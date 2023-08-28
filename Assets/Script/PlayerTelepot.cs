using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTelepot : MonoBehaviour
{
    private GameObject currentTeleporter;
    public Image blackImgTeleport;
    public bool openDoor = false;

    private bool isFading;
    private bool hasChangedTag = false;

    public AudioSource soundOpenDoor;

    private void Start()
    {
        SetOpacity(0f);
        blackImgTeleport.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Enemy_Controller.isChasingPlayer)
        {
            openDoor = true;
        }
        else
        {
            openDoor = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Telepor>().GetDestination().position;
                soundOpenDoor.Play();

                StartCoroutine(FadeOut());

               
                if (!hasChangedTag && openDoor)
                {
                    currentTeleporter.gameObject.tag = "EnemyTele";
                    hasChangedTag = true;
                    Debug.Log("Tag changed to EnemyTele.");
                }
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
        float duration = 0.7f;
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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
                hasChangedTag = false;
            }
        }
    }
}