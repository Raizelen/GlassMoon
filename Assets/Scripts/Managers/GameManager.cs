using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    [SerializeField] private int lastLevel = 2;
    private int currentLevel = 1;
    private GameObject player
    {
        get
        {
            return GameObject.FindGameObjectWithTag("Player");
        }
    }

    private IEnumerator UpdateAbilities()
    {
        while (true)
        {
            if (currentLevel == 1)
            {
                player.GetComponent<PlayerMovement>().doubleJumpAbility = false;
                player.GetComponent<PlayerMovement>().dashAbility = false;
            }
            if (currentLevel == 2)
            {
                player.GetComponent<PlayerMovement>().doubleJumpAbility = false;
                player.GetComponent<PlayerMovement>().dashAbility = true;
            }
            if (currentLevel == 3)
            {
                player.GetComponent<PlayerMovement>().doubleJumpAbility = true;
                player.GetComponent<PlayerMovement>().dashAbility = true;
            }
            yield return new WaitForSeconds(.5f);
        }
    }

    private void Start()
    {
        CameraUIManager.instance.ShowMessage(player.transform.position + Vector3.right * 6f, "Another day, New adventure", 2f);
        StartCoroutine(UpdateAbilities());
    }

    public void OnPlayerDeath()
    {
        SceneManager.LoadScene("Scenes/Level " + currentLevel);
    }

    public void OnFinish()
    {
        currentLevel += 1;
        if (currentLevel == lastLevel + 1)
        {
            SceneManager.LoadScene("Scenes/Game Complete");
            return;
        }
        SceneManager.LoadScene("Scenes/Level " + currentLevel);
    }
}
