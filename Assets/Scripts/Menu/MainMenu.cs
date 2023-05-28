using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelect;
    public GameObject optionMenu;

    private void Start()
    {
        levelSelect.SetActive(false);
        optionMenu.SetActive(false);
    }
    public void Play()
    {
        levelSelect.SetActive(true);
    }
    public void EscenaOpciones()
    {
        SceneManager.LoadScene("Options");
    }

    public void EscenaControles()
    {
        SceneManager.LoadScene("ControlMenu");
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Menu()
    {
        levelSelect.SetActive(false);
        optionMenu.SetActive(false);
    }

    public void OpenOption()
    {
        optionMenu.SetActive(true);
    }
}
