using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RestartGameUI : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    private bool isGameOverUIVisible = false;

    private void Start()
    {
        HideGameOverUI();
    }

    public void ShowGameOverUI()
    {
        isGameOverUIVisible = true;
        this.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void HideGameOverUI()
    {
        isGameOverUIVisible = false;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public bool IsGameOverUIVisible()
    {
        return isGameOverUIVisible;
    }

    public void RestartGame()
    {
        Debug.Log("RestartGame method called!");
        GameManager.Instance.ResetCurrentScore();
        GameManager.Instance.RestartGame();
        GameController gameController = FindObjectOfType<GameController>();
        if (gameController != null)
        {
            gameController.ClearAllFallingObjects();
        }
    }
}
