using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    [HideInInspector]
    public bool hasKey = false;
    private void OnMouseDown()
    {
        hasKey = true;
        Debug.Log("picked up key");
    }

}
