using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    [field: TextArea]
    public string[] line;

    public float textSpeed;
    public GameObject obj;
    public GameObject interfaceFace;

    public GameObject charecterTalk1;
    public GameObject charecterTalk2;
    
    public GameObject nameTalk;
    public GameObject nameTalk2;
    public bool[] boolArray;

   public PlayerController playerController;


  

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            StartDialogue();
            interfaceFace.SetActive(false);
            nameTalk.SetActive(true);
            nameTalk2.SetActive(false);
        }
    }

        // Update is called once per frame
        void Update()
    {
        playerController.ToggleMovement(false);
        charecterTalk1.SetActive(true);
        charecterTalk2.SetActive(true);

        if (Input.GetMouseButtonDown(0))
            if (textComponent.text == line[index])
            {
                nameTalk.SetActive(true);
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
        playerController.ToggleMovement(false);

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

            // Check the value of boolArray at the current index
            if (boolArray[index])
            {
                charecterTalk1.GetComponent<Image>().color = Color.gray;
                charecterTalk2.GetComponent<Image>().color = Color.white; 
                nameTalk.SetActive(false);
                nameTalk2.SetActive(true);
            }
            else
            {
                charecterTalk1.GetComponent<Image>().color = Color.white; 
                charecterTalk2.GetComponent<Image>().color = Color.gray;
                nameTalk.SetActive(true);
                nameTalk2.SetActive(false);
            }
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
            playerController.ToggleMovement(true);
            foreach (char c in line[index].ToCharArray())
            {
                textComponent.text += c;
            }
        }
    }

}