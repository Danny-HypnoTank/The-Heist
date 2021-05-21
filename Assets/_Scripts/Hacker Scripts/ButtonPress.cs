using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour {
    public static string correctCode = "0692";
    public static string playerCode = "";

    public static int totalDigits=0;

    public static string didclick = "n";

    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject LoseScreen;

    [SerializeField]
    private Text timer;
    [SerializeField]
    private GameObject keyPadTimer;
    [SerializeField]
    private float timeRemaining = 60;
    private bool levelComplete = false;

    public GameObject objective;


    // Start is called before the first frame update
    void Start()
    {
        winScreen.gameObject.SetActive(false);
        LoseScreen.gameObject.SetActive(false);
        keyPadTimer.SetActive(true);
        timer.text = "Time Remaining: " + timeRemaining;
        objective.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerCode);

        if (totalDigits == 4)
        {
            if (playerCode==correctCode)
            {
                Debug.Log("Correct!");
                levelComplete = true;
                keyPadTimer.SetActive(false);
               winScreen.gameObject.SetActive(true);
               // timer.gameObject.SetActive(false);
               objective.gameObject.SetActive(false);
            }

            else
            {
                playerCode = "";
                totalDigits = 0;
                Debug.Log("Wrong code try again");
            }
        }
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

    private void OnMouseUp()
    {
        playerCode += gameObject.name;
        totalDigits += 1;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);
        StartCoroutine(waittochange());
        didclick = "y";
    }


     void OnMouseOver()
    {
        if (didclick == "n")
        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
    }


     void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    IEnumerator waittochange()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        didclick = "n";
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(0);
    }
}

