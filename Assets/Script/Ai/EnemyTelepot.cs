using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTelepot : MonoBehaviour
{
    private GameObject currentTeleporter;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
        if (currentTeleporter != null)
        {
            transform.position = currentTeleporter.GetComponent<Telepor>().GetDestination().position;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (currentTeleporter != null)
        {
            transform.position = currentTeleporter.GetComponent<Telepor>().GetDestination().position;
        }
    }
}
