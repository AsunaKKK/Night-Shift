using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource walking;
    public AudioSource runing;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            walking.enabled = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walking.enabled = false;
                runing.enabled = true;
            }
            else
            {
                runing.enabled = false;
            }
        }
        else
        {
            walking.enabled = false;
            runing.enabled = false;
        }
    }
}
