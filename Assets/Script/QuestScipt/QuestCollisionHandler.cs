using UnityEngine;
using System.Collections.Generic;

public class QuestCollisionHandler : MonoBehaviour , IDataSave
{
    private Completion completionScript;
    public int chackQuestMain = 1;

    private void Start()
    {
        // Get the Completion component on the same GameObject
        completionScript = FindObjectOfType<Completion>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(chackQuestMain==1)
            {
                if (QuestManager.quest2 && chackQuestMain == 1)
                {
                    // Find the GameObject with the name "quest101" in the list
                    foreach (GameObject obj in completionScript.chackOj)
                    {
                        if (obj.name == "quest101")
                        {
                            // Set quest2Completion to true
                            QuestManager.quest2Completion = true;

                            // Deactivate the "quest101" GameObject
                            obj.SetActive(false);

                            // Set "quest102" to active
                            foreach (GameObject questObject in completionScript.chackOj)
                            {
                                if (questObject.name == "quest102")
                                {
                                    questObject.SetActive(true);
                                    chackQuestMain = 2;
                                    break;
                                }
                            }

                            break;
                        }
                    }
                }
            }
            if(chackQuestMain==2)
            {
                // Check if quest102 is completed before activating quest103
                if (QuestManager.quest4&&chackQuestMain==2)
                {
                    // Find the GameObject with the name "quest102" in the list
                    foreach (GameObject obj in completionScript.chackOj)
                    {
                        if (obj.name == "quest102")
                        {
                            // Set quest4Completion to true
                            QuestManager.quest4Completion = true;

                            // Deactivate the "quest102" GameObject
                            obj.SetActive(false);

                            // Set "quest103" to active
                            foreach (GameObject questObject in completionScript.chackOj)
                            {
                                if (questObject.name == "quest103")
                                {
                                    questObject.SetActive(true);
                                    chackQuestMain = 3;
                                    break;
                                }
                            }

                            break;
                        }
                    }
                }
            }
            if(chackQuestMain==3)
            {
                // Check if quest103 is completed before activating quest104 (if needed)
                if (QuestManager.quest5 && chackQuestMain == 3)
                {
                    // Find the GameObject with the name "quest103" in the list
                    foreach (GameObject obj in completionScript.chackOj)
                    {
                        if (obj.name == "quest103")
                        {
                            // Set quest5Completion to true
                            QuestManager.quest5Completion = true;

                            // Deactivate the "quest103" GameObject
                            obj.SetActive(false);

                            foreach (GameObject questObject in completionScript.chackOj)
                            {
                                if (questObject.name == "quest104")
                                {
                                    questObject.SetActive(true);
                                    chackQuestMain = 4;
                                    break;
                                }
                            }

                            break;
                        }
                    }
                }
            }
            

        

            
            if (QuestManager.quest6)
            {
                // Find the GameObject with the name "quest101" in the list
                foreach (GameObject obj in completionScript.chackOj)
                {
                    if (obj.name == "quest104")
                    {
                        // Set quest2Completion to true
                        QuestManager.quest6Completion = true;

                        // Deactivate the "quest101" GameObject
                        obj.SetActive(false);

                        // Set "quest102" to active
                        foreach (GameObject questObject in completionScript.chackOj)
                        {
                            if (questObject.name == "quest105")
                            {
                                questObject.SetActive(true);
                                break;
                            }
                        }

                        break;
                    }
                }
            }
            if (QuestManager.quest11)
            {
                // Find the GameObject with the name "quest101" in the list
                foreach (GameObject obj in completionScript.chackOj)
                {
                    if (obj.name == "quest105")
                    {
                        // Set quest2Completion to true
                        QuestManager.quest11Completion = true;

                        // Deactivate the "quest101" GameObject
                        obj.SetActive(false);

                        // Set "quest102" to active
                        foreach (GameObject questObject in completionScript.chackOj)
                        {
                            if (questObject.name == "quest106")
                            {
                                questObject.SetActive(true);
                                break;
                            }
                        }

                        break;
                    }
                }
            }
            if (QuestManager.quest12)
            {
                
                foreach (GameObject obj in completionScript.chackOj)
                {
                    if (obj.name == "quest106")
                    {
                        
                        QuestManager.quest12Completion = true;

                        
                        obj.SetActive(false);

                        foreach (GameObject questObject in completionScript.chackOj)
                        {
                            if (questObject.name == "quest107")
                            {
                                questObject.SetActive(true);
                                break;
                            }
                        }

                        break;
                    }
                }
            }
            if (QuestManager.quest13)
            {

                foreach (GameObject obj in completionScript.chackOj)
                {
                    if (obj.name == "quest107")
                    {

                        QuestManager.quest13Completion = true;


                        obj.SetActive(false);

                        foreach (GameObject questObject in completionScript.chackOj)
                        {
                            if (questObject.name == "quest108")
                            {
                                questObject.SetActive(true);
                                break;
                            }
                        }

                        break;
                    }
                }
            }
            if (QuestManager.quest14)
            {

                foreach (GameObject obj in completionScript.chackOj)
                {
                    if (obj.name == "quest108")
                    {

                        QuestManager.quest14Completion = true;


                        obj.SetActive(false);

                        foreach (GameObject questObject in completionScript.chackOj)
                        {
                            if (questObject.name == "quest109")
                            {
                                questObject.SetActive(true);
                                break;
                            }
                        }

                        break;
                    }
                }
            }


        }
    }
    public void SaveData(ref GameData data)
    {
        data.chackQuestId = chackQuestMain;
    }

    public void LoadData(GameData data)
    {
        chackQuestMain = data.chackQuestId;
    }

}