using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeOpen : MonoBehaviour
{

    public ButtonPress Key;
    
    public Sprite safeOpen, safeClose;

    private void Start()
    {
        Key = FindObjectOfType<ButtonPress>();
        
    }
    private void OnMouseDown()
    {
       if (PuzzleManager.gotKey == true)
        {
            Debug.Log("safe open");
            //winScreen.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = safeOpen;
        }
    }

}
