using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    private int crows;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        crows = spawner.GetComponent<SpawnManager>().activeCrows;
    }

    public void GameOver()
    {
        if(crows >= 5)
        {
            SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(2).buildIndex);
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).buildIndex);
    }

    public void exitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
