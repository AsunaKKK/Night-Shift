using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoditionPlayTag : MonoBehaviour
{
    private int initialOrder;
    private SpriteRenderer spriteRenderer;

    public GameObject box1;
    public GameObject box2;
    public GameObject symo;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialOrder = spriteRenderer.sortingOrder;
        box1.SetActive(false);
        box2.SetActive(false);
        symo.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        symo.SetActive(true);
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            ToggleTag(collision.gameObject);
            initialOrder = 11;
            box1.SetActive(true);
            box2.SetActive(true);
            symo.SetActive(false);
        }
        spriteRenderer.sortingOrder = initialOrder;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        symo.SetActive(true);
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            ToggleTag(collision.gameObject);
            initialOrder = 11;
            box1.SetActive(true);
            box2.SetActive(true);
            symo.SetActive(false);
        }
        else if (collision.CompareTag("Hidden") && Input.GetKey(KeyCode.E))
        {
            ToggleTag(collision.gameObject);
            initialOrder = 0;
            box1.SetActive(false);
            box2.SetActive(false);
        }
        spriteRenderer.sortingOrder = initialOrder;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        symo.SetActive(false);
    }

    private void ToggleTag(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            obj.tag = "Hidden";
        }
        else if (obj.CompareTag("Hidden"))
        {
            obj.tag = "Player";
        }
    }
    
   
}