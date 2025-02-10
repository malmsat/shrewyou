using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGate : MonoBehaviour
{
    [SerializeField] private int _nextSceneIndex; // Set the scene index in Inspector
    private bool _canEnter = false;

    private void Start()
    {
        // Find the player's HealthController to track XP changes
        HealthController playerHealth = FindObjectOfType<HealthController>();
        if (playerHealth != null)
        {
            playerHealth.OnXPChanged.AddListener(CheckXP);
            CheckXP(); // Run once to update immediately
        }
    }

    private void CheckXP()
    {
        // Allow entry if XP is full
        HealthController playerHealth = FindObjectOfType<HealthController>();
        if (playerHealth != null && playerHealth.XPPercentage >= 1f)
        {
            _canEnter = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _canEnter)
        {
            SceneManager.LoadScene(_nextSceneIndex);
        }
    }
}
