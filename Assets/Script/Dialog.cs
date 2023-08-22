using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    [field: TextArea]
    public string[] line;

    public float textSpeed;
    public GameObject obj;
    public GameObject interfaceFace;

    public GameObject[] nameShow;
  
    
    
    
    public GameObject charecterTalk1;
    public GameObject charecterTalk2;
    public GameObject nameTalk;
    public GameObject nameTalk2;
    

    public PlayerController playerController;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        playerController = FindObjectOfType<PlayerController>();
        interfaceFace.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        charecterTalk1.SetActive(true);
        charecterTalk2.SetActive(true);
        nameTalk.SetActive(true);
        nameTalk2.SetActive(true);

        if (Input.GetMouseButtonDown(0))
            if (textComponent.text == line[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = line[index];
            }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in line[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < line.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            interfaceFace.SetActive(true);
            charecterTalk1.SetActive(false);
            charecterTalk2.SetActive(false);
            nameTalk.SetActive(false);
            nameTalk2.SetActive(false);
            obj.SetActive(false);
            gameObject.SetActive(false);
            textComponent.text = string.Empty;
            index = 0;

            foreach (char c in line[index].ToCharArray())
            {
                textComponent.text += c;
            }
        }
    }

}