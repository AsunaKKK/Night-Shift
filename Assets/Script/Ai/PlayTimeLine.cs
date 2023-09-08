using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PlayTimeLine : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public GameObject imageTimeLine;
   // public GameObject Box;
    public GameObject TimeLine;
    public float changeTime;
    public static bool Go = false;
    public PlayerController playerController;
    private void Start()
    {
        //Box.SetActive(false); 
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerController.ToggleMovement(false);
            timelineDirector.Play();
            //Box.SetActive(true);
        }

    }
    private void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            TimeLine.SetActive(false);
           // Box.SetActive(false);
            timelineDirector.Stop();
            imageTimeLine.SetActive(false);
            timelineDirector.gameObject.SetActive(false);
            Go = true;
            playerController.ToggleMovement(true);
        }
    }
}
