using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoad : MonoBehaviour
{
    public GameObject Puzzle;
  
    void Start()
    {
        Puzzle.SetActive(false);
    }


    private void OnMouseDown()
    {
        Puzzle.SetActive(true);
    }
}
