using UnityEngine;

public class GroundCollisionChecker : MonoBehaviour
{
    private RestartGameUI restartGameUI;

    private void Start()
    {
        restartGameUI = FindObjectOfType<RestartGameUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Clone"))
        {
            restartGameUI.ShowGameOverUI();
            GameManager.Instance.GameOver();
        }
    }
}
