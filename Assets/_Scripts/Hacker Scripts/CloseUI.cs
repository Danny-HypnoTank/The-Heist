using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject winUI;
    public GameObject puzzle;

    public void closeUI()
    {
        winUI.SetActive(false);
        puzzle.SetActive(false);
    }
}
