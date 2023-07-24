using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogShow : MonoBehaviour
{
    public GameObject smyboolDialogShow;
    public Dialog dialog;
    public bool showDialog = false;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        smyboolDialogShow.SetActive(false);
        dialog.gameObject.SetActive(false);
        obj.SetActive(false);
    }
    private void Update()
    {
        if(showDialog)
        {
            dialog.gameObject.SetActive(true);
        }
        else
        {
            dialog.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E)&&QuestManager.quest7)
            {
               
                
                    showDialog = true;
                    obj.SetActive(true);
                    QuestManager.quest7Completion = true;
                
            }
            if (Input.GetKey(KeyCode.E) && QuestManager.quest15)
            {


                
                QuestManager.quest15Completion = true;

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            smyboolDialogShow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            smyboolDialogShow.SetActive(false);
            dialog.gameObject.SetActive(false);
            obj.SetActive(false);
        }
    }

}
