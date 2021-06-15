using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text scoreTextBackdrop;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text timerTextBackdrop;
    [SerializeField]
    private float timeRemaining;
    [SerializeField]
    private GameObject timerOBJ;
    [SerializeField]
    private GameObject timerBackdropOBJ;
    private bool levelOver;

    private int score;
    private int areaFilled;

    public int Score { get => score; set => score = value; }
    public int AreaFilled { get => areaFilled; set => areaFilled = value; }

    private void Start()
    {
        timerOBJ.SetActive(true);
        timerBackdropOBJ.SetActive(true);
        levelOver = false;
    }

    private void Update()
    {
        scoreText.text = "$: " + score;
        scoreTextBackdrop.text = "$: " + score;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        timerText.text = timeRemaining.ToString("00");
        timerTextBackdrop.text = timeRemaining.ToString("00");
        if (timeRemaining <= 0)
        {
            levelOver = true;
        }

        if (levelOver == true)
        {
            timerOBJ.SetActive(false);
            timerBackdropOBJ.SetActive(false);
            //Complete UI;
        }
        if (areaFilled == 100)
        {
            //Max take UI;
        }
    }
}
