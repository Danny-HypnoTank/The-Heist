using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour

{
    [SerializeField]
    private Text timer;
    [SerializeField]
    private GameObject keyPadTimer;
    [SerializeField]
    private float timeRemaining = 60;
    private bool levelComplete = false;
    [SerializeField]
    private GameObject LoseScreen;
    [SerializeField]
    private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        keyPadTimer.SetActive(true);
        timer.text = "Time Remaining: " + timeRemaining;
        LoseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelComplete != true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            timer.text = "Time Remaining: " + timeRemaining.ToString("f0");

            if (timeRemaining <= 0)
            {
                keyPadTimer.SetActive(false);
                LoseScreen.SetActive(true);
            }
        }
    }
}
