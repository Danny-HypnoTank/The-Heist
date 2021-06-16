using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject levelEnd;
    public GameObject loseScreen;
    //public GameObject background;

    public float currentTime = 0f;
    public float startingTime = 10f;
    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        winText.SetActive(false);
        puzzleComplete = false;
        gotKey = false;
        Key.SetActive(false);
        levelEnd.SetActive(false);
        loseScreen.SetActive(false);
        //background.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1*  Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            loseScreen.SetActive(true);
            //background.SetActive(true);
        }

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

        if (SafeOpen.isOpen == true)
        {
            levelEnd.SetActive(true);
            
        }
       
    }
}
