using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoad : MonoBehaviour
{
    public GameObject rotatePuzzle;
    public GameObject dragDrop;
    public GameObject keypad;
  
    void Start()
    {
        rotatePuzzle.SetActive(false);
        dragDrop.SetActive(false);
        keypad.SetActive(false);
    }


    private void OnMouseDown()
    {
        rotatePuzzle.SetActive(true);
        dragDrop.SetActive(true);
        keypad.SetActive(true);
    }
}
