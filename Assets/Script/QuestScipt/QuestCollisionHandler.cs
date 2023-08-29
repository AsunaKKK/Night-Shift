using UnityEngine;
using System.Collections.Generic;

public class QuestCollisionHandler : MonoBehaviour
{
    private Completion completionScript;
    public bool chack101;
    public bool chack102;
    public bool chack103;
    public bool chack104;
    public bool chack105;
    public bool chack106;
    public bool chack107;
    public bool chack108;
    public bool chack109;
    public bool chack110;
    private void Start()
    {
        // Get the Completion component on the same GameObject
        completionScript = FindObjectOfType<Completion>();
    }
    private void Update()
    {
        foreach (GameObject questObject in completionScript.chackOj)
        {

            if (QuestManager.questID == 2)
            {                
                    if (questObject.name == "quest101")
                    {
                        questObject.SetActive(true);
                        chack101 = true;
                    break;

                }
                
            }
            if (QuestManager.questID == 4)
            {             
                    if (questObject.name == "quest102")
                    {
                        questObject.SetActive(true);
                        chack102 = true;
                    break;

                }               
            }
            if (QuestManager.questID == 5)
            {
                
                    if (questObject.name == "quest103")
                    {
                        questObject.SetActive(true);
                        chack103 = true;
                    break;

                }              
            }
            if (QuestManager.questID == 6)
            {              
                    if (questObject.name == "quest104")
                    {
                        questObject.SetActive(true);
                        chack104 =true;
                    break;

                }                
            }
            if (QuestManager.questID == 11)
            {               
                
                    if (questObject.name == "quest105")
                    {
                        questObject.SetActive(true);
                        chack105 = true;
                    break;

                }               
            }
            if (QuestManager.questID == 12)
            {              
                    if (questObject.name == "quest106")
                    {
                        questObject.SetActive(true);
                        chack106 =true;
                    break;
                }
                
            }
            if (QuestManager.questID == 13)
            {  
                    if (questObject.name == "quest107")
                    {
                        questObject.SetActive(true);
                        chack107 = true;
                    break;
                }
                
            }
            if (QuestManager.questID == 14)
            {            
                    if (questObject.name == "quest108")
                    {
                        questObject.SetActive(true);
                        chack108 = true;
                    break;
                }              
            }
            if (QuestManager.questID == 17)
            {             
                    if (questObject.name == "quest109")
                    {
                        questObject.SetActive(true);
                        chack109 = true;
                    break;
                }
                
            }
            if (QuestManager.questID == 19)
            {
               
                    if (questObject.name == "quest110")
                    {
                        questObject.SetActive(true);
                        chack110 = true;
                        break;
                    }
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.CompareTag("Player"))
            {
             foreach (GameObject obj in completionScript.chackOj)
               {
                if (chack101)
                {

                    if (obj.name == "quest101")
                    {
                        QuestManager.quest2Completion = true;
                        obj.SetActive(false);
                        break;

                    }
                    

                }


                if (chack102)
                {



                    if (obj.name == "quest102")
                    {
                        QuestManager.quest4Completion = true;
                        obj.SetActive(false);
                        break;
                    }

                }

                if (chack103)
                {


                    if (obj.name == "quest103")
                    {

                        QuestManager.quest5Completion = true;
                        obj.SetActive(false);
                        break;
                    }

                }

                if (chack104)
                {


                    if (obj.name == "quest104")
                    {
                        QuestManager.quest6Completion = true;
                        obj.SetActive(false);
                        break;
                    }

                }
                if (chack105)
                {



                    if (obj.name == "quest105")
                    {
                        QuestManager.quest11Completion = true;
                        obj.SetActive(false);
                        break ;
                    }

                }
                if (chack106)
                {
                    if (obj.name == "quest106")
                    {

                        Enemy_Controller.isChasingPlayer = false;
                        QuestManager.quest12Completion = true;
                        obj.SetActive(false);
                        break;

                    }

                }
                if (chack107)
                {
                    if (obj.name == "quest107")
                    {

                        QuestManager.quest13Completion = true;
                        obj.SetActive(false);
                        break;

                    }

                }
                if (chack108)
                {
                    if (obj.name == "quest108")
                    {

                        QuestManager.quest14Completion = true;
                        obj.SetActive(false);
                        break;

                    }
                }
                if (chack109)
                {
                    if (obj.name == "quest109")
                    {

                        QuestManager.quest17Completion = true;
                        obj.SetActive(false);
                        break;

                    }

                }
                if (chack110)
                {
                    if (obj.name == "quest110")
                    {

                        QuestManager.quest19Completion = true;
                        obj.SetActive(false);

                        break;
                    }
                }
             }


            }
    }
    

}