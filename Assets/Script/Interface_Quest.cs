using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface_Quest : MonoBehaviour
{
        public Text questItem;
        public Color completedColor;

        public void OnTriggerEnter2D(Collider2D collision)
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
