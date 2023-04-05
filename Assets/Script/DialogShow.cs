using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogShow : MonoBehaviour
{
    public GameObject dialogShow;
    // Start is called before the first frame update
    void Start()
    {
        dialogShow.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogShow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogShow.SetActive(false);
        }
    }

}
