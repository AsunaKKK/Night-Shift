using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public GameObject smyDoor;

    // Start is called before the first frame update
    void Start()
    {
        smyDoor.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KPlayer")
        {
            smyDoor.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "KPlayer")
        {
            if (Input.GetKey(KeyCode.E))
            {
                SaveManager.instance.NewGame();
                SceneManager.LoadSceneAsync("Scene01");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "KPlayer")
        {
            smyDoor.SetActive(false);
        }
    }
}
