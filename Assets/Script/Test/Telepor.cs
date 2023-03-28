using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telepor : MonoBehaviour
{
    [SerializeField] private Transform destination;

    //Set Value Player
    public Transform GetDestination()
    {
        return destination;
    }
}
