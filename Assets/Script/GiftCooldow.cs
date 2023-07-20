using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCooldow : MonoBehaviour
{
    public GameObject gift;
    bool giftCheck = false;
    private float giftTimer = 0f;
    private float timeLimit = 1f;

    private void Update()
    {
        giftTimer += Time.deltaTime; 
        if(giftTimer >= timeLimit)
        {
            giftTimer = 0f;
            gift.SetActive(false);
        }
    }
}
