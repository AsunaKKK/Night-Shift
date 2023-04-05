using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interface_Quest : MonoBehaviour
{
        public Text questItem;
        public Color completedColor;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                FinisQuest();
                Destroy(gameObject);
            }
        }
        void FinisQuest()
        {
            questItem.color = completedColor;
        }
    
}
