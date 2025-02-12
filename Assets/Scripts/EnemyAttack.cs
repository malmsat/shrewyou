using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the "Player" tag
        {
            HealthController playerHealth = other.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                Debug.Log("Player hit by AttackCollider! Dealing damage...");
                playerHealth.TakeDamage(100); // Instantly kill the player
            }
        }
    }
}
