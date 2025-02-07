using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;    // The prefab you want to spawn
    public float spawnRadius = 10f;     // The area radius where prefabs will spawn
    public LayerMask groundLayer;       // The ground layer to detect the ground

    void Start()
    {
        SpawnObject();  // Call function to spawn object
    }

    void SpawnObject()
    {
        // Generate random position within the spawn radius
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            50f,  // Start with a high Y value to check for ground detection
            Random.Range(-spawnRadius, spawnRadius)
        );

        // Cast a ray downwards from the generated position to find the ground
        RaycastHit hit;
        if (Physics.Raycast(randomPosition, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            // Instantiate the prefab at the hit point
            Instantiate(prefabToSpawn, hit.point, Quaternion.identity);
        }
    }
}
