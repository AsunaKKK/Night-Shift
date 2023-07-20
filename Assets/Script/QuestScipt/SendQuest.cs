using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendQuest : MonoBehaviour
{
    // Reference to the LockDoor script
    public LockDoor lockDoorScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (QuestManager.quest2 == true && LockDoor.key102 == true)
            {
                
                QuestManager.quest2Completion = true;
            }
        }
    }
}