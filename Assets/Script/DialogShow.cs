using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogShow : MonoBehaviour
{
    public GameObject smyboolDialogShow;
    public Dialog dialog;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        smyboolDialogShow.SetActive(false);
        dialog.gameObject.SetActive(false);
        obj.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                dialog.gameObject.SetActive(true);
                obj.SetActive(true);
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
