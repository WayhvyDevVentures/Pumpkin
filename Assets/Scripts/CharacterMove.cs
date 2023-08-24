using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb;
    private int collectedCount = 0;
    public TMPro.TextMeshProUGUI collectedCountText;
    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        collectedCountText.text = "Collected: " + collectedCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            collectedCount++;
            gameManager.IncrementCurrentScore();
            gameManager.UpdateHighScoreText();
        }
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(0, 0, 0);
    }
}
