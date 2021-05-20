using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region UI Menu Variables
    [SerializeField]
    private GameObject mainMenuUI;
    [SerializeField]
    private GameObject hubUI;
    [SerializeField]
    private GameObject heistUI;
    [SerializeField]
    private GameObject carUI;
    [SerializeField]
    private GameObject crewUI;
    [SerializeField]
    private GameObject hackerUI;
    [SerializeField]
    private GameObject optionsUI;
    [SerializeField]
    private GameObject quitUI;
    #endregion

    #region Heist Select Menu Variables
    [SerializeField]
    private GameObject heistContractUI;
    [SerializeField]
    private Text heistName;
    [SerializeField]
    private Text heistDiscription;
    [SerializeField]
    private Text heistTakeText;
    [SerializeField]
    private Text heistExpenseText;
    private int DriverLevelToLoad;
    private int HackerLevelToLoad;
    #endregion

    #region Scene Start
    public void Start()
    {
        mainMenuUI.SetActive(true);
        hubUI.SetActive(false);
        heistUI.SetActive(false);
        heistContractUI.SetActive(false);
        carUI.SetActive(false);
        crewUI.SetActive(false);
        hackerUI.SetActive(false);
        optionsUI.SetActive(false);
        quitUI.SetActive(false);
    }
    #endregion

    #region Menu Transition Buttons
    public void StartButton()
    {
        mainMenuUI.SetActive(false);
        hubUI.SetActive(true);
        heistUI.SetActive(false);
        heistContractUI.SetActive(false);
        carUI.SetActive(false);
        crewUI.SetActive(false);
        hackerUI.SetActive(false);
        optionsUI.SetActive(false);
        quitUI.SetActive(false);
    }

    public void HeistButton()
    {
        mainMenuUI.SetActive(false);
        hubUI.SetActive(false);
        heistUI.SetActive(true);
        heistContractUI.SetActive(false);
        carUI.SetActive(false);
        crewUI.SetActive(false);
        hackerUI.SetActive(false);
        optionsUI.SetActive(false);
        quitUI.SetActive(false);
    }

    public void CarCUButton()
    {
        mainMenuUI.SetActive(false);
        hubUI.SetActive(false);
        heistUI.SetActive(false);
        heistContractUI.SetActive(false);
        carUI.SetActive(true);
        crewUI.SetActive(false);
        hackerUI.SetActive(false);
        optionsUI.SetActive(false);
        quitUI.SetActive(false);
    }

    public void CrewCUButton()
    {
        mainMenuUI.SetActive(false);
        hubUI.SetActive(false);
        heistUI.SetActive(false);
        heistContractUI.SetActive(false);
        carUI.SetActive(false);
        crewUI.SetActive(true);
        hackerUI.SetActive(false);
        optionsUI.SetActive(false);
        quitUI.SetActive(false);
    }

    public void HackerCUButton()
    {
        mainMenuUI.SetActive(false);
        hubUI.SetActive(false);
        heistUI.SetActive(false);
        heistContractUI.SetActive(false);
        carUI.SetActive(false);
        crewUI.SetActive(false);
        hackerUI.SetActive(true);
        optionsUI.SetActive(false);
        quitUI.SetActive(false);
    }
    #endregion

    #region Heist Select Buttons
    //Level Select Buttons
    public void Level1Button()
    {
        //heist title
        heistName.text = "Test Heist";
        //heist discription
        heistDiscription.text = "Heist Discription text testing";
        DriverLevelToLoad = 1;
        HackerLevelToLoad = 2;
        heistContractUI.SetActive(true);
    }
    public void Level2Button()
    {
        //heist title
        heistName.text = "Test Heist";
        //heist discription
        heistDiscription.text = "Heist Discription text testing";
        DriverLevelToLoad = 1;
        HackerLevelToLoad = 3;
        heistContractUI.SetActive(true);
    }
    public void Level3Button()
    {
        //heist title
        heistName.text = "Test Heist";
        //heist discription
        heistDiscription.text = "Heist Discription text testing";
        DriverLevelToLoad = 1;
        HackerLevelToLoad = 4;
        heistContractUI.SetActive(true);
    }
    public void DriverButton()
    {
        SceneManager.LoadScene(DriverLevelToLoad);
    }
    public void HackerButton()
    {
        SceneManager.LoadScene(HackerLevelToLoad);
    }
    public void CloseHeist()
    {
        heistContractUI.SetActive(false);
    }
    #endregion

    #region Quit and Options Menu Functions
    //Options Buttons
    public void OptionsButton()
    {
        optionsUI.SetActive(true);
    }
    public void CloseOptionsButton()
    {
        optionsUI.SetActive(false);
    }

    //QUIT Buttons
    public void QuitButton()
    {
        quitUI.SetActive(true);
    }
    public void YesQuitButton()
    {
        //Close application
    }
    public void NoQuitButton()
    {
        quitUI.SetActive(false);
    }
    #endregion
}
