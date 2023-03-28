using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Button button;
    public RectTransform uiElement;
    public float xOffset;
    public float yOffset;

    public float _xOffset;
    public float _yOffset;


    //Set Button
    void Start()
    {
        button.onClick.AddListener(MoveElement);
    }

    //Move Mini Map Come Show
    public void MoveElement()
    {
        Vector2 currentPosition = uiElement.anchoredPosition;
        uiElement.anchoredPosition = new Vector2(currentPosition.x + xOffset, currentPosition.y + yOffset);
    }
    // Move Mini Map Out
    public void ResetMove()
    {
        Vector2 currentPosition = uiElement.anchoredPosition;
        uiElement.anchoredPosition = new Vector2(currentPosition.x + _xOffset, currentPosition.y + _yOffset);
    }
}
