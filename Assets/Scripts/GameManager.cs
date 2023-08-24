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
        restartGameUI.HideGameOverUI();
    }

    public void UpdateHighScoreText()
    {

        highScoreText.text = "High Score: " + highScore;
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
        ResetCurrentScore();
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

            if (restartGameUI != null)
            {
                restartGameUI.ShowGameOverUI();
            }
        }
    }

    public void RestartGame()
    {
        UpdateHighScoreText();
        ResetCurrentScore();
        if (restartGameUI != null)
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
