using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField]
    GameObject pauseMenu;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }



    public void ResumeGame ()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");
    }
}
