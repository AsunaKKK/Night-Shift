using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SendQuest : MonoBehaviour
{
    private LockDoor lockDoorScript;
    public TextMeshProUGUI textNoItem;
    public TextMeshProUGUI textItem;

    private void Start()
    {
        lockDoorScript = FindObjectOfType<LockDoor>();
        textNoItem.gameObject.SetActive(false);
        textItem.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //if no item
            if(Input.GetKey(KeyCode.E) && lockDoorScript.electricFuse == false)
            {
                StartCoroutine(GiftItem());
            }
            // Check if the player has pressed the E key and has the electricFuse
            if (Input.GetKey(KeyCode.E) && lockDoorScript.electricFuse)
            {
                QuestManager.quest10Completion = true;
                StartCoroutine(UseItem());
            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper1)
            {
                QuestManager.quest20Completion = true;
                StartCoroutine(UseItem());

            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper2)
            {
                QuestManager.quest21Completion = true;
                StartCoroutine(UseItem());

            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper3)
            {
                QuestManager.quest22Completion = true;
                StartCoroutine(UseItem());

            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper4)
            {
                QuestManager.quest23Completion = true;
                StartCoroutine(UseItem());

            }
            if (Input.GetKey(KeyCode.E) && lockDoorScript.talisManpaper5)
            {
                QuestManager.quest24Completion = true;
                StartCoroutine(UseItem());
            }
        }
    }

    IEnumerator GiftItem()
    {
        textNoItem.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        textNoItem.gameObject.SetActive(false);
    }
    IEnumerator UseItem()
    {
        textItem.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        textItem.gameObject.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            textNoItem.gameObject.SetActive(false);
        }
    }
}