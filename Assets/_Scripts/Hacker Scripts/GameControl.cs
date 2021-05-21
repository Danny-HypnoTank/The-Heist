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
    private float timeRemaining = 60;
    private bool levelComplete = false;
    [SerializeField]
    private GameObject winUI;
    [SerializeField]
    private GameObject loseUI;
    [SerializeField]
    private GameObject timerOBJ;


    public static bool youWin;

    public GameObject objective;

    // Start is called before the first frame update
    void Start()
    {
        winUI.SetActive(false);
        loseUI.SetActive(false);
        timerOBJ.SetActive(true);
        youWin = false;
        objective.SetActive(true);
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
                timerOBJ.SetActive(false);
                loseUI.SetActive(true);
            }
        }

        if (pictures[0].rotation.z == 0 &&
            pictures[1].rotation.z == 0 &&
            pictures[2].rotation.z == 0 &&
            pictures[3].rotation.z == 0)
        {
            youWin = true;
            levelComplete = true;
        }     

        if (youWin == true)
        {
            objective.SetActive(false);
            timerOBJ.SetActive(false);
            winUI.SetActive(true);
        }
        
       

    }
}
