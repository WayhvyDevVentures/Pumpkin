using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int highScore = 0;
    private int currentScore = 0;
    public TextMeshProUGUI highScoreText;
    public RestartGameUI restartGameUI;
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        LoadHighScore();

        if (restartGameUI == null)
        {
            Debug.LogError("RestartGameUI reference is null in GameManager!");
        }
        else
        {
            Debug.Log("Calling HideGameOverUI from GameManager Start()");
            restartGameUI.HideGameOverUI();
        }
    }

    public void UpdateHighScoreText()
    {
        if (highScoreText == null)
        {
            Debug.LogError("HighScoreText reference is null in GameManager!");
            return;
        }

        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    public void UpdateHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
            UpdateHighScoreText();
        }
    }

    public void IncrementCurrentScore()
    {
        currentScore++;
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void GameOver()
    {
        CharacterMove characterMove = FindObjectOfType<CharacterMove>();
        if (characterMove != null)
        {
            characterMove.enabled = false;

            if (restartGameUI == null)
            {
                Debug.LogError("RestartGameUI reference is null in GameManager!");
            }
            else
            {
                restartGameUI.ShowGameOverUI();
            }
        }
    }

    public void RestartGame()
    {
        currentScore = 0;
        UpdateHighScoreText();

        if (restartGameUI == null)
        {
            Debug.LogError("RestartGameUI reference is null in GameManager!");
        }
        else
        {
            restartGameUI.HideGameOverUI();
        }

        CharacterMove characterMove = FindObjectOfType<CharacterMove>();
        if (characterMove != null)
        {
            characterMove.ResetPosition();
            characterMove.enabled = true;
        }
    }
}