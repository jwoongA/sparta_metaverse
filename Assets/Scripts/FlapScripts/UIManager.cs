using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    public GameObject scoreUI;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI currentScoreText;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowScore(int score)
    {
        scoreUI.SetActive(true);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score >  highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreText.text = highScore.ToString();
        currentScoreText.text = score.ToString();
    }
}
