using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public GameObject startUI;

    private bool isGameStarted = false;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }

    private int currentScore = 0;

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        Time.timeScale = 0f;
        startUI.SetActive(true);
        uiManager.UpdateScore(0);
    }

    public void StartGame()
    {
        if (isGameStarted) return;

        isGameStarted = true;
        Time.timeScale = 1f;
        startUI.SetActive(false);
    }

    public void GameOver()
    {
        uiManager.ShowScore(currentScore);
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
