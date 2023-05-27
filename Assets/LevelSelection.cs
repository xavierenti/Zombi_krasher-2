using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void CambiaeNivel(string nombreNibel)
    {
        SceneManager.LoadScene(nombreNibel);
    }
    public void CambiaeNivel(int numeroNibel)
    {
        SceneManager.LoadScene(numeroNibel);
    }
}
