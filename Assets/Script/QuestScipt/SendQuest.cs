using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SendQuest : MonoBehaviour
{
    private LockDoor lockDoorScript;
    public GameObject textNoItem;

    private void Start()
    {
        lockDoorScript = FindObjectOfType<LockDoor>();
        textNoItem.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //if no item
            if(Input.GetKey(KeyCode.E)&& lockDoorScript.electricFuse == false)
            {
                StartCoroutine(GiftItem());
            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper1 == false)
            {
                StartCoroutine(GiftItem());
            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper2 == false)
            {
                StartCoroutine(GiftItem());
            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper3 == false)
            {
                StartCoroutine(GiftItem());
            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper4 == false)
            {
                StartCoroutine(GiftItem());
            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper5 == false)
            {
                StartCoroutine(GiftItem());
            }
            // Check if the player has pressed the E key and has the electricFuse
            if (Input.GetKey(KeyCode.E) && lockDoorScript.electricFuse)
            {
                QuestManager.quest10Completion = true;
                Debug.Log("Quest 10 completed!");
            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper1)
            {
                QuestManager.quest20Completion = true;
              
            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper2)
            {
                QuestManager.quest21Completion = true;

            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper3)
            {
                QuestManager.quest22Completion = true;

            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper4)
            {
                QuestManager.quest23Completion = true;

            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper5)
            {
                QuestManager.quest24Completion = true;

            }
        }
    }

    IEnumerator GiftItem()
    {
        textNoItem.SetActive(true);
        yield return new WaitForSeconds(2f);
        textNoItem.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            textNoItem.SetActive(false);
        }
    }
}