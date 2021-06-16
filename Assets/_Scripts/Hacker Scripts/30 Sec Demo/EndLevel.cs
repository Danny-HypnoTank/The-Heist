using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject levelEnd;

    private void Start()
    {
        levelEnd.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log("clicked");
        levelEnd.SetActive(true);
    }
}
