using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomisationMenu : MonoBehaviour
{
    //Universal Variables
    private int spendableMoney;
    private int offShoreMoney;

    #region Hub Variables
    [SerializeField]
    private Image currentCarIamge;
    [SerializeField]
    private Sprite[] curCarSprites;
    [SerializeField]
    private Text spendableMoneyHubText;
    #endregion

    #region Car Variables
    [SerializeField]
    private GameObject[] carUI;
    [SerializeField]
    private int curCar;
    [SerializeField]
    private Text spendableMoneyCarText;
    #endregion

    #region Crew Variables
    [SerializeField]
    private Text spendableMoneyCrewText;
    [SerializeField]
    private Text offShoreMoneyText;
    #endregion

    #region Hacker Variables
    [SerializeField]
    private Text spendableMoneyHackText;
    #endregion

    #region CarMenu
    private void Start()
    {
        if (PlayerPrefs.HasKey("SpendableMoney"))
        {
            spendableMoney = PlayerPrefs.GetInt("SpendableMoney");
        }
        else
        {
            spendableMoney = 0;
        }

        curCar = 0;
        carUI[curCar].SetActive(true);
        currentCarIamge.sprite = curCarSprites[curCar];
        spendableMoneyHubText.text = "$: " + spendableMoney;
        spendableMoneyCarText.text = "$: " + spendableMoney;
        spendableMoneyCrewText.text = "$: " + spendableMoney;
        spendableMoneyHackText.text = "$: " + spendableMoney;
        offShoreMoneyText.text = "Off Shore Account: $" + offShoreMoney;
    }

    public void NextButton()
    {
        if (curCar < 4 )
        {
            curCar++;
            for (int i = 0; i < carUI.Length; i++)
            {
                carUI[i].SetActive(false);
            }
            carUI[curCar].SetActive(true);
        }
        else if (curCar == 4)
        {
            curCar = 0;
            for (int i = 0; i < carUI.Length; i++)
            {
                carUI[i].SetActive(false);
            }
            carUI[curCar].SetActive(true);
        }
    }
    public void PreviousButton()
    {
        if (curCar > 0)
        {
            curCar--;
            for (int i = 0; i < carUI.Length; i++)
            {
                carUI[i].SetActive(false);
            }
            carUI[curCar].SetActive(true);
        }
        else if (curCar == 0)
        {
            curCar = 4;
            for (int i = 0; i < carUI.Length; i++)
            {
                carUI[i].SetActive(false);
            }
            carUI[curCar].SetActive(true);
        }
    }
    public void EquipButton()
    {
        PlayerPrefs.SetInt("CarSprite", curCar);
        currentCarIamge.sprite = curCarSprites[curCar];
    }

    public void PurchaseBoostButton()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            //Enable Boost inGame - through prefs
        }
        else
        {

        }
    }
    public void IncreaseGarageSize()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            //Increase garagesize - through prefs
        }
        else
        {

        }
    }
    #endregion

    #region Crew Upgrades
    public void IncreaseAvailableHeists()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            //Increase available heist level - through prefs
        }
        else
        {

        }
    }

    public void IncreaseMoneyPerTake()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;

            PlayerPrefs.SetInt("IncreaseMoneyPerTake", 1);
            PlayerPrefs.Save();
        }
        else
        {

        }
    }

    public void IncreaseMaxBeforePickup()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;

            PlayerPrefs.SetInt("IncreaseMaxBeforePickup", 1);
            PlayerPrefs.Save();
        }
        else
        {

        }
    }

    public void IncreaseTakeSpeed()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;

            PlayerPrefs.SetInt("IncreaseTakeSpeed", 1);
            PlayerPrefs.Save();
        }
        else
        {

        }
    }

    public void IncreaseChanceOfNotBeingCaught()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;

            PlayerPrefs.SetInt("IncreaseChanceOfNotBeingCaught", 1);
            PlayerPrefs.Save();
        }
        else
        {

        }
    }
    #endregion

    #region Hacker Upgrades
    //Hacking Customisation - upgrades
    #endregion
}
