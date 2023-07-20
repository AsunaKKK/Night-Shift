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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ItemQuest")
        {
           itemQuest1.SetActive(false);
        }

        if(collision.tag == "ItemQuest")
        {
            itemQuest2.SetActive(false);
        }
    
    }
}