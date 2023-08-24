using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RestartGameUI : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; // >:(
    public Button restartButton;

    private void Start()
    {
        HideGameOverUI();
    }

    public void ShowGameOverUI()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void HideGameOverUI()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }
}
