using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotate : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!PuzzleManager.puzzleComplete)
            transform.Rotate(0f, 0f, 90f);
    }
}
