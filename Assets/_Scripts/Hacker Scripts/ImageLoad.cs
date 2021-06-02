using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoad : MonoBehaviour
{
    public GameObject rotatePuzzle;
    public GameObject dragDrop;
    public GameObject keypad;

    public GameObject rotatebutton;
    public GameObject dragButton;
    public GameObject keypadButton;

    public void OpenRotatePuzzle()
    {
        if (rotatePuzzle != null)
        {
            bool isActive = rotatePuzzle.activeSelf;

            rotatePuzzle.SetActive(!isActive);
            //dragButton.SetActive(!isActive);
        }
    }

    public void OpenDragPuzzle()
    {
        if (dragDrop != null)
        {
            bool isActive = dragDrop.activeSelf;

            dragDrop.SetActive(!isActive);
        }
    }

    public void OpenKeypad ()
    {
        if (keypad != null)
        {
            bool isActive = keypad.activeSelf;

            keypad.SetActive(!isActive);
        }
    }
}
