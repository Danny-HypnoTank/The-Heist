using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeistTracker : MonoBehaviour
{
    #region Money Collection Variables
    [SerializeField]
    private Text moneyText;
    private int money;
    private int totalTake = 0;
    private float takeDelay = 1;
    private float Timer;
    #endregion

    #region UI References
    [SerializeField]
    private GameObject boostButton;
    private bool boostenabled = false;

    [SerializeField]
    private Text objectiveText;
    [SerializeField]
    private Text heistTimer;
    [SerializeField]
    private GameObject heistTimerGB;

    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private GameObject quitUI;

    [SerializeField]
    private GameObject loseUI;
    [SerializeField]
    private Text loseBreakdownTakeText;
    [SerializeField]
    private Text loseOutGoingsText;
    [SerializeField]
    private Text loseTotalTakeText;

    [SerializeField]
    private GameObject winUI;
    [SerializeField]
    private Text winBreakdownTakeText;
    [SerializeField]
    private Text winOutGoingsText;
    [SerializeField]
    private Text winTotalTakeText;
    #endregion

    #region GameObject References for Objectives
    [SerializeField]
    private GameObject[] objectives;
    [SerializeField]
    private GameObject heistLocation;
    [SerializeField]
    private GameObject[] exits;
    #endregion

    private float heistTime;
    private float pickupTime;

    #region Objective Conditions
    public bool droppingOff = false;
    private bool dropOffComplete = false;
    public bool heistInProgress = false;
    public bool pickupRequired = false;
    public bool pickedUpHeisters = false;
    public bool heistersCaught = false;
    public bool heistersEscape = false;

    public bool EnabledCops = false;
    private int exitToActivate;
    #endregion

    #region On Level Start Functions
    private void Awake()
    {
        heistTime = 30;
        pickupTime = 10;
        money = 10;
        exitToActivate = Random.Range(0, 5);
        EnabledCops = true;
    }

    private void Start()
    {
        droppingOff = false;
        boostButton.SetActive(false);
        boostenabled = false;
        objectiveText.text = "Get to the drop off point";
        objectives[0].SetActive(true);
        heistLocation.SetActive(true);
        pauseUI.SetActive(false);
        quitUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
        heistTimerGB.SetActive(false);
    }
    #endregion

    #region Mission Objective functions and Rules
    private void Update()
    {
        if (heistersCaught == false && heistersEscape == false)
        {
            DropOffProgress();
            EnableBoost();

            if (dropOffComplete == true && heistInProgress == true)
            {
                HeistProgress();
            }

            moneyText.text = "Total Take: " + totalTake;

            if (pickupRequired == true)
            {
                PickUpProgress();
            }
        }
        if (pickedUpHeisters == true)
        {
            PickedUpHeisters();
        }
    }

    private void DropOffProgress()
    {
        if (droppingOff == true)
        {
            objectiveText.text = "Standy by dropping off crew";
            StartCoroutine(DropOffTimer());
        }
    }

    private void HeistProgress()
    {
        heistTimerGB.SetActive(true);
        if (PlayerPrefs.GetInt("BoostPurchased") == 1)
        {
            boostenabled = true;
        }
        EnabledCops = true;
        if (heistersCaught == false)
        {
            if (heistTime > 0)
            {
                heistTime -= Time.deltaTime;
            }
            heistTimer.text = heistTime.ToString("f0");
            TakeMoney();
        }

        if (heistTime <= 0)
        {
            pickupRequired = true;
            heistInProgress = false;
        }
    }

    private void TakeMoney()
    {
        Timer += Time.deltaTime;
        if (PlayerPrefs.GetInt("CrewUpgrades") == 1)
        {
            takeDelay = 1;
            if (Timer >= takeDelay)
            {
                Timer = 0f;
                totalTake += money + 5;
            }
        }
        else if (PlayerPrefs.GetInt("CrewUpgrades") == 1 && PlayerPrefs.GetInt("IncreaseTakeSpeed") == 1)
        {
            takeDelay = 0.75f;
            if (Timer >= takeDelay)
            {
                Timer = 0f;
                totalTake += money + 5;
            }
        }
        else if (PlayerPrefs.GetInt("CrewUpgrades") != 1 && PlayerPrefs.GetInt("IncreaseTakeSpeed") == 1)
        {
            takeDelay = 0.75f;
            if (Timer >= takeDelay)
            {
                Timer = 0f;
                totalTake += money;
            }
        }
        else
        {
            takeDelay = 1;
            if (Timer >= takeDelay)
            {
                Timer = 0f;
                totalTake += money;
            }
        }

    }

    private void PickUpProgress()
    {
        heistTimerGB.SetActive(true);
        if (PlayerPrefs.GetInt("BoostPurchased") == 1)
        {
            boostenabled = true;
        }
        if (pickupRequired == true && heistersCaught == false)
        {
            objectives[1].SetActive(true);
            if (pickupTime > 0)
            {
                pickupTime -= Time.deltaTime;
            }
            heistTimer.text = pickupTime.ToString("f0");
        }

        if (pickupTime <= 0)
        {
            heistersCaught = true;
            HeistConditions();
        }
    }

    private void PickedUpHeisters()
    {
        heistTimerGB.SetActive(false);
        objectives[1].SetActive(false);
        objectiveText.text = "Escape the city";
        exits[exitToActivate].SetActive(true);
    }

    public void HeistConditions()
    {
        if (heistersCaught == true)
        {
            boostenabled = false;
            Debug.Log("You lost");
            PauseGame();
            loseUI.SetActive(true);
            //game end with a loss
            HeistBreakdown();
        }
        if (heistersEscape == true)
        {
            boostenabled = false;
            Debug.Log("You Win");
            PauseGame();
            winUI.SetActive(true);
            //game end with win
            HeistBreakdown();
        }
    }

    private void HeistBreakdown()
    {
        if (heistersCaught == true)
        {
            loseBreakdownTakeText.text = "Take: " + totalTake / 10;
            loseOutGoingsText.text = "Expenditure: " + 10;
            loseTotalTakeText.text = "Total Take: " + ((totalTake / 10) - 10);

        }

        if (heistersEscape == true)
        {
            winBreakdownTakeText.text = "Take: " + totalTake;
            winOutGoingsText.text = "Expenditure: " + 10;
            winTotalTakeText.text = "Total Take: " + (totalTake);
            PlayerPrefs.SetInt("SpendableMoney", totalTake);
            PlayerPrefs.SetInt("OffShoreMoney", totalTake);
        }
    }
    #endregion

    #region Enablers for abilities and Timers
    IEnumerator DropOffTimer()
    {
        yield return new WaitForSeconds(3f);
        droppingOff = false;
        dropOffComplete = true;
        objectives[0].SetActive(false);
        objectiveText.text = "Wait for heist to begin, keep an eye out";
        yield return new WaitForSeconds(3f);
        objectiveText.text = "We've been had, cops inbound. Distract them for as long as you can";
        heistInProgress = true;
    }

    private void EnableBoost()
    {
        if (boostenabled == true)
        {
            boostButton.SetActive(true);
        }
        else
        {
            boostButton.SetActive(false);
        }
    }

    private void PauseGame( )
    {
        Time.timeScale = 0;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
    #endregion

    #region In-Game UI Buttons
    //Pause Menu Functionality needed
    //Pause button
    public void PauseButton()
    {
        PauseGame();
        pauseUI.SetActive(true);
    }
    //Options
    public void OptionsButton()
    {
        //Open Options Panel
    }
    //Close Pause
    public void ClosePauseMenu()
    {
        pauseUI.SetActive(false);
        ResumeGame();
    }

    //Buttons Required
    //Continue to breakdown
    public void ContinueButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    //quit
    public void QuitButton()
    {
        quitUI.SetActive(true);
    }
    //Yes
    public void YesQuitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    //No
    public void NoQuitButton()
    {
        quitUI.SetActive(false);
    }
    #endregion

}
