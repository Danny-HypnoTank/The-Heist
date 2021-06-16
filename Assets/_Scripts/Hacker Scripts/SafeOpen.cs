using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeOpen : MonoBehaviour
{

    public ButtonPress Key;
    
    public Sprite safeOpen, safeClose;
    public static bool isOpen;

    private void Start()
    {
        Key = FindObjectOfType<ButtonPress>();
        isOpen = false;
        
    }
    private void OnMouseDown()
    {
       if (PuzzleManager.gotKey == true)
        {
            Debug.Log("safe open");
            //winScreen.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = safeOpen;
            isOpen = true;
        }
    }

}
