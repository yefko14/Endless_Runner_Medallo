using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void ButtonStore()
    {
        SceneManager.LoadScene("Store");
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene("Inicio");
    }
}
