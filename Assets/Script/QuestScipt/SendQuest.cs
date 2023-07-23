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
            // Check if both quest2 and key102 are true
          /*  if (QuestManager.quest2 == true )
            {
               
                QuestManager.quest2Completion = true;
                
             
            }*/
        }
    }                   

               

    private void Update()
    {
        // Check if the player is pressing the "E" key
       /* if (Input.GetKeyDown(KeyCode.E)&&QuestManager.quest3)
        {
            // Set quest3Completion to true
            QuestManager.quest3Completion = true;
          

        }*/
       
    }
}