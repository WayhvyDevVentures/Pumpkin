using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] fallingObjectPrefabs;
    public float minXSpawn = -5.0f;
    public float maxXSpawn = 5.0f;
    public float spawnY = 10.0f;
    public float spawnInterval = 0.01f;

    private Collider2D collectionZoneCollider;

    private void Start()
    {
        collectionZoneCollider = GetComponentInChildren<Collider2D>();
        InvokeRepeating("SpawnRandomFallingObject", 1.0f, spawnInterval);
    }

    private void SpawnRandomFallingObject()
    {
        int randomIndex = Random.Range(0, fallingObjectPrefabs.Length);
        float randomXSpawn = Random.Range(minXSpawn, maxXSpawn);

        Vector3 spawnPosition = new Vector3(randomXSpawn, spawnY, 0f);

        GameObject newObject = Instantiate(fallingObjectPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        Rigidbody2D newObjectRigidbody = newObject.GetComponent<Rigidbody2D>();
        newObjectRigidbody.gravityScale = 0.1f;
    }
}