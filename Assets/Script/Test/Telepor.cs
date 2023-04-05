using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telepor : MonoBehaviour
{
    [SerializeField] private Transform destination;

    public GameObject smybool;

    private void Start()
    {
        smybool.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            smybool.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            smybool.SetActive(false);
        }
    }

    //Set Value Player
    public Transform GetDestination()
    {
        return destination;
    }
}
