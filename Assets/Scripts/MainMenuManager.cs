using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject info;

    public void Play()
    {
        SceneManager.LoadScene("Scenes/Level 1");
    }

    public void Info()
    {
        info.SetActive(true);
        main.SetActive(false);
    }

    public void Back()
    {
        info.SetActive(false);
        main.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit(0);
    }
}
