using UnityEngine;

public class PlayerMapTelepot : MonoBehaviour
{
    private GameObject currentTeleporter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<MapTelepot>().GetDestination().position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MapTeleporter"))
        {
            currentTeleporter = collision.gameObject;
            Debug.Log("PlayerMap at Enter ");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MapTeleporter"))
        {
            currentTeleporter = collision.gameObject;
            Debug.Log("PlayerMap at Stay ");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MapTeleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
