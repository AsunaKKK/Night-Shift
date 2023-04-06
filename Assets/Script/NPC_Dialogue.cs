using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NPC_Dialogue : MonoBehaviour
{
    public Dialog dialog;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialog.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialog.gameObject.SetActive(false);
        }
    }
}
