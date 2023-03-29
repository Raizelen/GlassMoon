using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(inGameUI);
    }

    [SerializeField] GameObject inGameUI;

    [SerializeField] private int lastLevel = 2;
    private int currentLevel = 1;
    
    public void OnPlayerDeath()
    {
        SceneManager.LoadScene("Scenes/Level " + currentLevel);
    }

    public void OnFinish()
    {
        currentLevel += 1;
        if (currentLevel == lastLevel + 1)
        {
            Debug.Log("Game complete");
            return;
        }
        SceneManager.LoadScene("Scenes/Level " + currentLevel);
    }
}
