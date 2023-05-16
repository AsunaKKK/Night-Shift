using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSave : MonoBehaviour
{
    public GameObject objSave;
    public GameObject smybool;

    private void Start()
    {
        objSave.SetActive(false);
        smybool.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            smybool.SetActive(true);

            if(Input.GetKey(KeyCode.F))
            {
                objSave.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            smybool.SetActive(false);

        }
    }
}
