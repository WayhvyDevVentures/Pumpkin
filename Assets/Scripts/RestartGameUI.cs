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
        this.gameObject.SetActive(true);
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
        Debug.Log("RestartGame method called!");
        GameManager.Instance.ResetCurrentScore(); // Reset the current score to 0
        GameManager.Instance.RestartGame();
    }
}
