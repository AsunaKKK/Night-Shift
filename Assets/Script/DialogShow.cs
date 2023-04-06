using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogShow : MonoBehaviour
{
    public GameObject smyboolDialogShow;
    public GameObject dialog;
    // Start is called before the first frame update
    void Start()
    {
        smyboolDialogShow.SetActive(false);
        dialog.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            dialog.SetActive(true);
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
            dialog.SetActive(false);
        }
    }

}
