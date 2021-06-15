using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour

{
    [SerializeField]
    private Transform[] pictures;
    [SerializeField]
    private GameObject winText;
    public GameObject Key;

    public static bool puzzleComplete;
    public static bool gotKey;
    public Sprite wallSafe;
    public GameObject[] puzzle;
    private static int length;

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        puzzleComplete = false;
        gotKey = false;
        Key.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pictures[0].rotation.z == 0 &&
            pictures[1].rotation.z == 0 &&
            pictures[2].rotation.z == 0 &&
            pictures[3].rotation.z == 0 &&
            pictures[4].rotation.z == 0 &&
            pictures[5].rotation.z == 0)
        {
            //gotKey = true;
            puzzleComplete = true;
            puzzle[0].SetActive(false);
            puzzle[1].SetActive(false);
            puzzle[2].SetActive(false);
            puzzle[3].SetActive(false);
            puzzle[4].SetActive(false);
            puzzle[5].SetActive(false);
            Key.SetActive(true);
        }
    }
}
