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
    public GameObject ques;
    public GameObject itemQuse;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        //itemQuse.SetActive(false);
        //ques.SetActive(false);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
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
            obj.SetActive(false);
            gameObject.SetActive(false);
            textComponent.text = string.Empty;
            index = 0;
            foreach (char c in line[index].ToCharArray())
            {
                textComponent.text += c;
            }

            //ques.SetActive(true);
           // itemQuse.SetActive(true);
        }
    }

}