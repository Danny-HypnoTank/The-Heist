using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private Text timer;
    [SerializeField]
    private float timeRemaining;
    private float totalTime = 60;
    private bool rotatePuzzle = false;
    private bool dragDrop = false;
    private bool keypad = false;
    private bool puzzlesComplete;
    [SerializeField]
    private GameObject winUI;
    [SerializeField]
    private Text timeRemainingText;
    [SerializeField]
    private GameObject loseUI;
    [SerializeField]
    private GameObject timerOBJ;

    public bool levelFail = false;
    private bool dragDropComplete = false;

    public static bool youWin;

    public GameObject objective;

    public int correctMovements;

    [SerializeField]
    private Text moneyGained;
    private int moneyGainedStage1 = 30;
    private int moneyGainedStage2 = 20;
    private int moneyGainedStage3 = 10;
    
    public GameObject rotatebutton;
    public GameObject dragButton;
    public GameObject keypadButton;
    public GameObject dragDropPuzzle;

    public GameObject rotateWin;
    public GameObject dragDropWin;
    //public GameObject keypadWin;
    public GameObject puzzleButtons;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = totalTime;
        winUI.SetActive(false);
        loseUI.SetActive(false);
        timerOBJ.SetActive(true);
        youWin = false;
        objective.SetActive(true);
        rotateWin.SetActive(false);
        dragDropWin.SetActive(false);
        //keypadWin.SetActive(false);
        puzzleButtons.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzlesComplete != true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            timer.text = "Time Remaining: " + timeRemaining.ToString("f0");
            if (timeRemaining <= 0)
            {
                timerOBJ.SetActive(false);
                loseUI.SetActive(true);
                levelFail = false;
            }
        }

        if (pictures[0].rotation.z == 0 &&
            pictures[1].rotation.z == 0 &&
            pictures[2].rotation.z == 0 &&
            pictures[3].rotation.z == 0)
        {
            rotateWin.SetActive(true);
            rotatePuzzle = true;
        }     

        if (puzzlesComplete == true)
        {
            objective.SetActive(false);
            timerOBJ.SetActive(false);
            winUI.SetActive(true);
            timeRemainingText.text = "Time Completed in:" + ((totalTime - timeRemaining).ToString("f0"));
            if ((totalTime - timeRemaining) <= 10)
            {
                moneyGained.text = "Money gained: " + moneyGainedStage1;
                PlayerPrefs.SetInt("SpendableMoney", moneyGainedStage1);
                PlayerPrefs.SetInt("OffShoreMoney", moneyGainedStage1);
                PlayerPrefs.Save();
            }
            else if ((totalTime - timeRemaining) > 10 && (totalTime - timeRemaining) <= 20)
            {
                moneyGained.text = "Money gained: " + moneyGainedStage2;
                PlayerPrefs.SetInt("SpendableMoney", moneyGainedStage2);
                PlayerPrefs.SetInt("OffShoreMoney", moneyGainedStage2);
                PlayerPrefs.Save();
            }
            else if ((totalTime - timeRemaining) > 20 && (totalTime - timeRemaining) < 60)
            {
                moneyGained.text = "Money gained: " + moneyGainedStage3;
                PlayerPrefs.SetInt("SpendableMoney", moneyGainedStage3);
                PlayerPrefs.SetInt("OffShoreMoney", moneyGainedStage3);
                PlayerPrefs.Save();
            }
        }


        if (correctMovements == 5)
        {
            dragDropComplete = true;
            dragDropWin.SetActive(true);
            dragDropPuzzle.SetActive(false);


        }



    }

}
