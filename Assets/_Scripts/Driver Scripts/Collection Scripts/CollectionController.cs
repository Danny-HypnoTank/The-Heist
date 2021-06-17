using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text overallTakeText;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private float timeRemaining;
    [SerializeField]
    private GameObject timerOBJ;
    [SerializeField]
    private GameObject objectiveOBJ;
    [SerializeField]
    private GameObject scoreOBJ;
    private bool levelOver;
    private bool levelStart = false;
    [SerializeField]
    private GameObject completionUI;
    [SerializeField]
    private GameObject startUI;

    private int score;

    public int Score { get => score; set => score = value; }
    public bool LevelOver { get => levelOver; set => levelOver = value; }

    private void Start()
    {
        Time.timeScale = 0;
        startUI.SetActive(true);
        timerOBJ.SetActive(false);
        objectiveOBJ.SetActive(false);
        scoreOBJ.SetActive(false);
        levelOver = false;
        levelStart = false;
    }

    public void StartLevel()
    {
        startUI.SetActive(false);
        timerOBJ.SetActive(true);
        objectiveOBJ.SetActive(false);
        scoreOBJ.SetActive(true);
        levelOver = false;
        Time.timeScale = 1;
        levelStart = true;
    }

    private void Update()
    {
        if (levelStart == true)
        {
            scoreText.text = "$: " + score;
            if (levelOver != true)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                timerText.text = timeRemaining.ToString("00");
                if (timeRemaining <= 0)
                {
                    levelOver = true;
                }
            }

            if (levelOver == true)
            {
                timerOBJ.SetActive(false);
                objectiveOBJ.SetActive(false);
                scoreOBJ.SetActive(false);
                completionUI.SetActive(true);
                overallTakeText.text = "Overall Take.....$" + score;
            }
        }
    }

    public void ContinueButton()
    {

    }
}
