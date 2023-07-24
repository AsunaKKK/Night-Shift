using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendQuest : MonoBehaviour
{
    private LockDoor lockDoorScript;

    private void Start()
    {
        lockDoorScript = FindObjectOfType<LockDoor>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            // Check if the player has pressed the E key and has the electricFuse
            if (Input.GetKeyDown(KeyCode.E) && lockDoorScript.electricFuse)
            {
                QuestManager.quest10Completion = true;
                Debug.Log("Quest 10 completed!");
            }
        }
    }
}