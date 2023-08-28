using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    public bool checkWalls = false;
    public PlayerMap playerMap;

    private void Start()
    {
        playerMap = FindObjectOfType<PlayerMap>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            checkWalls = true;
            playerMap.ToggleMovement(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            checkWalls = true;
            playerMap.ToggleMovement(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            checkWalls = false;
            playerMap.ToggleMovement(true);
        }
    }

}
