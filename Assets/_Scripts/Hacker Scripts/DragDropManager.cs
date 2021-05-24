using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDropManager : MonoBehaviour
{
    [SerializeField]
    private Text timer;
    [SerializeField]
    private GameObject timerOBJ;
    [SerializeField]
    private float timeRemaining;
    private float totalTime = 60;
    private bool levelComplete = false;
    public bool levelFail= false;
    [SerializeField]
    private GameObject LoseScreen;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private Text timeRemainingText;

    public GameObject objective;

    public int correctMovements;

    [SerializeField]
    private Text moneyGained;
    private int moneyGainedStage1 = 30;
    private int moneyGainedStage2 = 20;
    private int moneyGainedStage3 = 10;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = totalTime;
        timerOBJ.SetActive(true);
        timer.text = "Time Remaining: " + timeRemaining;
        LoseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        timerOBJ.SetActive(true);
        objective.SetActive(true);
        levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (correctMovements == 5)
        {
            levelComplete = true;
        }

        if (levelComplete == true)
        {
            objective.SetActive(false);
            timerOBJ.SetActive(false);
            winScreen.SetActive(true);
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

        if (levelComplete != true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            timer.text = "Time Remaining: " + timeRemaining.ToString("f0");

            if (timeRemaining <= 0)
            {
                levelFail = true;
                timerOBJ.SetActive(false);
                objective.SetActive(false);
                LoseScreen.SetActive(true);
            }
        }
    }
}
