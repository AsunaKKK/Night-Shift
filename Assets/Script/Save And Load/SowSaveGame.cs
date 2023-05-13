using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SowSaveGame : MonoBehaviour
{
    public GameObject dialogSave;
    public GameObject showSmybol;


    // Start is called before the first frame update
    void Start()
    {
        dialogSave.SetActive(false);
        showSmybol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            dialogSave.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            showSmybol.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            showSmybol.SetActive(false);
        }
    }

}
