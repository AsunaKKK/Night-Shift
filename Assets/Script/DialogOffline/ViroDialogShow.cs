using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViroDialogShow : MonoBehaviour
{
    public GameObject smyboolDialogShow;
    public DialogK dialog;
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
        if (showDialog)
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
        if (collision.tag == "KPlayer")
        {
            if (Input.GetKey(KeyCode.E))
            {
                showDialog = true;
                obj.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KPlayer")
        {
            smyboolDialogShow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "KPlayer")
        {
            smyboolDialogShow.SetActive(false);
            dialog.gameObject.SetActive(false);
            obj.SetActive(false);
        }
    }
}
