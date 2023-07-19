using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completion : MonoBehaviour
{
    public  GameObject itemQuest1;
    public  GameObject itemQuest2;
    
    private int x = 0;

    void Start()
    {
        itemQuest1.SetActive(false);
        itemQuest2.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        QuestRun();
    }

    public void QuestRun()
    {
        if (QuestManager.quest1 == true)
        {
            itemQuest1.SetActive(true);
            itemQuest2.SetActive(true);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Check which itemQuest has been hit and set its respective boolean to true
            if (collision.gameObject == itemQuest1)
            {
                itemQuest1.SetActive(false);
                itemQuest1Hit = true;
            }
            else if (collision.gameObject == itemQuest2)
            {
                itemQuest2.SetActive(false);
                itemQuest2Hit = true;
            }
        }
    
    }*/
}