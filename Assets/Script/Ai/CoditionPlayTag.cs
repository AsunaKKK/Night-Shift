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
    [SerializeField] private Animator anim;
    private Collider2D collision;
    bool OK = false;
    public GameObject lightP;
    private void OnEnable()
    {
        anim.SetBool("IsHide", false);
        anim.SetBool("outHide", false);

    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialOrder = spriteRenderer.sortingOrder;
        box1.SetActive(false);
        box2.SetActive(false);
        symo.SetActive(false);
        
    }
    private void Update()
    {
        if(collision != null&&OK)
        {
            if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(playHide());
                lightP.SetActive(false);
                ToggleTag(collision.gameObject);
                initialOrder = 11;
                box1.SetActive(true);
                box2.SetActive(true);
                symo.SetActive(false);
            }
            else if (collision.CompareTag("Hidden") && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(playOutHide());
                lightP.SetActive(true);
                ToggleTag(collision.gameObject);
                initialOrder = 0;
                box1.SetActive(false);
                box2.SetActive(false);
            }
            spriteRenderer.sortingOrder = initialOrder;
        }
    }
    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        collision = otherCollision;
        symo.SetActive(true);
        OK = true;
    }

    private void OnTriggerStay2D(Collider2D otherCollision)
    {
        collision = otherCollision;
        symo.SetActive(true);
        OK = true;
        

    }
    private void OnTriggerExit2D()
    {
        symo.SetActive(false);
        collision = null;
    }


    IEnumerator playHide()
    {
        anim.SetBool("IsHide", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsHide", false);

    }
    IEnumerator playOutHide()
    {
        anim.SetBool("outHide", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("outHide", false);

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