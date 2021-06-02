using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeOpen : MonoBehaviour
{

    public ButtonPress Key;
    public GameObject winScreen;

    private void Start()
    {
        Key = FindObjectOfType<ButtonPress>();
        winScreen.gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
       if (ButtonPress.hasKey == true)
        {
            Debug.Log("safe open");
            winScreen.gameObject.SetActive(true);
        }
    }

}
