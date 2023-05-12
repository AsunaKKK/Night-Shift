using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text tooltipText;
    private Image myImage;
    private bool isHovering;

    private void Start()
    {
        myImage = GetComponent<Image>();
        myImage.enabled = false;
    }

    public void setTooltip(string DetailItem)
    {
        if (DetailItem.Length > 0)
        {
            isHovering = true;
            tooltipText.text = DetailItem;
            myImage.enabled = true;
        }
        else
        {
            tooltipText.text = string.Empty;
            myImage.enabled = false;
            isHovering = false;
        }
    }

    private void Update()
    {
        if (isHovering)
        {
            transform.position = Input.mousePosition;
        }
    }
}
