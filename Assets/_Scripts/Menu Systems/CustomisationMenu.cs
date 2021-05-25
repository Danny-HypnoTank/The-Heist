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

    [SerializeField]
    private GameObject car2PurchaseButton;
    [SerializeField]
    private GameObject car3PurchaseButton;
    [SerializeField]
    private GameObject car4PurchaseButton;
    [SerializeField]
    private GameObject car5PurchaseButton;
    [SerializeField]
    private int[] carPurchasedCheckForEquip;
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

        if (PlayerPrefs.HasKey("OffShoreMoney"))
        {
            offShoreMoney = PlayerPrefs.GetInt("OffShoreMoney");
        }
        else
        {
            offShoreMoney = 0;
        }

        CarPurchaseCheck();

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
        if (carPurchasedCheckForEquip[curCar] == 1)
        {
            PlayerPrefs.SetInt("CarSprite", curCar);
            currentCarIamge.sprite = curCarSprites[curCar];
        }
    }

    public void PurchaseCar2Button()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            PlayerPrefs.SetInt("Car2Purchased", 1);
            PlayerPrefs.Save();
            carPurchasedCheckForEquip[1] = 1;
            car2PurchaseButton.SetActive(false);
        }
        else
        {

        }
    }
    public void PurchaseCar3Button()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            PlayerPrefs.SetInt("Car3Purchased", 1);
            carPurchasedCheckForEquip[2] = 1;
            PlayerPrefs.Save();
            car3PurchaseButton.SetActive(false);
        }
        else
        {

        }
    }
    public void PurchaseCar4Button()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            PlayerPrefs.SetInt("Car4Purchased", 1);
            carPurchasedCheckForEquip[3] = 1;
            PlayerPrefs.Save();
            car4PurchaseButton.SetActive(false);
        }
        else
        {

        }
    }
    public void PurchaseCar5Button()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            PlayerPrefs.SetInt("Car5Purchased", 1);
            carPurchasedCheckForEquip[4] = 1;
            PlayerPrefs.Save();
            car5PurchaseButton.SetActive(false);
        }
        else
        {

        }
    }

    public void PurchaseBoostButton()
    {
        if (spendableMoney > 1 && PlayerPrefs.GetInt("BoostPurchased") == 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            PlayerPrefs.SetInt("BoostPurchased", 1);
            PlayerPrefs.Save();
        }
        else
        {

        }
    }
    public void PurchaseIncreaseSpeed()
    {
        if (spendableMoney > 1 && PlayerPrefs.GetInt("IncreaseSpeed") == 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            PlayerPrefs.SetInt("IncreaseSpeed", 1);
            PlayerPrefs.Save();
        }
        else
        {

        }
    }
    public void PurchaseCarUpgrade2()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            PlayerPrefs.SetInt("", 1);
            PlayerPrefs.Save();
        }
        else
        {

        }
    }
    public void PurchaseCarUpgrade3()
    {
        if (spendableMoney > 1)
        {
            spendableMoney -= 1;
            spendableMoneyCarText.text = "$: " + spendableMoney;
            spendableMoneyCrewText.text = "$: " + spendableMoney;
            spendableMoneyHackText.text = "$: " + spendableMoney;
            PlayerPrefs.SetInt("", 1);
            PlayerPrefs.Save();
        }
        else
        {

        }

    }

    private void CarPurchaseCheck()
    {
        carPurchasedCheckForEquip[0] = 1;
        if (PlayerPrefs.GetInt("Car2Purchased") == 1)
        {
            car2PurchaseButton.SetActive(false);
            carPurchasedCheckForEquip[1] = 1;
        }
        else
        {
            car2PurchaseButton.SetActive(true);
            carPurchasedCheckForEquip[1] = 0;
        }
        if (PlayerPrefs.GetInt("Car3Purchased") == 1)
        {
            car3PurchaseButton.SetActive(false);
            carPurchasedCheckForEquip[2] = 1;
        }
        else
        {
            car3PurchaseButton.SetActive(true);
            carPurchasedCheckForEquip[2] = 0;
        }
        if (PlayerPrefs.GetInt("Car4Purchased") == 1)
        {
            car4PurchaseButton.SetActive(false);
            carPurchasedCheckForEquip[3] = 1;
        }
        else
        {
            car4PurchaseButton.SetActive(true);
            carPurchasedCheckForEquip[3] = 0;
        }
        if (PlayerPrefs.GetInt("Car5Purchased") == 1)
        {
            car5PurchaseButton.SetActive(false);
            carPurchasedCheckForEquip[4] = 1;
        }
        else
        {
            car5PurchaseButton.SetActive(true);
            carPurchasedCheckForEquip[4] = 0;
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
