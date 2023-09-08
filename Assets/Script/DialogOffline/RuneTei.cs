using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTei : MonoBehaviour
{
    public GameObject runeimg;
    public GameObject tei;

    private void Start()
    {
        runeimg.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            runeimg.SetActive(true);
            Destroy(tei);
        }
    }
}
