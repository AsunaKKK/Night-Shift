using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImControl : MonoBehaviour
{
    public List<GameObject> imageObject;
    private int currentImageIndex = 0;
    public AudioSource audioNext;
    public GameObject totu;
    public bool checktotu = false;

    private void Start()
    {
        foreach (GameObject obj in imageObject)
        {
            obj.SetActive(false);
        }
        ShowImage(currentImageIndex);
    }

    private void Update()
    {

    }
    public void NextImage()
    {
        imageObject[currentImageIndex].SetActive(false);
        currentImageIndex = (currentImageIndex + 1) % imageObject.Count;
        ShowImage(currentImageIndex);
        audioNext.Play();
    }

    public void PreviousImage()
    {
        imageObject[currentImageIndex].SetActive(false);
        currentImageIndex = (currentImageIndex - 1 + imageObject.Count) % imageObject.Count;
        ShowImage(currentImageIndex);
        audioNext.Play();
    }

    private void ShowImage(int index)
    {
        imageObject[index].SetActive(true);
    }
    public void CloseBout()
    {
        Time.timeScale = 1;
        totu.SetActive(false);

    }
}
