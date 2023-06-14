using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool IsPaused = false;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.visible = false;
    }

    public void Restart(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Controls(GameObject idk)
    {
        idk.SetActive(true);
    }

    public void ExitControls(GameObject idk)
    {
        idk.SetActive(false);
    }

    public void ExitGame(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
}
