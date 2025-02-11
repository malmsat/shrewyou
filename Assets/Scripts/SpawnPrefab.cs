using UnityEngine;
using System.Collections;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;  // Array to hold the different prefabs
    public float spawnRadius = 10f;      // The area radius where prefabs will spawn
    public LayerMask groundLayer;        // The ground layer to detect the ground

    public float spawnInterval = 1f;     // The interval time (in seconds) between spawns

    private void Start()
    {
        // Start the coroutine to spawn prefabs every second
        StartCoroutine(SpawnObjectPeriodically());
    }

    private IEnumerator SpawnObjectPeriodically()
    {
        // Continuously spawn prefabs every 'spawnInterval' seconds
        while (true)
        {
            SpawnObject();  // Call function to spawn object
            yield return new WaitForSeconds(spawnInterval);  // Wait for 'spawnInterval' seconds before spawning again
        }
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
            // Randomly choose a prefab from the array
            int randomIndex = Random.Range(0, prefabsToSpawn.Length);

            // Instantiate the selected prefab at the hit point
            GameObject spawnedObject = Instantiate(prefabsToSpawn[randomIndex], hit.point, Quaternion.identity);

            // Adjust the position to sit correctly on the ground
            Collider collider = spawnedObject.GetComponent<Collider>();
            if (collider != null)
            {
                float objectHeight = collider.bounds.extents.y;
                spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x,
                    spawnedObject.transform.position.y + objectHeight, spawnedObject.transform.position.z);
            }

            // Destroy the object after 60 seconds
            Destroy(spawnedObject, 60f);
        }
    }

}
