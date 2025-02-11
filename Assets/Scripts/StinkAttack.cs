using UnityEngine;

public class StinkAttack : MonoBehaviour
{
    [SerializeField] private ParticleSystem stinkEffect; // Reference to the stink effect
    [SerializeField] private float stinkRadius = 5f; // How far the stink attack affects enemies
    [SerializeField] private LayerMask enemyLayer; // Enemy layer for detection

    [SerializeField] private AudioSource stunSound; // Optional: Sound when stunned

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // If player presses 'E'
        {
            PlayerStinkAttack();
        }
    }

    private void PlayerStinkAttack()
    {
        if (stinkEffect != null)
        {
            stinkEffect.Stop();  // Stop in case it's still playing
            stinkEffect.Play();  // Play the effect
        }
        
        if (stunSound != null)
            stunSound.Play(); // Play stun sound

        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, stinkRadius, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.StunEnemy(); // Call enemy's stun method
            }
        }
    }
}

