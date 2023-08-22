using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriGerTo : MonoBehaviour
{
    public GameObject TriGer;
    public GameObject objTri;
    private void Start()
    {
        TriGer.SetActive(false);
        objTri.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KPlayer")
        {
            TriGer.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(objTri);
    }
}
