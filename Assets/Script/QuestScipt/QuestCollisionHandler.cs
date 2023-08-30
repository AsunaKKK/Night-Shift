using UnityEngine;
using System.Collections.Generic;

public class QuestCollisionHandler : MonoBehaviour , IDataSave
{
    private Completion completionScript;
    public bool chack101 = false;
    public bool chack102 = false;
    public bool chack103 = false;
    public bool chack104 = false;
    public bool chack105 = false;
    public bool chack106 = false;
    public bool chack107 = false;
    public bool chack108 = false;
    public bool chack109 = false;
    public bool chack110 = false;
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

    public void SaveData(GameData data)
    {
        data.chack101 = chack101;
        data.chack102 = chack102;
        data.chack103 = chack103;
        data.chack104 = chack104;
        data.chack105 = chack105;
        data.chack106 = chack106;
        data.chack107 = chack107;
        data.chack108 = chack108;
        data.chack109 = chack109;
        data.chack110 = chack110;

    }

    public void LoadData(GameData data)
    {
        chack101 = data.chack101;
        chack102 = data.chack102;
        chack103 = data.chack103;
        chack104 = data.chack104;
        chack105 = data.chack105;
        chack106 = data.chack106;
        chack107 = data.chack107;
        chack108 = data.chack108;
        chack109 = data.chack109;
        chack110 = data.chack110;

    }


}