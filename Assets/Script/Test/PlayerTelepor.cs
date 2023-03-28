using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTelepor : MonoBehaviour
{
    private GameObject currentTeleporter;

    void Update()
    {
        // Press E will Telepot
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Telepor>().GetDestination().position;
            }
        }
    }

    //Chack Player 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    // Chack Player Out Door
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
