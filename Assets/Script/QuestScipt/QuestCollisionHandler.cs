using UnityEngine;

public class QuestCollisionHandler : MonoBehaviour
{
    public Completion completionScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Find the GameObject with the name "quest101" in the list
            foreach (GameObject obj in completionScript.chackOj)
            {
                if (obj.name == "quest101" && QuestManager.quest2)
                {
                    // Set quest2Completion to true
                    QuestManager.quest2Completion = true;

                    // Destroy the "quest101" GameObject
                    completionScript.chackOj.Remove(obj);
                    Destroy(obj);
                    

                    
                }
                if (obj.name == "quest102" && QuestManager.quest4)
                {
                    // Set quest2Completion to true
                    QuestManager.quest4Completion = true;

                    // Destroy the "quest101" GameObject
                    completionScript.chackOj.Remove(obj);
                    Destroy(obj);

                   
                }
                break;
            }
        }

        /* private void Update()
         {
             // Check for "F" key press
             if (Input.GetKey(KeyCode.F))
             {
                 // Find the GameObject with the name "quest102" in the list and check and complete the quest
                 GameObject objQuest102 = completionScript.chackOj.Find(obj => obj.name == "quest102");
                 if (objQuest102 != null)
                 {
                     completionScript.CheckAndCompleteQuest("quest102");
                 }
             }
         }*/
    }
}