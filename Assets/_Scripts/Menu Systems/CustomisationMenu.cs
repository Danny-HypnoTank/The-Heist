using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomisationMenu : MonoBehaviour
{
    #region Hub Variables
    [SerializeField]
    private Image currentCarIamge;
    [SerializeField]
    private Sprite[] curCarSprites;
    #endregion

    #region Car Variables
    [SerializeField]
    private GameObject[] carUI;
    [SerializeField]
    private int curCar;
    #endregion

    #region CarMenu
    private void Start()
    {
        curCar = 0;
        carUI[curCar].SetActive(true);
        currentCarIamge.sprite = curCarSprites[curCar];
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
        //Unlock Boost Ability;
        //Enable Boost inGame - through prefs
    }
    public void IncreaseGarageSize()
    {

    }
    #endregion

    #region Crew Upgrades
    public void IncreaseAvailableHeists()
    {

    }
    public void IncreaseMoneyPerTake()
    {
        PlayerPrefs.SetInt("IncreaseMoneyPerTake", 1);
        PlayerPrefs.Save();
    }
    public void IncreaseMaxBeforePickup()
    {
        PlayerPrefs.SetInt("IncreaseMaxBeforePickup", 1);
        PlayerPrefs.Save();
    }
    public void IncreaseTakeSpeed()
    {
        PlayerPrefs.SetInt("IncreaseTakeSpeed", 1);
        PlayerPrefs.Save();
    }
    public void IncreaseChanceOfNotBeingCaught()
    {
        PlayerPrefs.SetInt("IncreaseChanceOfNotBeingCaught", 1);
        PlayerPrefs.Save();
    }
    #endregion

    #region Hacker Upgrades
    //Hacking Customisation - upgrades
    #endregion
}
