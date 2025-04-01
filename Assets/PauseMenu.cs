using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject LoseMenu;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private GameObject Player;
    public static bool ispaused;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Player == null) {
        //    Lose();
        //}

        if (Input.GetKeyDown(KeyCode.Escape)){
            if (ispaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        if (UpgradeMenu.isupgrademenu == false || SpecialUpgradeMenu.isspecialupgrademenu==false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            ispaused = true;
        }
    }
    public void Lose()
    {
        if (LoseMenu != null)
        {
            LoseMenu.SetActive(true);
            Time.timeScale = 0f;
            ispaused = true;
        }
    }
    public void Win()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        ispaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        ispaused = false;
    }
    public void Main()
    {
        Time.timeScale = 1f;
        ispaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
