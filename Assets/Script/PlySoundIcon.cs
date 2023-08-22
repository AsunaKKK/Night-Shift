using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlySoundIcon : MonoBehaviour
{
    public AudioSource soundMap;
    public AudioSource soundInventory;
    public AudioSource soundInventoryQuest;
    public AudioSource soundClos;
    public AudioSource soundSave;
    public AudioSource soundCilk;

    public void PlySoundMap()
    {
        soundMap.Play();
    }
    public void PlySoundInventory()
    {
        soundInventory.Play();
    }
    public void PlySoundInventoryQuest()
    {
        soundInventoryQuest.Play();
    }
    public void PlySoundClos()
    {
        soundClos.Play();
    }
    public void PlySoundSave()
    {
        soundSave.Play();
    }
    public void PlySoundCilk()
    {
        soundCilk.Play();
    }
}
