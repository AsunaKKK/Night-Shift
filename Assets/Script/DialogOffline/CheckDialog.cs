using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDialog : MonoBehaviour
{
    public GameObject showDialog;

    private void Start()
    {
        showDialog.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KPlayer")
        {
            showDialog.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "KPlayer")
        {
            showDialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "KPlayer")
        {
            showDialog.SetActive(false);
        }
    }
}
