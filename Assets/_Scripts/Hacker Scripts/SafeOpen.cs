using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeOpen : MonoBehaviour
{

    public ButtonPress Key;

    private void Start()
    {
        Key = FindObjectOfType<ButtonPress>();
    }
    private void OnMouseDown()
    {
       if (ButtonPress.hasKey == true)
        {
            Debug.Log("safe open");
        }
    }

}
