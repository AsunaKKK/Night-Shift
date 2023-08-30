using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriGerTo : MonoBehaviour
{
    public GameObject TriGer;
    public GameObject objTri;

    public KconrollerOutDoor player;
    private void Start()
    {
        TriGer.SetActive(false);
        objTri.SetActive(true);
        player = FindObjectOfType<KconrollerOutDoor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KPlayer")
        {
            TriGer.SetActive(true);
            Time.timeScale = 0;
            player.CanMoveK(false);
        }
    }

    public void Cloes()
    {
        player.CanMoveK(true);
        TriGer.SetActive(false);
    }
}
