using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    //public Button button;
    public RectTransform uiElement;
    public float xOffset;
    public float yOffset;

    public float _xOffset;
    public float _yOffset;

    public bool _isDragging = true;


    //Set Button
    void Start()
    {
        //button.onClick.AddListener(MoveElement);
    }

    //Move Mini Map Come Show
    public void MoveElement()
    {
        if(_isDragging)
        {
            Vector2 currentPosition = uiElement.anchoredPosition;
            uiElement.anchoredPosition = new Vector2(currentPosition.x + xOffset, currentPosition.y + yOffset);
            Time.timeScale = 0;
            _isDragging = false;
        }
        
    }
    // Move Mini Map Out
    public void ResetMove()
    {
        if(!_isDragging)
        {
            Vector2 currentPosition = uiElement.anchoredPosition;
            uiElement.anchoredPosition = new Vector2(currentPosition.x + _xOffset, currentPosition.y + _yOffset);
            Time.timeScale = 1;
            _isDragging = true;
        }
    }
}
