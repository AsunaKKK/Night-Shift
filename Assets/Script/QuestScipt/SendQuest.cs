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
        if (collision.tag == "Player")
        {
            
            // Check if the player has pressed the E key and has the electricFuse
            if (Input.GetKeyDown(KeyCode.E) && lockDoorScript.electricFuse)
            {
                QuestManager.quest10Completion = true;
                Debug.Log("Quest 10 completed!");
            }
            if (Input.GetKeyDown(KeyCode.E) && lockDoorScript.talisManpaper1)
            {
                QuestManager.quest20Completion = true;
              
            }
            if (Input.GetKeyDown(KeyCode.E) && lockDoorScript.talisManpaper2)
            {
                QuestManager.quest21Completion = true;

            }
            if (Input.GetKeyDown(KeyCode.E) && lockDoorScript.talisManpaper3)
            {
                QuestManager.quest22Completion = true;

            }
            if (Input.GetKeyDown(KeyCode.E) && lockDoorScript.talisManpaper4)
            {
                QuestManager.quest23Completion = true;

            }
            if (Input.GetKeyDown(KeyCode.E) && lockDoorScript.talisManpaper5)
            {
                QuestManager.quest24Completion = true;

            }
        }
    }
}