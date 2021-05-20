using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationMenu : MonoBehaviour
{



    #region CarMenu
    [SerializeField]
    private GameObject[] carUI;
    [SerializeField]
    private int curCar;

    private void Start()
    {
        curCar = 0;
        carUI[curCar].SetActive(true);
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
    }

    public void PurchaseBoostButton()
    {
        //Unlock Boost Ability;
    }
    #endregion




    //Crew Customisation - upgrades
    public void CrewUpgrade()
    {
        PlayerPrefs.SetInt("CrewUpgrades", 1);
        PlayerPrefs.Save();
    }

    //Hacking Customisation - upgrades
}
