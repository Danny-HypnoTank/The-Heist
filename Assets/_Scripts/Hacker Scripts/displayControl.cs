using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayControl : MonoBehaviour
{
   
    void Update()
    {
        GetComponent<TextMesh>().text = ButtonPress.playerCode;
    }
}
